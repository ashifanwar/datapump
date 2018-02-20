using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using ODSFunction.Implementation;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ODSService.Controllers
{
    [RoutePrefix("api/ticket")]
    public class TicketController : ApiController
    {
        private readonly string _sbConnection;
        private readonly string _storageConnection;
        private static readonly string _queueName = "ticket";
        private static readonly string _container = "tickets";
        private const string CONTENT_TYPE = "application/json";
        private const string QueueAccessKey = "gF7bCC5rSITfHt7ssiV8Ryq7jSkcMkipEJJawgjgvy8=";
        private string _sbConnectionKey;
        private string TicketSendPolicy = "ticketsendpolicy";

        public TicketController()
        {
            _sbConnection = ConfigurationManager.AppSettings["ServiceBusConnection"];
            _storageConnection = ConfigurationManager.AppSettings["StorageConnectionString"];
            _sbConnectionKey = ConfigurationManager.AppSettings["ServiceBusConnectionKey"];
        }
         
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]Ticket ticket)
        {
            //var jsonData = await Request.Content.ReadAsStringAsync();
            //var ticket = JsonConvert.DeserializeObject<Ticket>(jsonData);

            //var jsonData = JsonConvert.SerializeObject(ticket);
            //await UploadToBlob(ticket.Id, jsonData);
            
            await QueueMessage(ticket);

            return Ok();
        }

        public async Task UploadToBlob(string blobName, string jsonData)
        {
            var storageAccount = CloudStorageAccount.Parse(_storageConnection);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference(_container);
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference(blobName);
            blockBlob.Properties.ContentType = CONTENT_TYPE;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
            {
                await blockBlob.UploadFromStreamAsync(stream);
            }
        }

        public async Task QueueMessage(Ticket ticket)
        {
            try
            {               
                var jsonData = JsonConvert.SerializeObject(ticket);
                await EnsureQueueExists();
                var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(TicketSendPolicy, QueueAccessKey, TimeSpan.FromMinutes(10));
                var namespaceManager = new NamespaceManager(ServiceBusEnvironment.CreateServiceUri("sb", "aanwarsb", string.Empty), tokenProvider);  
                MessagingFactory factory = MessagingFactory.Create(ServiceBusEnvironment.CreateServiceUri("sb", "aanwarsb", string.Empty), tokenProvider);
                var queueClient = factory.CreateQueueClient(_queueName);
                
                //var queueClient = QueueClient.CreateFromConnectionString(_sbConnection, _queueName);
                
                var brokeredMsg = new BrokeredMessage(jsonData);
                await queueClient.SendAsync(brokeredMsg);                
            }
            catch(Exception ex)
            {

            } 
            
        }

        private async Task EnsureQueueExists()
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(_sbConnection);
                if (!await namespaceManager.QueueExistsAsync(_queueName))
                {
                    var qd = new QueueDescription(_queueName);
                    qd.DefaultMessageTimeToLive = TimeSpan.FromHours(1);
                    qd.EnableDeadLetteringOnMessageExpiration = true;
                    qd.Authorization.Add(new SharedAccessAuthorizationRule(TicketSendPolicy, QueueAccessKey, new[] { AccessRights.Send }));
                    //qd.Authorization.Add(new SharedAccessAuthorizationRule(TicketSendPolicy, QueueAccessKey, new[] { AccessRights.Send }));
                    await namespaceManager.CreateQueueAsync(qd);
                }
            }
            catch(Exception ex)
            {

            } 
            
        }
    }

    public class Ticket_Test
    {
        public string Id { get; set; }
        public string Status { get; set; }
    }
}
