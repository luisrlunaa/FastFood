using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class SalesDetails
    {
        [Key]
        public int Id { get; set; }
        public int IdSale { get; set; }
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public decimal Prices { get; set; }
        public decimal Itbis { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Earnings { get; set; } //Ganancias por producto
        public DateTime? DateIn { get; set; }
    }
}
