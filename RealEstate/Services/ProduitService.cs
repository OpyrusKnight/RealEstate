using Microsoft.EntityFrameworkCore;
using RealEstate.Context;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class ProduitService
    {
        readonly RealEstateContext context;
        public ProduitService(RealEstateContext context)
        {
            this.context = context;
        }

        public async Task<List<Produit>> GetProducts()
        {
            var products = await context.Produits.ToListAsync();
            return products;
        }

        public async Task<Produit> GetProductById(int id)
        {
            try
            {
                var product = await context.Produits.FirstOrDefaultAsync(p => p.id == id);
                    return product;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<List<Produit>> GetProductsByContract(string contract)
        {
            try
            {
                var products = await context.Produits.Where(p => p.contrat == contract).ToListAsync();
                return products;
            }
            catch (Exception)
            {
                return new List<Produit>();
            }
        }
    }
}
