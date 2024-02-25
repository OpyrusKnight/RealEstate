using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RealEstate.Context;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Produit> produits { get; set; } = new List<Produit> { };
        private readonly ProduitService service;
        public IndexModel(ProduitService service)
        {
            this.service = service;
            produits = service.GetProducts().Result;
        }

        public async void OnGetAsync()
        {
            await Console.Out.WriteLineAsync("Request Done !");
            produits = await service.GetProducts();
        }
    }
}
