namespace TheUniversity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public Role Roles { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
