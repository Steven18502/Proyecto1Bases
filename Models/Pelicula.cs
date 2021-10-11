using System.ComponentModel.DataAnnotations;

namespace Proyecto1Bases.Models
{
    public class Pelicula
    {
        [Key]
        public string pnombre_original { get; set; }
        public string pnombre { get; set; }
        public string pduracion { get; set; }
        public string director { get; set; }
        public string clasificacion { get; set; }
        public string protagonistas { get; set; }
        public string pimagen { get; set; }
    }
}