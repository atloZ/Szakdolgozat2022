using Microsoft.AspNetCore.Identity;
using UPDF.Models;

namespace UPDF.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext _context)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@UPDF.com",
                Email = "superadmin@UPDF.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Asdf@1234");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }
            }
            var basicUser = new ApplicationUser
            {
                UserName = "basicadmin@UPDF.com",
                Email = "basicadmin@UPDF.com",
                FirstName = "User",
                LastName = "Basic",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != basicUser.Id))
            {
                var user = await userManager.FindByEmailAsync(basicUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(basicUser, "Asdf@1234");
                    await userManager.AddToRoleAsync(basicUser, Enums.Roles.User.ToString());
                }
            }
        }

        public static async Task SeedKorcsoport(ApplicationDbContext _context, UserManager<ApplicationUser> userManager)
        {
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Mini").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Mini",
                    Minimum = 3,
                    Maximum = 6,
                };
                _context.Add(korcsoport);
            }
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Child").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Child",
                    Minimum = 6,
                    Maximum = 10,
                };
                _context.Add(korcsoport);
            }
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Junior").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Junior",
                    Minimum = 10,
                    Maximum = 14,
                };
                _context.Add(korcsoport);
            }
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Teener").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Teener",
                    Minimum = 13,
                    Maximum = 17,
                };
                _context.Add(korcsoport);
            }
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Adult").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Adult",
                    Minimum = 18,
                    Maximum = 30,
                };
                _context.Add(korcsoport);
            }
            if (_context.Korcsoportok.Where(e => e.Megnevezes == "Senior").Count() == 0)
            {
                Korcsoport korcsoport = new Korcsoport
                {
                    Megnevezes = "Senior",
                    Minimum = 30,
                    Maximum = 50,
                };
                _context.Add(korcsoport);
            }
            await _context.SaveChangesAsync();
        }

        public static async Task SeedKategoria(ApplicationDbContext _context, UserManager<ApplicationUser> userManager)
        {
            if (_context.Kategoriak.Where(e => e.Megnevezes == "HIPHOP").Count() == 0)
            {
                Kategoria kategoria = new Kategoria
                {
                    Megnevezes = "HIPHOP",
                };
                _context.Add(kategoria);
            }
            if (_context.Kategoriak.Where(e => e.Megnevezes == "Cheerleaders").Count() == 0)
            {
                Kategoria kategoria = new Kategoria
                {
                    Megnevezes = "Cheerleaders",
                };
                _context.Add(kategoria);
            }
            await _context.SaveChangesAsync();
        }

        public static async Task SeedVersenySzam(ApplicationDbContext _context, UserManager<ApplicationUser> userManager)
        {
            if (_context.VersenySzamok.Where(e => e.Megnevezes == "solo").Count() == 0)
            {
                VersenySzam versenySzam = new VersenySzam
                {
                    Megnevezes = "solo",
                };
                _context.Add(versenySzam);
            }
            await _context.SaveChangesAsync();
        }
    }
}