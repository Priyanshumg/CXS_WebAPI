using Application.Interfaces;
using Infrastructure.Repositories.Interface;
using Models.Entities;

namespace Application.BusinessLogics;

public class QuestionService : IQuestionService
{
    private readonly IGenericRepository<Question> _repo;

    public QuestionService(IGenericRepository<Question> repo)
    {
        _repo = repo;
    }
    
    public async Task<IEnumerable<Question>> GetAllAsync()
        => await _repo.GetAllAsync();
}