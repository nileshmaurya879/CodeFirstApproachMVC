using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CodeFirstApproachMVC.Models
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get;set; }
    }
}
