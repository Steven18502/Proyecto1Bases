using System;

namespace Proyecto1Bases.Dtos
{
    public class CreateProyeccionDto
    {
        public int proyeccionid { get; set; }
        public string horario { get; set; }
        public string cine { get; set; }
        public string sala { get; set; }
    }
}