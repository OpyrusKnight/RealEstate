using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Pages.Shared
{
    public class PropertyListModel : PageModel
    {
        [BindProperty]
        public List<Produit> produits { get; set; } = new List<Produit> { };
        private readonly ProduitService service;
        public PropertyListModel(ProduitService service)
        {
            this.service = service;
            produits = service.GetProducts().Result;
        }
    }
}
