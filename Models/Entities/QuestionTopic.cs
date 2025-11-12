namespace Models.Entities;

public class QuestionTopic
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int TopicId { get; set; }
    public Question? Question { get; set; }
    public Topic? Topic { get; set; }
}