namespace Thesis.Auth.Models;

/// <summary>
/// Сотрудник
/// </summary>
public class Employee : User
{
    /// <summary>
    /// Роль сотрудника
    /// </summary>
    public EmployeeRoles Role { get; set; }
}