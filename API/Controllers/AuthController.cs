using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartClinic.Core.Enums;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;
using SmartClinic.Infrastructure;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ClinicDbContext _db;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtService _jwt;

    public AuthController(ClinicDbContext db, IPasswordHasher hasher, IJwtService jwt)
    {
        _db = db; _hasher = hasher; _jwt = jwt;
    }

    [HttpPost("register/patient")]
    public async Task<IActionResult> RegisterPatient([FromBody] RegisterDto dto)
    {
        if (await _db.Users.AnyAsync(u => u.Email == dto.Email)) return Conflict("Email taken");
        if (!PasswordPolicyValid(dto.Password)) return BadRequest("Weak password");

        var user = new User
        {
            Email = dto.Email,
            FullName = dto.FullName,
            Role = Role.Patient,
            PasswordHash = _hasher.Hash(dto.Password)
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        _db.Patients.Add(new Patient
        {
            UserId = user.Id,
            DateOfBirth = dto.DateOfBirth,
            Email = dto.Email,
            FullName = dto.FullName,
        });
        await _db.SaveChangesAsync();

        return Ok(new { message = "Patient registered" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !_hasher.Verify(user.PasswordHash, dto.Password)) return Unauthorized();

        var token = _jwt.GenerateToken(user);
        return Ok(new { token, role = user.Role.ToString(), userId = user.Id });
    }

    private bool PasswordPolicyValid(string p)
    {
        if (p.Length < 8) return false;
        if (!p.Any(char.IsUpper)) return false;
        if (!p.Any(char.IsLower)) return false;
        if (!p.Any(char.IsDigit)) return false;
        if (!p.Any(ch => "!@#$%^&*()_-+={}[]:;\"'<>,.?/\\|".Contains(ch))) return false;
        return true;
    }
}

public record RegisterDto(string Email, string FullName, string Password, DateTime DateOfBirth, Role Role);
public record LoginDto(string Email, string Password);
