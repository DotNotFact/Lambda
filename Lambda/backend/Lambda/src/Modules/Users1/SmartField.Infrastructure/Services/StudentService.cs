using Lambda.Modules.Users.Application.Repositories;
using Lambda.Modules.Users.Domain.Entities.Enums;
using Lambda.Modules.Users.Application.Services;
using Microsoft.AspNetCore.Identity;
using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Infrastructure.Services;

// StudentService.cs
public class StudentService(IStudentRepository studentRepository, IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher = passwordHasher;

    public async Task CreateStudentAsync(StudentEntity student, string username, string email, string password)
    {
        // Создание пользователя
        var user = new UserEntity
        {
            Uid = Guid.NewGuid(),
            Username = username,
            Email = email,
            Role = Role.Student,
            CreatedAt = DateTime.UtcNow
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, password);
        await _userRepository.AddUserAsync(user);

        // Создание студента
        student.Uid = Guid.NewGuid();
        student.UserUid = user.Uid;
        await _studentRepository.AddStudentAsync(student);
    }

    public async Task UpdateStudentAsync(StudentEntity student)
    {
        await _studentRepository.UpdateStudentAsync(student);
    }

    public async Task DeleteStudentAsync(Guid studentUid)
    {
        var student = await _studentRepository.GetStudentByUidAsync(studentUid);
       
        if (student != null)
        {
            await _studentRepository.DeleteStudentAsync(student.Uid);
        }
    }

    public async Task<StudentEntity> GetStudentByUidAsync(Guid studentUid)
    {
        return await _studentRepository.GetStudentByUidAsync(studentUid);
    }

    public async Task<IEnumerable<StudentEntity>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllStudentsAsync();
    } 
}
