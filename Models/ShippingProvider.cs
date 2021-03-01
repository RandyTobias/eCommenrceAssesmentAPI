using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class ShippingProvider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public float rateFlat { get; set; }

        public List<Transaction> transactions { get; set; }
    }
}
