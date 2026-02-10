using AgendaContactos.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContactos.Componentes
{
    public partial class UCContactList : UserControl
    {
        public event EventHandler<Contact> OnSelected;
        public event EventHandler OnNew;
        private List<Contact> list;
        public UCContactList()
        {
            InitializeComponent();
            btnNew.Click += (s, e) => OnNew?.Invoke(this, EventArgs.Empty);//Crear un nuevo contacto

            BuildAlphabet();//Generación de botones con Scroll
        }
        public void LoadList(List<Contact> contactos)
        {
            //Cargamos los contactos poniendolos en colapsados
            list = contactos;
            panelContacts.Controls.Clear();

            foreach (var c in list)
            {
                var colapsado = new UCCollapsedContact();
                colapsado.LoadContact(c);
                colapsado.OnClickExpand += (s, e) => OnSelected?.Invoke(this, c);
                panelContacts.Controls.Add(colapsado);
            }
        }

        public void Refresh(List<Contact> contacts)
        {
            //Refresca la info que se ve
            LoadList(contacts);
        }

        private void BuildAlphabet()
        {
            //Generacion de botones con Scroll
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letra in abecedario)
            {
                var btn = new Button();
                btn.Width = 24;
                btn.Height = 24;
                btn.Margin = new Padding(1);
                btn.Text = letra.ToString();
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btn.ForeColor = Color.FromArgb(73,37,10) ;
                btn.BackColor = Color.FromArgb(205, 177, 171);
                btn.Click += (s, e) => ScrollToLetter(letra);
                panelABC.Controls.Add(btn);
            }
        }
        private void ScrollToLetter(char letra)
        {
            //Scroll Interactivo para los botones
            letra = char.ToUpper(letra);

            foreach (Control ctrl in panelContacts.Controls)
            {
                if (ctrl is UCCollapsedContact collapsed && collapsed.contact != null)
                {
                    var nombre = collapsed.contact.Nombre;
                    //Scrollea hasta el primer contacto existente que su nombre empiece por la letra deseada
                    if (!string.IsNullOrWhiteSpace(nombre) &&
                        char.ToUpper(nombre[0]) == letra)
                    {
                        panelContacts.ScrollControlIntoView(ctrl);
                        return;
                    }
                }
            }
        }



    }
}
