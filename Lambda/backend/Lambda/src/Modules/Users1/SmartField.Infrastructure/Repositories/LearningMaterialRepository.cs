using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class LearningMaterialRepository(LambdaDbContext context) : ILearningMaterialRepository
{
    private readonly LambdaDbContext _context = context;

    public async Task AddLearningMaterialAsync(LearningMaterialEntity material)
    {
        await _context.LearningMaterials.AddAsync(material);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLearningMaterialAsync(LearningMaterialEntity material)
    {
        _context.LearningMaterials.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLearningMaterialAsync(int materialId)
    {
        var material = await _context.LearningMaterials.FindAsync(materialId);
        if (material != null)
        {
            _context.LearningMaterials.Remove(material);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<LearningMaterialEntity> GetLearningMaterialByIdAsync(int materialId)
    {
        return await _context.LearningMaterials.FindAsync(materialId);
    }

    public async Task<IEnumerable<LearningMaterialEntity>> GetAllLearningMaterialsAsync()
    {
        return await _context.LearningMaterials.ToListAsync();
    } 
}
