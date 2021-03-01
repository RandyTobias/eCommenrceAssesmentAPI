using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.Address
{
    public class AddressUpdateDto
    {
        public int id { get; set; }
        public string street1 { get; set; } = "";
        public string street2 { get; set; } = "";
        public string city { get; set; } = "";
        public int postalCode { get; set; }
        public int postalCodeExt { get; set; }
        public bool isPrimary { get; set; } = false;
        public int user { get; set; }
    }
}