using System.Linq;
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
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.Patronymic);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}