namespace NewsPortal.WebAppApi.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; } 
    }
}
