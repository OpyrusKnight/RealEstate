using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Pages.Shared
{
    public class SingleProductModel : PageModel
    {
        [BindProperty]
        public Produit produit { get; set; } = new();
        private readonly ProduitService service;
        public SingleProductModel(ProduitService service, int id)
        {
            this.service = service;
            produit = service.GetProductById(id).Result;
        }

        public void OnGet()
        {
        }
    }
}
