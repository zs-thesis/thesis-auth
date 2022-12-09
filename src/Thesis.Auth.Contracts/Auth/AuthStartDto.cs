namespace Thesis.Auth.Contracts.Auth;

/// <summary>
/// Модель данных для старта авторизации
/// </summary>
public class AuthStartDto
{
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; set; } = string.Empty;
    
    /// <summary>
    /// Информация об устройстве
    /// </summary>
    public string? DeviceDescription { get; set; } = string.Empty;
}