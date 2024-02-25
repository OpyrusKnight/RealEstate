using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using RealEstate.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Pages.Shared
{
    public class ConnexionModel : PageModel
    {
        [BindProperty]
        public string nomLogin { get; set; }
        [BindProperty]
        public string passwordLogin { get; set; }
        [BindProperty]
        public string nomLogup { get; set;}
        [BindProperty]
        public string prenomLogup { get; set;}
        [BindProperty]
        public string nomULogup { get; set;}
        [BindProperty]
        public string emailLogup { get; set;}
        [BindProperty]
        public string passLogup { get; set;}
        public void OnGet()
        {
        }
    }
}
