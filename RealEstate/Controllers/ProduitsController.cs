using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Context;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public ProduitsController(RealEstateContext context)
        {
            _context = context;
        }

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Produits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduitDTO>>> GetProduits()
        {
            return await _context.Produits.Select(p => new ProduitDTO()
            {
                id = p.id,
                nom = p.nom,
                description = p.description,
                prix = p.prix,
                size = p.size,
                type = p.type,
                contrat = p.contrat,
                disponibilite = p.disponibilite,
                localisation = p.localisation,
                raison = p.raison,
                images = ConvertImageToBase64(p.images)
            }).ToListAsync();
        }

        public static string[] ConvertImageToBase64(byte[][] images)
        {
            List<string> result = new List<string>();
            foreach (var image in images)
            {
                result.Add(Convert.ToBase64String(image));
            }

            return result.ToArray();
        }

        // GET: api/Produits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(int id)
        {
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.id)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitExists(int id)
        {
            return _context.Produits.Any(e => e.id == id);
        }
    }
}
