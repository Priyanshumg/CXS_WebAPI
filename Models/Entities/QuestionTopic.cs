using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class QuestionTopic
{
    [Column("id")]
    public int Id { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }

    [Column("topic_id")]
    public int TopicId { get; set; }

    public Question? Question { get; set; }
    public Topic? Topic { get; set; }
}