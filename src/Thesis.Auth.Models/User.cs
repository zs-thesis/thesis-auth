namespace Thesis.Auth.Models;

/// <summary>
/// Модель пользователя
/// </summary>
public abstract class User : Entity
{
	/// <summary>
	/// Номер телефона
	/// </summary>
	public string Phone { get; set; } = string.Empty;

	/// <summary>
	/// Адрес электронной почты
	/// </summary>
	public string Email { get; set; } = string.Empty;
	
	/// <summary>
	/// Имя
	/// </summary>
	public string Name { get; set; } = string.Empty;
	
	/// <summary>
	/// Фамилия
	/// </summary>
	public string Surname { get; set; } = string.Empty;
	
	/// <summary>
	/// Отчество
	/// </summary>
	public string? Patronymic { get; set; }
}