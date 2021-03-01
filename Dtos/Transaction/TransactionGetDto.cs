using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Transaction
{
    public class TransactionGetDto
    {
        public int id { get; set; }
        public int user { get; set; }
        public int shippingProviderid { get; set; }
        public int shippingAddressid { get; set; }
        public float total { get; set; }
    }
}