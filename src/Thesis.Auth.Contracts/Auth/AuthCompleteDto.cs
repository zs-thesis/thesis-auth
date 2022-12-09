namespace Thesis.Auth.Contracts.Auth;

/// <summary>
/// Модель данных для завершения регистрации
/// </summary>
public class AuthCompleteDto
{
    /// <summary>
    /// Тикет
    /// </summary>
    public string Ticket { get; set; } = string.Empty;
    
    /// <summary>
    /// Код подтверждения
    /// </summary>
    public string Code { get; set; } = string.Empty;
}