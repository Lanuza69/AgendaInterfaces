using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaContactos.Clases;

namespace AgendaContactos.Componentes
{
    public partial class UCCollapsedContact : UserControl
    {
        public Contact contact { get; set; }
        public event EventHandler<Contact> OnClickExpand;

        public UCCollapsedContact()
        {
            InitializeComponent();
            //Todos los Click son para que el usuario clickee donde sea para poder
            this.Click += this_Click;
            lblNombre.Click += this_Click;
            lblTelefono.Click += this_Click;
            lblEmail.Click += this_Click;
            pictureBoxFoto.Click += this_Click;
            guna2Panel1.Click += this_Click;
        }
        public void LoadContact(Contact c)
        {
            //Se carga la información del contacto en un collapsed
            contact = c;
            lblNombre.Text = c.NombreCompleto;
            if ((c.Telefonos.Any(t => !string.IsNullOrEmpty(t))))
                lblTelefono.Text = c.Telefonos[0];
            if((c.Emails.Any(t => !string.IsNullOrEmpty(t))))
                lblEmail.Text = c.Emails[0];
            if (!string.IsNullOrEmpty(c.Foto) && File.Exists(c.Foto))
                using (var temp = Image.FromFile(c.Foto))
                {
                    pictureBoxFoto.Image = new Bitmap(temp);
                }
        }

        private void this_Click(object sender, EventArgs e)
        {
            OnClickExpand?.Invoke(this, contact);//Evento para abrir la info extensa
        }
    }
}
