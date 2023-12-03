using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Student> Students { get; set; }    
    }
}
