namespace Models.Entities;

public class Topic
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<QuestionTopic> QuestionTopics { get; set; } = new List<QuestionTopic>();
}
