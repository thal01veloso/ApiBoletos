using Microsoft.EntityFrameworkCore;
using PagamentoAPI.Models;
using System.Collections.Generic;

namespace PagamentoAPI.Context
{
    public class PagamentoContext : DbContext
    {
        public PagamentoContext(DbContextOptions<PagamentoContext> options) : base(options)
        {
        }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>()
             .HasOne(b => b.Banco)                   
             .WithMany(b => b.Boletos)               
             .HasForeignKey(b => b.BancoId);

        }
    }
}

