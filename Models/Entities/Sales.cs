using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class Sales
    {
        [Key]
        public int IdSale { get; set; }
        public int IdEmployee { get; set; }
        public string ClientName { get; set; }
        public string ClientRnc { get; set; }
        public string Address { get; set; }
        public string SalesCheckType { get; set; }
        public string DocumentType { get; set; }
        public string NroComprobante { get; set; }
        public string DeliveryName { get; set; }
        public decimal? DeliveryAmount { get; set; }
        public decimal Total { get; set; }
        public decimal Remaining { get; set; } //Restantes
        public DateTime? DateIn { get; set; }
    }
}
