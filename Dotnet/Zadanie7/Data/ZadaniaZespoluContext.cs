using Microsoft.EntityFrameworkCore;
using ZadaniaZespolu.Models;

namespace ZadaniaZespolu.Data
{
    public class ZadaniaZespoluContext : DbContext
    {
        public ZadaniaZespoluContext(DbContextOptions<ZadaniaZespoluContext> options)
            : base(options)
        {
        }

        public DbSet<Zadanie> Zadanie { get; set; } = default!;
    }
}
