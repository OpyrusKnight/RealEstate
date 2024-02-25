using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    [Table("rendezvous")]
    [PrimaryKey("id")]
    public class RendezVous
    {
        public int id { get; set; }
        public string nom {  get; set; }
        public string date { get; set; }
        public string horaire { get; set; }
    }
}
