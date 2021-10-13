using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1Bases.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ccedula { get; set; }
        public string cusuario { get; set; }
        public string cconstrasenia { get; set; }
        public string cnombre_completo { get; set; }
        public int cedad { get; set; }
        public DateTime cfecha_nacimiento { get; set; }
        public string ctelefono { get; set; }
    }
}