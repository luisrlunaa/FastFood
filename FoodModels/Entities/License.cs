using System;

namespace FastFood.Models.Entities
{
    public class License
    {
        public int Id { get; set; }
        public string Business { get; set; }
        public int InitialSequence { get; set; }
        public int CentralSequence { get; set; }
        public int FinalSequence { get; set; }
        public string Provider { get; set; }
        public string SecretWord { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
