using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class Order
    {
        public int id { get; set; }
        public Transaction transaction { get; set; }
        public int transactionid { get; set; }
        public Product product { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }
    }
}
