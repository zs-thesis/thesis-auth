using Microsoft.AspNetCore.Mvc;
using Thesis.Auth.Contracts.Users;
using Thesis.Auth.Models;

namespace Thesis.Auth.Controllers;

/// <summary>
/// Контроллер для работы с пользователями
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly ILogger<UsersController> _logger;

    /// <summary>
    /// Конструктор класса <see cref="UsersController" />
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    /// <param name="logger">Логгер</param>
    public UsersController(DatabaseContext context, ILogger<UsersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить список пользователей
    /// </summary>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Users.ToList());
    }
    
    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        return user is not null ? Ok(user) : NotFound("Пользователь не найден");
    }
    
    /// <summary>
    /// Добавить пользователя
    /// </summary>
    /// <param name="userAddDto">Данные пользователя</param>
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
    {
        if (_context.Users.Any(user => user.Phone == userAddDto.Phone || user.Email == userAddDto.Email))
            return BadRequest("Пользователь с таким номером телефона или почтой уже существует");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Phone = userAddDto.Phone,
            Email = userAddDto.Email,
            Role = userAddDto.Role,
            Note = userAddDto.Note,
            Created = DateTime.UtcNow,
            Name = userAddDto.Name,
            Surname = userAddDto.Surname,
            Patronymic = userAddDto.Patronymic,
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return  CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    
    /// <summary>
    /// Обновить пользователя
    /// </summary>
    /// <param name="userUpdateDto">Данные пользователя</param>
    /// <response code="200">Пользователь успешно обновлен</response>
    /// <response code="400">Пользователь с таким номером телефона или почтой уже существует</response>
    /// <response code="404">Пользователь не найден</response>
    /// <response code="500">Ошибка сервера</response>
    [HttpPatch("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
    {
        if (_context.Users.Any(user => user.Phone == userUpdateDto.Phone || user.Email == userUpdateDto.Email))
            return BadRequest("Пользователь с таким номером телефона или почтой уже существует");
        
        var user = _context.Users.FirstOrDefault(u => u.Id == userUpdateDto.Id);
        if (user is null)
            return NotFound("Пользователь не найден");
        
        user.Name = userUpdateDto.Name;
        user.Surname = userUpdateDto.Surname;
        user.Patronymic = userUpdateDto.Patronymic;
        user.Phone = userUpdateDto.Phone;
        user.Email = userUpdateDto.Email;
        user.Role = userUpdateDto.Role;
        user.Note = userUpdateDto.Note;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return Get(user.Id);
    }
}