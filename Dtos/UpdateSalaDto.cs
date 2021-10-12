using System;

namespace Proyecto1Bases.Dtos
{
    public class UpdateSalaDto
    {
        public string nombre_sucursal  { get; set; }
        public int cantidad_columnas { get; set; }
        public int cantidad_filas  { get; set; }
        public int scapacidad { get; set; } 
    }
}