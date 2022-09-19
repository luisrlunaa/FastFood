using System;
using System.ComponentModel.DataAnnotations;

namespace FastFoodDemo.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public decimal Stock { get; set; }
        public decimal Itbis { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal BayPrice { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string ImageName { get; set; }
    }
}
