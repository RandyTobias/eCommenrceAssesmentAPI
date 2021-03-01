using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class Address
    {
        public int id { get; set; }
        public User user { get; set; }
        public int userid { get; set; }
        public string street1 { get; set; } = "";
        public string street2 { get; set; } = "";
        public string city { get; set; } = "";
        public int postalCode { get; set; }
        public int postalCodeExt { get; set; }
        public bool isPrimary { get; set; } = false;
        public List<Transaction> transactions { get; set; }
    }
}