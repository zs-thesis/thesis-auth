using Thesis.Auth.Models;

namespace Thesis.Auth.Services;

/// <summary>
/// Контракт сервиса аутентификации
/// </summary>
public interface ICodeSender
{
    /// <summary>
    /// Метод отправки сообщения с кодом подтверждения
    /// </summary>
    /// <param name="ticket">Тикет</param>
    /// <returns>True, если тикет отправлен</returns>
    Task<bool> Send(AuthTicket ticket);
}