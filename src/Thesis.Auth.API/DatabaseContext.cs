using Microsoft.EntityFrameworkCore;
using Thesis.Auth.Models;

namespace Thesis.Auth;

/// <summary>
/// Контекст данных для работы с БД
/// </summary>
public sealed class DatabaseContext : DbContext
{
    #region Tables

    /// <summary>
    /// Коллекция тикетов авторизации
    /// </summary>
    public DbSet<AuthTicket> AuthTickets { get; set; } = null!;
    
    /// <summary>
    /// Коллекция клиентов
    /// </summary>
    public DbSet<Client> Clients { get; set; } = null!;

    /// <summary>
    /// Коллекция сотрудников
    /// </summary>
    public DbSet<Employee> Employees { get; set; } = null!;

    /// <summary>
    /// Коллекция приложений
    /// </summary>
    public DbSet<ApiConsumer> ApiConsumers { get; set; } = null!;

    #endregion
    
    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public DatabaseContext() { }
    
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="options">Параметры</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }

    /// <inheritdoc cref="DbContext.OnModelCreating(ModelBuilder)"/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthTicket>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Code).IsRequired();
            entity.Property(e => e.Login).IsRequired();
            entity.Property(e => e.DeviceDescription);
            entity.Property(e => e.ExpiresAt).IsRequired().HasDefaultValueSql("now()");
        });
        
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.Note);
            entity.Property(e => e.Patronymic);
            entity.Property(e => e.Created).IsRequired().HasDefaultValueSql("now()");

            entity.HasData(new Client
            {
                Id = Guid.NewGuid(),
                Phone = "79887893991",
                Email = "seljmov@list.ru",
                Name = "Загидин",
                Surname = "Селимов",
                Note = "Создан автоматически",
                Created = DateTime.UtcNow,
            });
        });
        
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.Note);
            entity.Property(e => e.Patronymic);
            entity.Property(e => e.Created).IsRequired().HasDefaultValueSql("now()");
            
            entity.HasData(new Employee
            {
                Id = Guid.NewGuid(),
                Phone = "79887893991",
                Email = "seljmov@list.ru",
                Name = "Загидин",
                Surname = "Селимов",
                Note = "Создан автоматически",
                Role = EmployeeRoles.Admin,
                Created = DateTime.UtcNow,
            });
        });
        
        modelBuilder.Entity<ApiConsumer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Note);
            entity.Property(e => e.Created).IsRequired().HasDefaultValueSql("now()");
        });
        
        base.OnModelCreating(modelBuilder);
    }
}