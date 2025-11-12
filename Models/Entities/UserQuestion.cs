using Enums;

namespace Models.Entities;
public class UserQuestion
{
    public int UQId { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public StatusEnum Status { get; set; }
    public int TimesSolved { get; set; } = 1;
    public DateTime LastSolvedDate { get; set; } = DateTime.UtcNow;
    public DateTime? NextReviewDate { get; set; }
    public string? Notes { get; set; }
    public bool Favourite { get; set; } = false;
    public int UQPracticeCount { get; set; } = 0;

    public User? User { get; set; }
    public Question? Question { get; set; }
}