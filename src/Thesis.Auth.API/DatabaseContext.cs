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
    /// Коллекция пользователей
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Коллекция компаний-партнеров
    /// </summary>
    public DbSet<Company> Companies { get; set; } = null!;
    
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
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.Note);
            entity.Property(e => e.RefreshToken);
            entity.Property(e => e.RefreshTokenExpires);
            entity.Property(e => e.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.Patronymic);

            entity.HasData(new User
            {
                Id = Guid.NewGuid(),
                Role = Roles.Administator,
                Note = "Создано автоматически",
                Phone = "79887893991",
                Email = "seljmov@list.ru",
                Name = "Загидин",
                Surname = "Селимов",
                Created = DateTime.UtcNow,
            });
        });
        
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ClientId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Inn).IsRequired();
            entity.Property(e => e.LegalAddress).IsRequired();
            entity.Property(e => e.ActualAddress).IsRequired();
            entity.Property(e => e.Site);
            entity.Property(e => e.Director).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}