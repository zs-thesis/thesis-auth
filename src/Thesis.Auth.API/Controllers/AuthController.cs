using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Thesis.Auth.Contracts;
using Thesis.Auth.Contracts.Auth;
using Thesis.Auth.Helpers;
using Thesis.Auth.Models;
using Thesis.Auth.Services;
using Thesis.Services.Common.Options;

namespace Thesis.Auth.Controllers;

/// <summary>
/// Контроллер для работы с авторизацией
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IOptions<JwtOptions> _jwtOptions;
    private readonly JwtCreator _jwtCreator;
    private readonly ILogger<AuthController> _logger;

    /// <summary>
    /// Конструктор класса <see cref="AuthController"/>
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    /// <param name="jwtOptions">Настройки Jwt-токена</param>
    /// <param name="jwtCreator">Класс-создатель Jwt-токена</param>
    /// <param name="logger">Логгер</param>
    public AuthController(DatabaseContext context, IOptions<JwtOptions> jwtOptions, JwtCreator jwtCreator, ILogger<AuthController> logger)
    {
        _context = context;
        _jwtOptions = jwtOptions;
        _jwtCreator = jwtCreator;
        _logger = logger;
    }

    /// <summary>
    /// Начинает процесс авторизации. Отправляет секретный код по SMS. Возвращает тикет для завершения авторизации.
    /// </summary>
    /// <param name="startDto">Данные для старта авторизации</param>
    /// <param name="codeSender">Сервис отправки сообщений</param>
    /// <response code="200">Авторизация успешно начата</response>
    /// <response code="400">Передан некорректный логин</response>
    /// <response code="404">Пользователь c таким логином не найден</response>
    /// <response code="500">Ошибка сервера</response>
    [HttpPost("start")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthStartDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Client))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AuthStart([FromBody] AuthStartDto startDto, [FromServices] ICodeSender codeSender)
    {
        if (string.IsNullOrEmpty(startDto.Login))
            return BadRequest();

        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Phone == startDto.Login || c.Email == startDto.Login);
        if (client == null)
            return NotFound();
        
        var ticket = AuthTicket.Create(startDto.Login);
        try
        {
            await codeSender.Send(ticket);
            await _context.AuthTickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return Ok(new TicketDto { Ticket = ticket.Id.ToString() });
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw;
        }
    }
    
    /// <summary>
    /// Завершает процесс авторизации. Проверяет тикет и секретный код. Возвращает токен доступа и обновления.
    /// </summary>
    /// <param name="completeDto">Данные для завершения авторизации</param>
    /// <response code="200">Авторизация успешно завершена</response>
    /// <response code="400">Передан некорректный тикет или секретный код</response>
    /// <response code="404">Не найден тикет или клиент</response>
    /// <response code="500">Ошибка сервера</response>
    [HttpPost("complete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokensDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthCompleteDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult AuthComplete([FromBody] AuthCompleteDto completeDto)
    {
        if (string.IsNullOrEmpty(completeDto.Ticket) ||
            !Guid.TryParse(completeDto.Ticket, out var ticketId) ||
            string.IsNullOrEmpty(completeDto.Code))
            return BadRequest();

        var ticket = _context.AuthTickets.FirstOrDefault(t => t.Id == ticketId);
        if (ticket == null || ticket.Code != completeDto.Code)
            return NotFound(completeDto.Ticket);

        var client = _context.Clients.FirstOrDefault(c => c.Phone == ticket.Login || c.Email == ticket.Login);
        if (client == null)
            return NotFound(ticket.Login);

        var tokens = new TokensDto
        {
            AccessToken = _jwtCreator.CreateAccessToken(client.Id, client.Phone, _jwtOptions.Value.AccessTokenLifetime),
            RefreshToken = _jwtCreator.CreateRefreshToken(),
        };
        return Ok(tokens);
    }
}