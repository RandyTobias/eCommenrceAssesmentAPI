using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class UserType
    {
        public int id { get; set; }
        public string type { get; set; }
        public int accessLevel { get; set; }
        public List<User> users { get; set; }
    }
}
