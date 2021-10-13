using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1Bases.Models
{
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string nombre_cine  { get; set; }    
        public string ubicacion  { get; set; }
        public int cantidad_salas { get; set; }

    }
}