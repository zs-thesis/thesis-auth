using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Thesis.Services.Common.Options;

namespace Thesis.Auth.Helpers;

/// <summary>
/// Класс для генерации Jwt-токена
/// </summary>
public class JwtCreator
{
    private readonly IOptions<JwtOptions> _jwtOptions;

    /// <summary>
    /// Конструктор класса <see cref="JwtCreator"/>
    /// </summary>
    /// <param name="jwtOptions"></param>
    public JwtCreator(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }
    
    /// <summary>
    /// Создать Jwt-токен
    /// </summary>
    /// <param name="id">Идентификатор потребителя</param>
    /// <param name="login">Логин (наименование) потребителя</param>
    /// <param name="minutesValid">Время действия токена</param>
    /// <returns></returns>
    public string Create(Guid id, string login, int minutesValid)
    {
        var subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, id.ToString()),
            new Claim(ClaimTypes.GivenName, login)
        });
    
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Value.Issuer,
            Audience = $"*.{_jwtOptions.Value.Issuer}",
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(minutesValid),
            Subject = subject,
            SigningCredentials = new SigningCredentials(_jwtOptions.Value.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        };
    
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}