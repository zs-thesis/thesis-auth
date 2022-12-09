using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Thesis.Auth.Options;

namespace Thesis.Auth.Controllers;

/// <summary>
/// Контроллер для работы с авторизацией
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IOptions<JwtOptions> _jwtOptions;
    
    public AuthController(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }
    
    [HttpPost("start")]
    public IActionResult AuthStart()
    {
        return Ok(_jwtOptions.Value);
    }
    
    [HttpPost("complete")]
    public IActionResult AuthComplete()
    {
        return Ok(_jwtOptions.Value);
    }
}