namespace Models.Entities;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RevisionCount { get; set; } = 5;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public ICollection<UserQuestion> UserQuestions { get; set; } = new List<UserQuestion>();
}
