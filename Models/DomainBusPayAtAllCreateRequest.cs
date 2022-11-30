namespace WebApplication3.Models
{
    public class DomainBusPayAtAllCreateRequest
    {
        public string ActionUrl { get; set; }
        public string MID { get; set; }
        public string ServiceId { get; set; }
        public string InviceNo { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyType { get; set; }
        public string ResponseUrlBack { get; set; }
        public string ResponseUrlCancel { get; set; }
        public string ResponseUrlConfirm { get; set; }
        public string Language { get; set; }
        public string ExpiredDate { get; set; }
        public string MessageSlip1 { get; set; }
        public string MessageSlip2 { get; set; }
        public string Channel { get; set; }
        public string CheckData { get; set; }
    }
}
