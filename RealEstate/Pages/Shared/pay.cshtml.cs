using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Pages.Shared
{
    public class payModel : PageModel
    {
        [BindProperty]
        public Produit produit { get; set; }
        private readonly ProduitService service;

        public payModel(ProduitService _service, int id)
        {
            service = _service;
            produit = service.GetProductById(id).Result;
        }


        public void OnGet()
        {
        }
    }
}
