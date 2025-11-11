using SmartClinic.Core.Enums;

namespace SmartClinic.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}