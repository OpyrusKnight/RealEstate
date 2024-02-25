using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    [Table("produit")]
    [PrimaryKey("id")]
    public class Produit
    {
        public int id { get; set; }
        public string nom { get; set; } = null!;
        public string description { get; set; } = null!;
        public int prix { get; set; }
        public string? type { get; set; }
        public int size { get; set; }
        public string contrat { get; set; }
        public byte[][]? images { get; set; }
        public bool disponibilite { get; set; }
        public string localisation { get; set; } = null!;
        public string? raison { get; set; }
    }

    public class ProduitDTO
    {
        public int id { get; set; }
        public string nom { get; set; } = null!;
        public string description { get; set; } = null!;
        public int prix { get; set; }
        public string? type { get; set; }
        public int size { get; set; }
        public string contrat { get; set; }
        public string[]? images { get; set; }
        public bool disponibilite { get; set; }
        public string localisation { get; set; } = null!;
        public string? raison { get; set; }
    }
}
