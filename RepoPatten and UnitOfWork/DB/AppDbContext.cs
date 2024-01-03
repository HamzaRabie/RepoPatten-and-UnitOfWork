using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using RepoPatten_and_UnitOfWork.Model;

namespace RepoPatten_and_UnitOfWork.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
    }
}
