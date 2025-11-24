using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class User
{
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("middle_name")]
    public string? MiddleName { get; set; }   // column exists in DB

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("revision_count")]
    public int RevisionCount { get; set; } = 5;

    [Column("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public ICollection<UserQuestion> UserQuestions { get; set; } = new List<UserQuestion>();
}