using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using biblioteca_digital_Infrastructure.Mappings;
using biblioteca_digital_DOMAIN.Entities;

namespace biblioteca_digital_Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LivroMap());
        }
    }


}
