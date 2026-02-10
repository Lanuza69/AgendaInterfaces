using AgendaContactos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContactos.Componentes
{
    public partial class UCContacts : UserControl
    {
        private List<Contact> listContacts;
        public UCContacts()
        {
            InitializeComponent();
            //Recogemos los contactos del JSON
            listContacts = JSONManager.Load();
            listContacts = listContacts
                .OrderBy(c => c.NombreCompleto, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
            //Cargamos la lista de contactos y la mostramos
            ucContactList.LoadList(listContacts);
            ShowList();

            ucContactList.OnSelected += OpenExpanded;
            ucContactList.OnNew += OpenNew;
            ucExpandedContact.OnBack += BackList;
            ucExpandedContact.OnSave += SavedContact;
            ucExpandedContact.OnDelete += DeleteContact;

            
        }
        private void ShowList()
        {
            //Se muestra la lista y se esconde el Contacto Expandido
            ucContactList.Visible = true;
            ucExpandedContact.Visible = false;
            
        }

        private void OpenExpanded(Object sender,Contact c)
        {
            //Se abre el Contacto con info extensa a la vez que se carga la info en este
            ucExpandedContact.Load(c, read: true);
            ucContactList.Visible = false;
            ucExpandedContact.Visible = true;
        }
        private void OpenNew(Object sender, EventArgs e)
        {
            //Se genera un nuevo contacto que se añade a la lista
            var nuevo = new Contact();
            listContacts.Add(nuevo);
            //refrescar
            ucContactList.Refresh(listContacts);
            //Abrimos el contacto listo para editar
            ucExpandedContact.Load(nuevo, read: false);
            ucContactList.Visible = false;
            ucExpandedContact.Visible = true;
        }

        private void BackList(object sender, EventArgs e)
        {

            // limpiar contactos vacíos
            listContacts = listContacts
                .Where(c => !ContactIsEmpty(c))
                .ToList();

            // ordenar
            listContacts = listContacts
                .OrderBy(c => c.NombreCompleto, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            //refrescar
            ucContactList.Refresh(listContacts);

            //persistir en JSON
            GuardarContactos();

            //cambiar paneles
            ShowList();
        }

        private void SavedContact(object sender, Contact c)
        {
            //Actualizacion de JSON con la lista actual
            JSONManager.Save(listContacts);
            ShowList();
        }
        private void DeleteContact(object sender, Contact c)
        {
            //eliminar de la lista
            listContacts.Remove(c);

            // ordenar
            listContacts = listContacts
                .OrderBy(c => c.NombreCompleto, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            // refrescar UI
            ucContactList.Refresh(listContacts);

            // persistir en JSON
            GuardarContactos();

            // cambiar paneles
            ShowList();
            
        }

        public void GuardarContactos() //USAR EN UN OnFormClosing
        {
            //Nos aseguramos bien de volcar los datos en el JSON
            string json = JsonSerializer.Serialize(listContacts, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText("contactos.json", json);
        }
        private bool ContactIsEmpty(Contact c)
        {
            //Revisión de si un contacto esta vacio
            return string.IsNullOrWhiteSpace(c.Nombre)
                && string.IsNullOrWhiteSpace(c.Apellidos)
                && string.IsNullOrWhiteSpace(c.Empresa)
                && string.IsNullOrWhiteSpace(c.Direccion)
                && (c.Telefonos == null || c.Telefonos.Count == 0)
                && (c.Emails == null || c.Emails.Count == 0)
                && string.IsNullOrWhiteSpace(c.Dia)
                && string.IsNullOrWhiteSpace(c.Mes)
                && string.IsNullOrWhiteSpace(c.Anio)
                && string.IsNullOrWhiteSpace(c.Foto);
        }
        public void LimpiarFotosNoUsadas() //USAR EN UN OnFormClosing
        {
            //Crear ruta
            string carpeta = Path.Combine(Application.StartupPath, "FotosContacto");
            if (!Directory.Exists(carpeta))
                return;

            // Crear HashSet de todas las fotos usadas
            var fotosUsadas = new HashSet<string>(
                listContacts
                    .Where(c => !string.IsNullOrWhiteSpace(c.Foto))
                    .Select(c => Path.GetFullPath(c.Foto)),
                StringComparer.OrdinalIgnoreCase
            );

            // Iterar todos los archivos de la carpeta
            foreach (var file in Directory.GetFiles(carpeta))
            {
                string rutaCompleta = Path.GetFullPath(file);

                // Si no esta en la lista de contactos → eliminar
                if (!fotosUsadas.Contains(rutaCompleta))
                {
                    try
                    {
                        File.Delete(rutaCompleta);
                    }
                    catch (Exception ex)
                    {
                        // log por si falla
                        Console.WriteLine($"No se pudo eliminar {file}: {ex.Message}");
                    }
                }
            }
        }


    }
}
