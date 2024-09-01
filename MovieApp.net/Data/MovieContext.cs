using Microsoft.EntityFrameworkCore;
using MovieApp.net.Entity;

namespace MovieApp.net.Data
{   //ilgili nesneleri sınıfları buraya context olarak eklememiz gerekiyor
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }

        //aşağıda movie ve genre tablosunun özellikleri fluent api ile oluşturulmuştur.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Genre>()
                .Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Genre>()
                .Property(b => b.Name).HasMaxLength(50);
        }
    }
}
/*veritabanı güncellerken yapmamız gerekenler (powershellde veya buranın terminalinde yazabiliriz.);
1-) bir şey ekleyeceksek "dotnet ef migrations add AddTableDirector"(AddTableDirector migrationunu ekle ankamına gelir
- silme istersekte aynı şekilde"dotnet ef migrations add AddTableDirector")
2-) "dotnet ef database update" diyip güncellemek gerekir*/