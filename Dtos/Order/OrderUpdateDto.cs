using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Order
{
    public class OrderUpdateDto
    {
        public int id { get; set; }
        public int transaction { get; set; }
        public int product { get; set; }
        public int quantity { get; set; }
    }
}