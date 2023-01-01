namespace Thesis.Auth.Contracts.Auth;

/// <summary>
/// Тикет для авторизации
/// </summary>
public class TicketDto
{
    /// <summary>
    /// Наименование пользователя
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Тикет
    /// </summary>
    public string Ticket { get; set; } = string.Empty;
}