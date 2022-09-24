using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public int IdEmp { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
