using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Application.Services;

public interface ILearningMaterialService
{
    Task CreateLearningMaterialAsync(LearningMaterialEntity material);
    Task UpdateLearningMaterialAsync(LearningMaterialEntity material);
    Task DeleteLearningMaterialAsync(int materialId);
    Task<LearningMaterialEntity> GetLearningMaterialByIdAsync(int materialId);
    Task<IEnumerable<LearningMaterialEntity>> GetAllLearningMaterialsAsync();
}
