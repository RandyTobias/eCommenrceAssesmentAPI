using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Order
{
    public class OrderGetDto
    {
        public int id { get; set; }
        public int transactionid { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }
    }
}