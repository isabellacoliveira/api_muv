using Microsoft.EntityFrameworkCore;
using portoApplicationV1.Models;
using setorPortuario.Models;

namespace portoApplicationV1.Data
{
    public class PortoContext : DbContext
    {
        public PortoContext(DbContextOptions<PortoContext> options) : base(options)
        {
        }

        public DbSet<Container> Containers { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

    }
}

