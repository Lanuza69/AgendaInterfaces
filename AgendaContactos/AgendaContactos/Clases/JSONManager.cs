using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgendaContactos.Clases
{
    internal class JSONManager
    {
        private static string rutaJson = "contactos.json";

        public static List<Contact> Load()
        {
            if (!File.Exists(rutaJson))
                return new List<Contact>();

            string json = File.ReadAllText(rutaJson);
            var list = JsonSerializer.Deserialize<List<Contact>>(json);
            return list.OrderBy(c => c.Apellidos).ThenBy(c => c.Nombre).ToList();
        }

        public static void Save(List<Contact> lista)
        {
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaJson, json);
        }
    }
}
