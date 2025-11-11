using Microsoft.EntityFrameworkCore;
using SmartClinic.Core.Enums;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;
namespace SmartClinic.Infrastructure.Seed
{
    public static class SmartClinicSeed
    {
        public static async Task SeedAdminAsync(ClinicDbContext db, IServiceProvider services)
        {
            if (await db.Users.AnyAsync(u => u.Role == Role.Admin)) return;

            var pwdHasher = services.GetRequiredService<IPasswordHasher>();
            var admin = new User
            {
                Email = "admin@smartclinic.local",
                FullName = "System Admin",
                Role = Role.Admin,
                PasswordHash = pwdHasher.Hash("Admin@123456!") // recommend change after first login
            };
            db.Users.Add(admin);

            // Optional sample doctor & patient for manual testing
            var docUser = new User
            {
                Email = "doc@smartclinic.local",
                FullName = "Dr. Demo",
                Role = Role.Doctor,
                PasswordHash = pwdHasher.Hash("Doctor@123!")
            };
            db.Users.Add(docUser);
            var patientUser = new User
            {
                Email = "patient@smartclinic.local",
                FullName = "Patient Demo",
                Role = Role.Patient,
                PasswordHash = pwdHasher.Hash("Patient@123!")
            };
            db.Users.Add(patientUser);

            await db.SaveChangesAsync();

            db.Doctors.Add(new Doctor
            {
                UserId = docUser.Id,
                Id = Guid.NewGuid(),
                Specialty = "General",
                Email = "doc@smartclinic.local",
                FullName = "Dr. Demo",
            });
            await db.SaveChangesAsync();

            db.Patients.Add(new Patient
            {
                UserId = patientUser.Id, //done
                Id = Guid.NewGuid(), //done
                FullName = "John Doe",//done
                Email = "john@example.com", //done
                DateOfBirth = new DateTime(1990, 1, 1) //done

            });
            var saved = await db.SaveChangesAsync(); // returns number of state entries written to DB

            var exists = await db.Patients.AnyAsync(p => p.Email == "john@example.com");
            Console.WriteLine($"Found in afgafsafsf fasdffsfsfsf sdfsdfsdsdf dfsd fasd f DB via EF: {exists}"); // expected: True
            Console.WriteLine($"SaveChanges returned: {saved}");
            foreach (var entry in db.ChangeTracker.Entries())
            {
                Console.WriteLine($"{entry.Entity.GetType().Name} - {entry.State}");
            }
        }
    }
}