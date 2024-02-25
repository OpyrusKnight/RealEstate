using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using RealEstate.Models;
using RealEstate.Pages;
using RealEstate.Pages.Shared;
using RealEstate.Services;
using System.Security.Claims;

namespace RealEstate.Controllers
{
    [Route("[action]")]
    public class WebController : Controller
    {
        readonly UserService userService;
        readonly ProduitService produitService;

        public WebController(UserService userService, ProduitService produitService)
        {
            this.userService = userService;
            this.produitService = produitService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(new IndexModel(produitService));
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult pay(int id)
        {
            return View(new payModel(produitService, id));
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult PropertiesSearch(string type)
        {

            return View(new PropertiesSearchModel(produitService,type));
        }

        public IActionResult RendezVous()
        {
            return View();
        }

        public IActionResult property_type()
        {
            return View();
        }

        public IActionResult SuccessPage()
        {
            return View();
        }

        public IActionResult PropertyList()
        {
            return View(new PropertyListModel(produitService));
        }

        [Route("/Product")]
        public IActionResult SingleProduct(int id)
        {
            return View(new SingleProductModel(produitService, id));
        }

        public IActionResult Dashboard()
        {
            
            return View();
        }

        public IActionResult Deconnexion()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }




        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConnexionPost()
        {
            Console.WriteLine(Request.Form.ToJson());
            try
            {
                Utilisateur user = userService.IsValidUserCredentials(Request.Form["nomLogin"].ToString(), Request.Form["passwordLogin"].ToString())!;
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.nomutilisateur),
                        new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
                        // Add other claims as needed
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        IssuedUtc = DateTimeOffset.UtcNow,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                    Console.WriteLine(User.Identity!.IsAuthenticated);
                    // Redirect to Index page or another destination
                    return Redirect("/");
                }
                else
                {
                    // Failed login, return to the same page with an error message
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return Redirect("/Connexion");
                }
            }
            catch (Exception)
            {
                return Redirect("/Connexion");
            }

        }

        public IActionResult PostRegister(string username, string password)
        {
            try
            {
                Console.WriteLine(username + " ; " + password);
                Utilisateur user = userService.IsValidUserCredentials(username, password)!;
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.nomutilisateur),
                        new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
                        // Add other claims as needed
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        IssuedUtc = DateTimeOffset.UtcNow,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                    Console.WriteLine(User.Identity!.IsAuthenticated);
                    // Redirect to Index page or another destination
                    return Redirect("/");
                }
                else
                {
                    // Failed login, return to the same page with an error message
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return Redirect("/Connexion");
                }
            }
            catch (Exception)
            {
                return Redirect("/Connexion");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPost()
        {
            try
            {
                var user = new Utilisateur()
                {
                    nom = Request.Form["nomLogup"].ToString(),
                    prenom = Request.Form["prenomLogup"].ToString(),
                    nomutilisateur = Request.Form["nomULogup"].ToString(),
                    motpasse = Request.Form["passLogup"].ToString(),
                    email = Request.Form["emailLogup"].ToString()
                };
                await userService.Enregistrement(user);
                return PostRegister(user.nomutilisateur, Request.Form["passLogup"].ToString());
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return Redirect("/Connexion");
            }
            
        }
    }
}
