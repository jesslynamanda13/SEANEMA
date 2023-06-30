using Microsoft.EntityFrameworkCore;
using SEANEMAAPI.Model;

namespace SEANEMAAPI
{
    public class seanemaDBContext : DbContext
    {
        public DbSet<User> MsUser { get; set; }

        public seanemaDBContext(DbContextOptions<seanemaDBContext> options) : base(options) { }
    }
}
