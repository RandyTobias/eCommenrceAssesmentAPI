using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class User
    {
        public int id { get; set; }
        public string fName  { get; set; } = "John";
        public string lName { get; set; } = "Doe";

        public string email { get; set; } = "john@doe.com";

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        public UserType type { get; set; }
        public int typeid { get; set; }

        public List<Address> addresses { get; set; }

        public List<Transaction> transactions { get; set; }
        
    }

    
}