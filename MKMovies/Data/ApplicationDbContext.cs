using Microsoft.EntityFrameworkCore;
using MKMovies.Models;

namespace MKMovies.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        DbSet<User> Users { get; set; }
    }
}
