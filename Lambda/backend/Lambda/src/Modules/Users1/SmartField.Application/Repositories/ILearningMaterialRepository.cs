using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Repositories;

public interface ILearningMaterialRepository
{
    Task AddLearningMaterialAsync(LearningMaterialEntity material);
    Task UpdateLearningMaterialAsync(LearningMaterialEntity material);
    Task DeleteLearningMaterialAsync(int materialId);
    Task<LearningMaterialEntity> GetLearningMaterialByIdAsync(int materialId);
    Task<IEnumerable<LearningMaterialEntity>> GetAllLearningMaterialsAsync();
}
