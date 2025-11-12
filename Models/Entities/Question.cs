using Enums;

namespace Models.Entities;

public class Question
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DifficultyEnum Difficulty { get; set; }
    public DomainEnum Domain { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<QuestionTopic> QuestionTopics { get; set; } = new List<QuestionTopic>();
    public ICollection<UserQuestion> UserQuestions { get; set; } = new List<UserQuestion>();
}
