using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContactos.Clases
{
    public class Contact
    {
        public string Foto { get; set; }   // Ruta de la imagen
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<string> Telefonos { get; set; } = new List<string>();
        public List<string> Emails { get; set; } = new List<string>();
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}
