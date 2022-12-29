namespace Thesis.Auth.Models;

/// <summary>
/// Клиент системы
/// </summary>
public abstract class Client
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Роль клиента в системе
    /// </summary>
    public Roles Role { get; set; }
    
    /// <summary>
    /// Примечание
    /// </summary>
    public string? Note { get; set; }
    
    /// <summary>
    /// Токен обновления
    /// </summary>
    public string? RefreshToken { get; set; }
    
    /// <summary>
    /// Дата истечения токена обновления
    /// </summary>
    public DateTime? RefreshTokenExpires { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime Created { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Обновить токен обновления
    /// </summary>
    /// <param name="refreshToken">Токен обновления</param>
    /// <param name="refreshTokenExpires">Дата истечения токена обновления</param>
    public void UpdateRefreshToken(string refreshToken, DateTime refreshTokenExpires)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpires = refreshTokenExpires;
    }
    
    /// <summary>
    /// Удалить токен обновления
    /// </summary>
    public void ClearRefreshToken()
    {
        RefreshToken = null;
        RefreshTokenExpires = null;
    }
}
