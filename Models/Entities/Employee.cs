using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class Employee
    {
        [Key]
        public int IdEmp { get; set; }
        public int? IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentType { get; set; }
        public string EmployeeType { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
