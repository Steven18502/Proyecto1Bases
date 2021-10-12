using System.ComponentModel.DataAnnotations;
using System;

namespace Proyecto1Bases.Models
{
    public class Sucursal
    {
        [Key]
        public string nombre_cine  { get; set; }    
        public string ubicacion  { get; set; }
        public int cantidad_salas { get; set; }

    }
}