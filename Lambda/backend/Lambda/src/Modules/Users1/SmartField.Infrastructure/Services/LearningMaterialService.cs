using Lambda.Modules.Users.Application.Services;
using Lambda.Modules.Users.Domain.Entities;
using Lambda.Modules.Users.Application.Repositories;

namespace Lambda.Modules.Users.Infrastructure.Services;

public class LearningMaterialService(ILearningMaterialRepository learningMaterialRepository) : ILearningMaterialService
{
    private readonly ILearningMaterialRepository _learningMaterialRepository = learningMaterialRepository;

    public async Task CreateLearningMaterialAsync(LearningMaterialEntity material)
    {
        await _learningMaterialRepository.AddLearningMaterialAsync(material);
    }

    public async Task UpdateLearningMaterialAsync(LearningMaterialEntity material)
    {
        await _learningMaterialRepository.UpdateLearningMaterialAsync(material);
    }

    public async Task DeleteLearningMaterialAsync(int materialId)
    {
        await _learningMaterialRepository.DeleteLearningMaterialAsync(materialId);
    }

    public async Task<LearningMaterialEntity> GetLearningMaterialByIdAsync(int materialId)
    {
        return await _learningMaterialRepository.GetLearningMaterialByIdAsync(materialId);
    }

    public async Task<IEnumerable<LearningMaterialEntity>> GetAllLearningMaterialsAsync()
    {
        return await _learningMaterialRepository.GetAllLearningMaterialsAsync();
    } 
}
