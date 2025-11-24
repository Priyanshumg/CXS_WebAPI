using Models.Entities;

namespace Application.Interfaces;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetAllAsync();
}