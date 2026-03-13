using GestaoOscAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GestaoOscAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Osc> Oscs { get; set; }
    }
}