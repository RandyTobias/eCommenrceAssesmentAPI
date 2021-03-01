using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.User
{
    public class UserGetDto
    {
        public int id { get; set; }
        public string fName  { get; set; } = "John";
        public string lName { get; set; } = "Doe";

        public string email { get; set; } = "john@doe.com";
        public int typeid { get; set; }
    }
}