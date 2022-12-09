namespace Thesis.Auth.Models;

/// <summary>
/// Приложения, которое может быть авторизовано
/// </summary>
public class ApiConsumer : Entity
{
    /// <summary>
    /// Название приложения
    /// </summary>
    public string Name { get; set; } = string.Empty;
}