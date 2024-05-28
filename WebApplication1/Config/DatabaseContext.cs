using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Config
{
    public class DatabaseContext : DbContext {
           public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
    }
}

