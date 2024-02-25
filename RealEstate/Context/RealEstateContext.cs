using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Context
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options){
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
    }
}
