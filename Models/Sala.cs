using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1Bases.Models
{
    public class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string sid { get; set; }
        public string nombre_sucursal  { get; set; }
        public int cantidad_columnas { get; set; }
        public int cantidad_filas  { get; set; }
        public int scapacidad { get; set; }       
    }
}