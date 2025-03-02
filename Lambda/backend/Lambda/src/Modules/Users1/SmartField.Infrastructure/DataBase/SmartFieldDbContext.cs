using Microsoft.EntityFrameworkCore;
using Lambda.Modules.Users.Domain.Entities;

namespace Lambda.Modules.Users.Infrastructure.DataBase;

public sealed class LambdaDbContext(DbContextOptions<LambdaDbContext> options) : DbContext(options)
{
    // Пользователи
    public DbSet<UserEntity> Users { get; set; } = null!;

    // Студенты
    public DbSet<StudentEntity> Students { get; set; } = null!;

    // Преподаватели
    public DbSet<TeacherEntity> Teachers { get; set; } = null!;

    // Родители
    public DbSet<ParentEntity> Parents { get; set; } = null!;

    // Группы
    public DbSet<GroupEntity> Groups { get; set; } = null!;

    // Студенты в группах
    public DbSet<GroupStudentEntity> GroupStudents { get; set; } = null!;

    // Расписания
    public DbSet<ScheduleEntty> Schedules { get; set; } = null!;

    // Посещаемость
    public DbSet<AttendanceEntity> Attendances { get; set; } = null!;

    // Оценки
    public DbSet<GradeEntity> Grades { get; set; } = null!;

    // Уведомления
    public DbSet<NotificationEntity> Notifications { get; set; } = null!;

    // Документы
    public DbSet<DocumentEntity> Documents { get; set; } = null!;

    // Учебные материалы
    public DbSet<LearningMaterialEntity> LearningMaterials { get; set; } = null!;

    // Журналы занятий
    public DbSet<LessonLogEntity> LessonLogs { get; set; } = null!;

    // Финансовые данные
    public DbSet<FinancialDataEntity> FinancialData { get; set; } = null!;

    // Запросы на пересдачу
    public DbSet<RetakeRequestEntity> RetakeRequests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка User
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired(); // .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // Настройка Student
        modelBuilder.Entity<StudentEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ContactInfo).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.HasOne(s => s.User)
                  .WithOne(u => u.Student)
                  .HasForeignKey<StudentEntity>(s => s.UserUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(s => s.Parent)
                  .WithMany(p => p.Students)
                  .HasForeignKey(s => s.ParentUid)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // Настройка Teacher
        modelBuilder.Entity<TeacherEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ContactInfo).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.HasOne(t => t.User)
                  .WithOne(u => u.Teacher)
                  .HasForeignKey<TeacherEntity>(t => t.UserUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Parent
        modelBuilder.Entity<ParentEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ContactInfo).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(255);
        });

        // Настройка Group
        modelBuilder.Entity<GroupEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasOne(g => g.Teacher)
                  .WithMany(t => t.Groups)
                  .HasForeignKey(g => g.TeacherUid)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // Настройка GroupStudent
        modelBuilder.Entity<GroupStudentEntity>(entity =>
        {
            entity.HasKey(e => new { e.GroupUid, e.StudentUid });
            entity.HasOne(gs => gs.Group)
                  .WithMany(g => g.GroupStudents)
                  .HasForeignKey(gs => gs.GroupUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(gs => gs.Student)
                  .WithMany(s => s.GroupStudents)
                  .HasForeignKey(gs => gs.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Schedule
        modelBuilder.Entity<ScheduleEntty>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Classroom).IsRequired().HasMaxLength(50);
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();
            entity.HasOne(s => s.Group)
                  .WithMany(g => g.Schedules)
                  .HasForeignKey(s => s.GroupUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(s => s.Teacher)
                  .WithMany(t => t.Schedules)
                  .HasForeignKey(s => s.TeacherUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Attendance
        modelBuilder.Entity<AttendanceEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Status).IsRequired();
            entity.HasOne(a => a.Student)
                  .WithMany(s => s.Attendances)
                  .HasForeignKey(a => a.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(a => a.Schedule)
                  .WithMany(s => s.Attendances)
                  .HasForeignKey(a => a.ScheduleUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Grade
        modelBuilder.Entity<GradeEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.GradeValue).IsRequired();
            entity.Property(e => e.GradeDate).IsRequired();
            entity.HasOne(g => g.Student)
                  .WithMany(s => s.Grades)
                  .HasForeignKey(g => g.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(g => g.Schedule)
                  .WithMany(s => s.Grades)
                  .HasForeignKey(g => g.ScheduleUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Notification
        modelBuilder.Entity<NotificationEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Message).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired(); // s.HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.HasOne(n => n.User)
                  .WithMany(u => u.Notifications)
                  .HasForeignKey(n => n.UserUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка Document
        modelBuilder.Entity<DocumentEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.DocumentType).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DocumentData).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired(); // .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.HasOne(d => d.Student)
                  .WithMany(s => s.Documents)
                  .HasForeignKey(d => d.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка LearningMaterial
        modelBuilder.Entity<LearningMaterialEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MaterialName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.MaterialData).IsRequired();
            entity.Property(e => e.UploadDate).IsRequired();
            entity.HasOne(lm => lm.Teacher)
                  .WithMany(t => t.LearningMaterials)
                  .HasForeignKey(lm => lm.TeacherUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка LessonLog
        modelBuilder.Entity<LessonLogEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.LogDate).IsRequired();
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.HasOne(ll => ll.Schedule)
                  .WithMany(s => s.LessonLogs)
                  .HasForeignKey(ll => ll.ScheduleUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка FinancialData
        modelBuilder.Entity<FinancialDataEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.PaymentDate).IsRequired();
            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.PaymentType).IsRequired();
            entity.HasOne(fd => fd.Student)
                  .WithMany(s => s.FinancialData)
                  .HasForeignKey(fd => fd.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка RetakeRequest
        modelBuilder.Entity<RetakeRequestEntity>(entity =>
        {
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.RequestDate).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.HasOne(rr => rr.Student)
                  .WithMany(s => s.RetakeRequests)
                  .HasForeignKey(rr => rr.StudentUid)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(rr => rr.Schedule)
                  .WithMany(s => s.RetakeRequests)
                  .HasForeignKey(rr => rr.ScheduleUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка отношений между User и Student, Teacher, Parent
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasOne(u => u.Student)
                  .WithOne(s => s.User)
                  .HasForeignKey<StudentEntity>(s => s.UserUid)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(u => u.Teacher)
                  .WithOne(t => t.User)
                  .HasForeignKey<TeacherEntity>(t => t.UserUid)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(u => u.Parent)
                  .WithOne(p => p.User)
                  .HasForeignKey<ParentEntity>(p => p.Uid)
                  .OnDelete(DeleteBehavior.SetNull);
        });
    }
}