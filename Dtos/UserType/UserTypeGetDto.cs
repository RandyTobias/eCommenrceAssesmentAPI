using eCommerceAssessment.Models;

namespace eCommerceAssessment.Dtos.UserType
{
    public class UserTypeGetDto
    {
        public int id { get; set; }
        public string type { get; set; }
        public int accessLevel { get; set; }
    }
}