using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.User
{
    public class UserUpdateDto
    {
        public int id { get; set; }
        public string fName  { get; set; } = "John";
        public string lName { get; set; } = "Doe";
        public string email { get; set; }
        public string password { get; set; }
        public int type { get; set; }

    }
}