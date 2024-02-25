using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Pages.Shared
{
    public class PropertiesSearchModel : PageModel
    {
        [BindProperty]
        public List<Produit> produits { get; set; }
        readonly ProduitService service;
        public PropertiesSearchModel(ProduitService _service, string type)
        {
            service = _service;
            produits = service.GetProducts().Result.Where(p => p.type == type).ToList();
        }
        public void OnGet()
        {
        }
    }
}
