using SmartClinic.Core.Models;


namespace SmartClinic.Core.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}