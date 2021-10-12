using System;

namespace Proyecto1Bases.Dtos
{
    public class UpdateClienteDto
    {
        public string cusuario { get; set; }
        public string cconstrasenia { get; set; }
        public string cnombre_completo { get; set; }
        public int cedad { get; set; }
        public DateTime cfecha_nacimiento { get; set; }
        public string ctelefono { get; set; }
    }
}