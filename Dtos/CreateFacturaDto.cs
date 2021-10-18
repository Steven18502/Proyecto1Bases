using System;

namespace Proyecto1Bases.Dtos
{
    public class CreateFacturaDto
    {
        public int facturaId { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string Pelicula { get; set; }
        public string Proyeccion { get; set; }
        public string Sala { get; set; }
        public string Asiento { get; set; }
    }
}