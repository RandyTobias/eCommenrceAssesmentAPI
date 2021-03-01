using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.ShippingProvider
{
    public class ShippingProviderAddDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public float rateFlat { get; set; }
    }
}