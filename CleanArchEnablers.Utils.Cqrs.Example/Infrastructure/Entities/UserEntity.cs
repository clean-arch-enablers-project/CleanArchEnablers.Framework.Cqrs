using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Entities;

[Table("Users")]
public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsBlocked { get; set; }
}