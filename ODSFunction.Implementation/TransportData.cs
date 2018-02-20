using System;

namespace ODSFunction.Implementation
{
    public class TransportData
    {
        public SupplementalItinerary PassengerTransportSupplementalItinerary { get; set; }
        public TicketInformation PassengerTransportGeneralTicketInformation { get; set; }
        public TravelAgency TravelAgencyData { get; set; }
        public AncillaryService AncillaryServiceCategoryData { get; set; }
        public PassengerTransportTripLeg PassengerTransportTripLegData { get; set; }
    }

    public class SupplementalItinerary
    {
        public string ClearingSequenceNumber { get; set; }
        public string ClearingCount { get; set; }
        public double TotalClearingAmount { get; set; }
        public string ComputerizedReservationSystem { get; set; }
    }

    public class TicketInformation
    {
        public string TicketNumber { get; set; }
        public string PassengerName { get; set; }
        public string CustomerCode { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingCarrier { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int NumberInParty { get; set; }
        public string ConjuctionTicketId { get; set; }
        public string ElectronicTicketId { get; set; }
        public string RestrctedTicketId { get; set; }
        public string IATAClientCode { get; set; }
        public string CreditReasonId { get; set; }
        public string TicketChangeId { get; set; }
        public double TotalFare { get; set; }
        public double TotalFees { get; set; }
        public double Taxes { get; set; }
        public double ExchangeTicketAmount { get; set; }
        public double ExchangeFeeAmount { get; set; }
        public string InvoiceNumber { get; set; }
    }

    public class TravelAgency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string AuthorizationCode { get; set; }
    }

    public class AncillaryService
    {
        public string CategoryCode { get; set; }
        public string SubCategoryCode { get; set; }
        public string Description { get; set; }
        public string AssociatedTicketNumber { get; set; }
    }

    public class PassengerTransportTripLeg
    {
        public string ConjuctionTicketNumber { get; set; }
        public string ExchangeTicketNumber { get; set; }
        public string CouponNumber { get; set; }
        public string ServiceClass { get; set; }
        public string CarrierCode { get; set; }
        public string StopoverCode { get; set; }
        public string OriginAirportCode { get; set; }
        public string DestinationAirportCode { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string FareBasisCode { get; set; }
        public double TripLegFare { get; set; }
        public double TripLegTaxes { get; set; }
        public double TripLegFees { get; set; }
        public string EndorsementsRestrictions { get; set; }
    }
}
