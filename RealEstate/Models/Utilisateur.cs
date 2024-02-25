using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    [Table("utilisateur")]
    [PrimaryKey("id")]
    public class Utilisateur
    {
        public int id {  get; set; }
        public string nom { get; set; }
        public string? prenom { get; set; }
        public string nomutilisateur { get; set; }
        public string motpasse { get; set; }
        public string? numtelephone { get; set; }
        public string? email { get; set; }
    }
}
