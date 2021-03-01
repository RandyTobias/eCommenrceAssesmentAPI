using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Product
{
    public class ProductGetDto
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
    }
}