using LeilaoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Data
{
    public class LeilaoContext : DbContext
    {
        public LeilaoContext(DbContextOptions<LeilaoContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Lance> Lances { get; set; }

        /**
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Lance>().HasKey( x => new { x.Id_Lance});
        }**/

    }
}