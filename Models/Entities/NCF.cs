using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class NCF
    {
        [Key]
        public int Id_ncf { get; set; }
        public string Description_ncf { get; set; }
        public string Prefix { get; set; }
        public int Initialsequence { get; set; }
        public int Finalsequence { get; set; }
    }

    public class Receipts
    {
        [Key]
        public int Id_ncf { get; set; }
        public int Initialsequence { get; set; }
        public int Finalsequence { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Active { get; set; }
    }

    public class NCFGenerated
    {
        [Key]
        public int Id_sequence { get; set; }
        public int SequenceNCF { get; set; }
        public DateTime Datein { get; set; }
    }

    public class NCFDto
    {
        public int Id_ncf { get; set; }
        public string Description_ncf { get; set; }
        public bool Active { get; set; }
    }
}
