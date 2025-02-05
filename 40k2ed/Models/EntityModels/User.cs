namespace _40k2ed.Models.EntityModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool Confirmed { get; set; } = false;
    }
}
