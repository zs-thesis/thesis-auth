using MailKit.Net.Smtp;
using MimeKit;
using Thesis.Auth.Models;
using Thesis.Auth.Options;

namespace Thesis.Auth.Services;

/// <summary>
/// Сервис отправки кода подтверждения на почту
/// </summary>
public class EmailSenderService : ICodeSender
{
    private readonly SmtpClientOptions _options;

    /// <summary>
    /// Конструктор сервиса отправки кода подтверждения на почту
    /// </summary>
    /// <param name="options">Параметры Smtp-клиента</param>
    public EmailSenderService(SmtpClientOptions options)
    {
        _options = options;
    }
    
    /// <inheritdoc cref="ICodeSender.Send(AuthTicket)" />
    public async Task<bool> Send(AuthTicket ticket)
    {
        var emailMessage = new MimeMessage();
        
        emailMessage.From.Add(new MailboxAddress("Thesis Authorization", _options.Email));
        emailMessage.To.Add(new MailboxAddress("", ticket.Login));
        emailMessage.Subject = "Authorization code";
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = "Your authorization code: " + ticket.Code
        };

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_options.Host, _options.Port, _options.EnableSsl);
            await client.AuthenticateAsync(_options.Email, _options.Password);
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
}