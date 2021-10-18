using System;

namespace Proyecto1Bases.Dtos
{
    public class CreateProyeccionDto
    {
        public string proyeccionId { get; set; }
        public string horario { get; set; }
        public string cine { get; set; }
        public string sala { get; set; }
    }
}