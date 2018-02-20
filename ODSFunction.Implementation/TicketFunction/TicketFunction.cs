using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ODSFunction.Implementation.TicketFunction
{
    public class TicketFunction
    {
        private static string _dbConnection;
        private static string _storageConnectionString;
        private static string _container = "tickets";

        static TicketFunction() 
        {
            _dbConnection = ConfigurationManager.AppSettings["DBConnection"];
            _storageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
        }

        public static void Run(string ticket)
        {
            try
            {
                var ticketObj = JsonConvert.DeserializeObject<Ticket>(ticket);

                var insert = @"insert into TicketHistory (TicketId,Status) values (@ticketId, @status)";

                using (var con = new SqlConnection(_dbConnection))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@ticketId", ticketObj.Id);
                        cmd.Parameters.AddWithValue("@status", ticketObj.Status);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                }

                //await DeleteFromBlob(ticketObj.Id);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ticket exception {ex.Message}");
            }
        }

        private static async Task DeleteFromBlob(string blobRef)
        {
            var storageAccount = CloudStorageAccount.Parse(_storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference(_container);
            var blockBlob = container.GetBlockBlobReference(blobRef);
            await blockBlob.DeleteIfExistsAsync();
        }
    }
}
