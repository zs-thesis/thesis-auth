namespace Thesis.Auth.Models;

/// <summary>
/// Модель пользователя
/// </summary>
public class User : Client
{
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