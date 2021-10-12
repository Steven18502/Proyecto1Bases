using System;

namespace Proyecto1Bases.Dtos
{
    public class CreateSucursalDto
    {
        public string nombre_cine  { get; set; }    
        public string ubicacion  { get; set; }
        public int cantidad_salas { get; set; }
    }
}