using System;

namespace Proyecto1Bases.Dtos
{
    public class UpdateEmpleadoDto
    {
        public string eusuario { get; set; }
        public string econstrasenia { get; set; }
        public string enombre_completo { get; set; }
        public int eedad { get; set; }
        public DateTime efecha_nacimiento { get; set; }
        public string etelefono { get; set; }
        public string rol { get; set; }

    }
}