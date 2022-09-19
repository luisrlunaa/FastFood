using System;

namespace Models.Entities
{
    public class SalesCheck
    {
        public int IdVenta { get; set; }
        public int IdEmployee { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string SalesCheckType { get; set; }
        public string DocumentType { get; set; }
        public string NroComprobante { get; set; }
        public string DeliveryName { get; set; }
        public decimal? DeliveryAmount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Remaining { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
