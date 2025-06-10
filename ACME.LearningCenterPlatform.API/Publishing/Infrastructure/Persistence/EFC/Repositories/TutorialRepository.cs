using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

public class TutorialRepository(AppDbContext context) : BaseRepository<Tutorial>(context), ITutorialRepository
{
    public async Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(int CategoryId)
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .Where(tutorial => tutorial.CategoryId == CategoryId)
            .ToListAsync();
    }

    public async Task<bool> ExistsTitleAsync(string title)
    {
        return await Context.Set<Tutorial>().AnyAsync(tutorial => tutorial.Title == title);
    }
    
    public new async Task<Tutorial?> FindByIdAsync(int id)
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .FirstOrDefaultAsync(tutorial => tutorial.Id == id);
    }

    public new async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .ToListAsync();
    }
}