using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaFinanceiro.Models;

namespace SistemaFinanceiro.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Requisicao> Requisicoes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}