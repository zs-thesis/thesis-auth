namespace Thesis.Auth.Contracts.Auth;

/// <summary>
/// Тикет для авторизации
/// </summary>
public class TicketDto
{
    /// <summary>
    /// Тикет
    /// </summary>
    public string Ticket { get; set; } = string.Empty;
}