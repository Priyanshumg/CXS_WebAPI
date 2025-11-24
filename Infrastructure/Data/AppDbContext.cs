using Enums;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Question> Question => Set<Question>();
    public DbSet<Topic> Topics => Set<Topic>(); 
    public DbSet<QuestionTopic> QuestionTopics => Set<QuestionTopic>();
    public DbSet<UserQuestion> UserQuestions => Set<UserQuestion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- ENUMS ---
        modelBuilder.HasPostgresEnum<DifficultyEnum>();
        modelBuilder.HasPostgresEnum<DomainEnum>();
        modelBuilder.HasPostgresEnum<StatusEnum>();

        // --- USER QUESTIONS ---
        modelBuilder.Entity<UserQuestion>()
            .ToTable("user_questions")
            .HasKey(uq => uq.UQId);

        modelBuilder.Entity<UserQuestion>()
            .HasIndex(uq => new { uq.UserId, uq.QuestionId })
            .IsUnique();

        modelBuilder.Entity<UserQuestion>()
            .HasOne(uq => uq.User)
            .WithMany(u => u.UserQuestions)
            .HasForeignKey(uq => uq.UserId);

        modelBuilder.Entity<UserQuestion>()
            .HasOne(uq => uq.Question)
            .WithMany(q => q.UserQuestions)
            .HasForeignKey(uq => uq.QuestionId);

        // --- QUESTION TOPICS ---
        modelBuilder.Entity<QuestionTopic>()
            .ToTable("question_topics")
            .HasIndex(qt => new { qt.QuestionId, qt.TopicId })
            .IsUnique();

        modelBuilder.Entity<QuestionTopic>()
            .HasOne(qt => qt.Question)
            .WithMany(q => q.QuestionTopics)
            .HasForeignKey(qt => qt.QuestionId);

        modelBuilder.Entity<QuestionTopic>()
            .HasOne(qt => qt.Topic)
            .WithMany(t => t.QuestionTopics)
            .HasForeignKey(qt => qt.TopicId);

        // --- QUESTIONS ---
        modelBuilder.Entity<Question>()
            .ToTable("questions")
            .HasIndex(q => new { q.Title, q.Domain })
            .IsUnique();

        // --- USERS ---
        modelBuilder.Entity<User>()
            .ToTable("users")
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // --- TOPICS ---
        modelBuilder.Entity<Topic>()
            .ToTable("topics");

        base.OnModelCreating(modelBuilder);
    }
}
