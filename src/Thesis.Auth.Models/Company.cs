namespace Thesis.Auth.Models;

/// <summary>
/// Компания-партнер
/// </summary>
public class Company
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идеентификатор клиента-компании
    /// </summary>
    public Guid ClientId { get; set; }

    /// <summary>
    /// Название компании
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// ИНН
    /// </summary>
    public string Inn { get; set; } = string.Empty;

    /// <summary>
    /// Юридический адрес
    /// </summary>
    public string LegalAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// Фактический адрес
    /// </summary>
    public string ActualAddress { get; set; } = string.Empty;

    /// <summary>
    /// Сайт
    /// </summary>
    public string? Site { get; set; }
    
    /// <summary>
    /// Руководитель
    /// </summary>
    public string Director { get; set; } = string.Empty;
}