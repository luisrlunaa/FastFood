using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class BusinessInfo
    {
        [Key]
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string RNC { get; set; }
    }
}
