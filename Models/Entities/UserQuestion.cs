using Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class UserQuestion
{
    [Column("uqid")]
    public int UQId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }

    [Column("status")]
    public StatusEnum Status { get; set; }

    [Column("times_solved")]
    public int TimesSolved { get; set; } = 1;

    [Column("last_solved_date")]
    public DateTime LastSolvedDate { get; set; } = DateTime.UtcNow;

    [Column("next_review_date")]
    public DateTime? NextReviewDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("favourite")]
    public bool Favourite { get; set; } = false;

    [Column("uq_practice_count")]
    public int UQPracticeCount { get; set; } = 0;

    public User? User { get; set; }
    public Question? Question { get; set; }
}