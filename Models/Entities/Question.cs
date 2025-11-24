using Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Question
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("url")]
    public string Url { get; set; } = string.Empty;

    [Column("difficulty")]
    public DifficultyEnum Difficulty { get; set; }

    [Column("domain")]
    public DomainEnum Domain { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<QuestionTopic> QuestionTopics { get; set; } = new List<QuestionTopic>();
    public ICollection<UserQuestion> UserQuestions { get; set; } = new List<UserQuestion>();
}