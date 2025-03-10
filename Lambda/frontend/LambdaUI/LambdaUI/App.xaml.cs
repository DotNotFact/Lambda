﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using LambdaUI.ViewModels.Windows;
using LambdaUI.ViewModels.Pages;
using LambdaUI.Views.Windows;
using LambdaUI.Repositories;
using LambdaUI.Views.Pages;
using LambdaUI.Services;
using LambdaUI.Models;
using System.Windows;
using Wpf.Ui;

namespace LambdaUI;

public partial class App : Application
{
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            _ = c.SetBasePath(AppContext.BaseDirectory);
        })
        .ConfigureServices((_1, services) =>
        {
            // Регистрация репозиториев
            //_ = services.AddSingleton<IUserRepository, UserRepository>();

            //// Регистрация сервисов
            //_ = services.AddSingleton<IUserService, UserService>();
            //_ = services.AddSingleton<IPasswordHasher<User>, PasswordHasher>();

            // Репозитории
            services.AddSingleton<IRepository<User>, Repository<User>>();
            services.AddSingleton<IRepository<Student>, Repository<Student>>();
            services.AddSingleton<IRepository<Teacher>, Repository<Teacher>>();
            services.AddSingleton<IRepository<Parent>, Repository<Parent>>();
            services.AddSingleton<IRepository<Group>, Repository<Group>>();
            services.AddSingleton<IRepository<GroupStudent>, Repository<GroupStudent>>();
            services.AddSingleton<IRepository<Schedule>, Repository<Schedule>>();
            services.AddSingleton<IRepository<Attendance>, Repository<Attendance>>();
            services.AddSingleton<IRepository<Grade>, Repository<Grade>>();
            services.AddSingleton<IRepository<RetakeRequest>, Repository<RetakeRequest>>();
            services.AddSingleton<IRepository<LessonLog>, Repository<LessonLog>>();
            services.AddSingleton<IRepository<Notification>, Repository<Notification>>();
            services.AddSingleton<IRepository<Document>, Repository<Document>>();
            services.AddSingleton<IRepository<FinancialData>, Repository<FinancialData>>();

            // Сервисы
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<INotificationService, NotificationService>();
            // Другие сервисы: StudentService, GroupService, ScheduleService и т.д.

            //// Регистрация навигации
            _ = services.AddSingleton<INavigationService, NavigationService>();
            _ = services.AddSingleton<Wpf.Ui.Abstractions.INavigationViewPageProvider, PageService>();

            // Регистрация основного окна 
            _ = services.AddSingleton<IWindow, MainWindow>();

            // Регистрация ViewModels
            _ = services.AddSingleton<MainWindowViewModel>();
            _ = services.AddTransient<DashboardViewModel>();
            _ = services.AddTransient<ProfilesViewModel>();
            _ = services.AddTransient<ProfileViewModel>();
            _ = services.AddTransient<GroupsViewModel>();
            _ = services.AddTransient<ScheduleViewModel>();
            _ = services.AddTransient<AttendanceViewModel>();
            _ = services.AddTransient<GradesViewModel>();
            _ = services.AddTransient<NotificationsViewModel>();
            _ = services.AddTransient<DocumentsViewModel>();
            _ = services.AddTransient<AdministrationViewModel>();
            _ = services.AddTransient<SettingsViewModel>();
            _ = services.AddTransient<RegisterViewModel>();
            _ = services.AddTransient<LoginViewModel>();

            // Регистрация страниц
            _ = services.AddTransient<DashboardPage>();
            _ = services.AddTransient<ProfilePage>();
            _ = services.AddTransient<ProfilesPage>();
            _ = services.AddTransient<GroupsPage>();
            _ = services.AddTransient<SchedulePage>();
            _ = services.AddTransient<AttendancePage>();
            _ = services.AddTransient<GradesPage>();
            _ = services.AddTransient<NotificationsPage>();
            _ = services.AddTransient<DocumentsPage>();
            _ = services.AddTransient<AdministrationPage>();
            _ = services.AddTransient<SettingsPage>();
            _ = services.AddTransient<RegisterPage>();
            _ = services.AddTransient<LoginPage>();

            //  All other pages and view models
            // _ = services.AddTransientFromNamespace("LambdaUI.Views", LambdaUIAssembly.Asssembly);
            // _ = services.AddTransientFromNamespace(
            //     "LambdaUI.ViewModels",
            //     LambdaUIAssembly.Asssembly
            // );

            // _ = services.AddStringLocalizer(b =>
            // {
            //     b.FromResource<Translations>(new("pl-PL"));
            // });
        })
        .Build();

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private void OnStartup(object sender, StartupEventArgs e)
    {
        LocalStorageService.Initialize();

        var mainWindow = GetRequiredService<IWindow>();
        mainWindow.Show();

        _host.Start();
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private void OnExit(object sender, ExitEventArgs e)
    {
        _host.StopAsync().Wait();
        _host.Dispose();
    }

    /// <summary>
    /// Gets registered service.
    /// </summary>
    /// <typeparam name="T">Type of the service to get.</typeparam>
    /// <returns>Instance of the service or <see langword="null"/>.</returns>
    public static T GetRequiredService<T>() where T : class
    {
        return _host.Services.GetRequiredService<T>();
    }
}