using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class Client
    {
        [Key]
        public string DocumentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
