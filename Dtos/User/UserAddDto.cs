using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.User
{
    public class UserAddDto
    {
        public string fName  { get; set; } = "John";
        public string lName { get; set; } = "Doe";

        public string email { get; set; } = "john@doe.com";

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        public int type { get; set; }

    }
}