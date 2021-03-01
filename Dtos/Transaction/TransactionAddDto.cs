using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Transaction
{
    public class TransactionAddDto
    {
        public int id { get; set; }
        public int user { get; set; }
        public int shippingProvider { get; set; }
        public int shippingAddress { get; set; }
        public float total { get; set; }
    }
}