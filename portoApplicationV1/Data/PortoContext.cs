using Microsoft.EntityFrameworkCore;
using setorPortuario.Models;

namespace portoApplicationV1.Data
{
    public class PortoContext : DbContext
    {
        public PortoContext(DbContextOptions<PortoContext> options) : base(options)
        {
        }

        public DbSet<Container> Containers { get; set; }

    }
}

