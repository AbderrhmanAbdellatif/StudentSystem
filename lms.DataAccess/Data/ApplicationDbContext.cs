using lms.Models;

using Microsoft.EntityFrameworkCore;

namespace lms.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

#pragma warning disable CS8618 // Null atanamaz alan, oluşturucudan çıkış yaparken null olmayan bir değer içermelidir. Alanı null atanabilir olarak bildirmeyi düşünün.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS8618 // Null atanamaz alan, oluşturucudan çıkış yaparken null olmayan bir değer içermelidir. Alanı null atanabilir olarak bildirmeyi düşünün.
        {

        }
        public DbSet<Student> students { get; set; }

    }
}
