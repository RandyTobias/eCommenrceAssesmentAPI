namespace eCommerceAssessment.Dtos.User
{
    public class UserRegisterDto
    {
        public string fName  { get; set; } = "John";
        public string lName { get; set; } = "Doe";
        public string email { get; set; }
        public string password { get; set; }
        public int type { get; set; } = 3;
    }
}