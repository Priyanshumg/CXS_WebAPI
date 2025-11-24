using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Topic
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<QuestionTopic> QuestionTopics { get; set; } = new List<QuestionTopic>();
}