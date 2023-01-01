using System.ComponentModel.DataAnnotations;
using Thesis.Auth.Models;

namespace Thesis.Auth.Contracts.Users;

/// <summary>
/// Модель данных для добавления пользователя
/// </summary>
public class UserAddDto
{
	/// <summary>
	/// Телефон
	/// </summary>
	[Required(ErrorMessage = "Не указан телефон")]
	public string Phone { get; set; } = string.Empty;

	/// <summary>
	/// Электронная почта
	/// </summary>
	[Required(ErrorMessage = "Не указан адрес электронной почты")]
	public string Email { get; set; } = string.Empty;
    
	/// <summary>
	/// Роль клиента в системе
	/// </summary>
	[Required(ErrorMessage = "Не указана роль")]
	public Roles Role { get; set; }
    
	/// <summary>
	/// Примечание
	/// </summary>
	public string? Note { get; set; }
	
    /// <summary>
    /// Имя
    /// </summary>
    [Required(ErrorMessage = "Не указано имя")]
	public string Name { get; set; } = string.Empty;
	
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required(ErrorMessage = "Не указана фамилия")]
	public string Surname { get; set; } = string.Empty;
	
    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }
}