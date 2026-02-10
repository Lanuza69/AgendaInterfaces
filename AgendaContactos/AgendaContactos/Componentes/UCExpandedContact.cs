using AgendaContactos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContactos.Componentes
{
    public partial class UCExpandedContact : UserControl
    {
        private Contact currentContact;
        public event EventHandler OnBack;
        public event EventHandler<Contact> OnSaveFields;
        public event EventHandler<Contact> OnSave;
        public event EventHandler<Contact> OnDelete;
        private bool modoLectura;

        public UCExpandedContact()
        {
            InitializeComponent();
            btnBack.Click += (s, e) => OnBack?.Invoke(this, EventArgs.Empty);
            btnEdit.Click += (s, e) => SetReading(false);
            btnSave.Click += (s, e) =>
            {
                if (!ValidateDate())
                {
                    MessageBox.Show("La fecha del cumpleaños no es valida");
                    return;
                }
                SaveFields();
                OnSaveFields?.Invoke(this, currentContact);
                SetReading(true);
            };
            pictureBoxFoto.Click += (s, e) =>
            {
                if (!modoLectura)
                    SelectPhoto();
            };


            btnCancel.Click += (s, e) => Load(currentContact, read: true);
            btnDelete.Click += (s, e) => OnDelete?.Invoke(this, currentContact);

            btnAddTel.Click += (s, e) => AddTelefono();
            btnAddEmail.Click += (s, e) => AddEmail();
        }
        public void Load(Contact c, bool read = true)
        {
            //Carga la info en el Expanded para ver la info del contacto
            currentContact = c;

            txtNombre.Text = c.Nombre;
            txtApellidos.Text = c.Apellidos;
            txtEmpresa.Text = c.Empresa;
            txtDireccion.Text = c.Direccion;

            panelTelefonos.Controls.Clear();
            foreach (var tel in c.Telefonos)
                AddTelefono(tel);

            panelEmails.Controls.Clear();
            foreach (var mail in c.Emails)
                AddEmail(mail);

            LoadDate(c);
            LoadPhoto(c);

            SetReading(read);
        }

        public void SetReading(bool read = true)
        {
            //Funcion para el control de modo lectura vs edición
            modoLectura = read;

            txtNombre.ReadOnly = read;
            txtApellidos.ReadOnly = read;
            txtEmpresa.ReadOnly = read;
            txtDireccion.ReadOnly = read;

            foreach (FlowLayoutPanel c in panelTelefonos.Controls)
            {
                c.Controls.OfType<TextBox>().First().Enabled = !read;
                c.Controls.OfType<Button>().First().Visible = !read;
            }

            foreach (FlowLayoutPanel c in panelEmails.Controls)
            {
                c.Controls.OfType<TextBox>().First().Enabled = !read;
                c.Controls.OfType<Button>().First().Visible = !read;
            }

            comboDia.Visible = comboMes.Visible = comboAnio.Visible = !read;
            lblFecha.Visible = read;
            if (read && !string.IsNullOrEmpty(currentContact.Dia))
            {
                try
                {
                    var fecha = new DateTime(
                        int.Parse(currentContact.Anio),
                        int.Parse(currentContact.Mes),
                        int.Parse(currentContact.Dia)
                    );
                    lblFecha.Text = fecha.ToString("dd 'de' MMMM 'de' yyyy");
                }
                catch
                {
                    lblFecha.Text = "";
                }
            }

            btnEdit.Visible = read;
            btnSave.Visible = !read;
            btnCancel.Visible = !read;

            btnAddTel.Visible = !read;
            btnAddEmail.Visible = !read;

            pictureBoxFoto.Cursor = read ? Cursors.Default : Cursors.Hand;
        }

        private void LoadDate(Contact c)
        {
            comboDia.Items.Clear();
            comboDia.Items.AddRange(Enumerable.Range(1, 31).Select(i => i.ToString()).ToArray());//Rango de dias

            comboMes.Items.Clear();
            comboMes.Items.AddRange(new[]
            { "Enero","Febrero","Marzo","Abril","Mayo","Junio",
      "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" });//Rango de Meses

            comboAnio.Items.Clear();
            comboAnio.Items.AddRange(
                Enumerable.Range(1900, DateTime.Now.Year - 1900 + 1)//Rango de años
                .Select(i => i.ToString())
                .Reverse()//Para que salga primero el 2026
                .ToArray()
            );
            //Intentamos convertirlos a string
            if (int.TryParse(c.Dia, out int d)) comboDia.Text = d.ToString();
            if (int.TryParse(c.Mes, out int m)) comboMes.SelectedIndex = m - 1;
            if (int.TryParse(c.Anio, out int y)) comboAnio.Text = y.ToString();

        }

        private bool ValidateDate()
        {
            //Si hay algun valor nulo devuelve true pero no lo guarda en la funcion SaveFields
            if (comboDia.SelectedIndex == -1 || comboMes.SelectedIndex == -1 || comboAnio.SelectedIndex == -1)
                return true;
            try
            {
                //Parsea para comprobar que es una fecha valida. No 30 de febrero del año 5
                var d = int.Parse(comboDia.Text);
                var m = comboMes.SelectedIndex + 1;
                var y = int.Parse(comboAnio.Text);
                var fecha = new DateTime(y, m, d);
                return true;
            }
            catch { return false; }
        }

        private void SaveFields()
        {
            //Se guardan los atributos en el contacto
            currentContact.Nombre = txtNombre.Text;
            currentContact.Apellidos = txtApellidos.Text;
            currentContact.Empresa = txtEmpresa.Text;
            currentContact.Direccion = txtDireccion.Text;

            //Se guardan todos aquellos telefonos que no son nulos,vacios o con espacios en blanco
            currentContact.Telefonos = panelTelefonos.Controls
                .OfType<FlowLayoutPanel>()
                .Select(c => c.Controls.OfType<TextBox>().First().Text)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();

            //Se guardan todos aquellos emails que no son nulos,vacios o con espacios en blanco
            currentContact.Emails = panelEmails.Controls
                .OfType<FlowLayoutPanel>()
                .Select(c => c.Controls.OfType<TextBox>().First().Text)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();

            //Combierte los combos en una string y se guarda, no entra en el if si hay algun nulo
            if (comboDia.SelectedIndex != -1 || comboMes.SelectedIndex != -1 || comboAnio.SelectedIndex != -1)
            {
                currentContact.Dia = comboDia.Text;
                currentContact.Mes = (comboMes.SelectedIndex + 1).ToString();
                currentContact.Anio = comboAnio.Text;
            }
            //Resetear los combos
            ResetCombos();
        }
        private void AddTelefono(string value = "")
        {
            //Se genera un panel contenedor para poder ir añadiendo lo siguiente
            var container = new FlowLayoutPanel();

            //Generación de TextBox vacio para escribir el nuevo Telefono
            var txtTel = new TextBox();
            txtTel.Text = value;
            txtTel.Width = 220;
            txtTel.Enabled = !modoLectura;

            //Boton correpondiente a la eliminacion del anteriior tesxtBox
            var btnX = new Button();
            btnX.Text = "X";
            btnX.Width = 30;
            btnX.BackColor = Color.FromArgb(227, 211, 208);
            btnX.Font = new Font("Segoe UI", 8.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.FromArgb(73, 37, 10);
            btnX.Visible = !modoLectura;
            btnX.Click += (s, e) => panelTelefonos.Controls.Remove(container);

            //Ambos se añaden al panel
            container.Width = panelTelefonos.Width - 10;
            container.Height = 30;
            container.Controls.Add(txtTel);
            container.Controls.Add(btnX);

            panelTelefonos.Controls.Add(container);
        }
        private void AddEmail(string value = "")
        {
            //Se genera un panel contenedor para poder ir añadiendo lo siguiente
            var container = new FlowLayoutPanel();

            //Generación de TextBox vacio para escribir el nuevo Email
            var txtEm = new TextBox();
            txtEm.Text = value;
            txtEm.Width = 220;
            txtEm.Enabled = !modoLectura;

            //Boton correpondiente a la eliminacion del anteriior tesxtBox
            var  btnX = new Button();
            btnX.Text = "X";
            btnX.Width = 30;
            btnX.BackColor = Color.FromArgb(227, 211, 208);
            btnX.Font = new Font("Segoe UI", 8.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.FromArgb(73, 37, 10);
            btnX.Visible = !modoLectura;
            btnX.Click += (s, e) => panelEmails.Controls.Remove(container);

            //Ambos se añaden al panel
            container.Width = panelEmails.Width - 10;
            container.Height = 30;
            container.Controls.Add(txtEm);
            container.Controls.Add(btnX);

            panelEmails.Controls.Add(container);
        }

        private void SelectPhoto()
        {
            // Creamos y configuramos el OpenFileDialog para seleccionar imagenes
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Title = "Seleccionar foto";

            // Si se selecciona un archivo
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Obtenemos la ruta y el formato
                string origen = ofd.FileName;
                string extension = Path.GetExtension(origen);

                //Generamos nombre unico
                string nombre = $"{Guid.NewGuid()}{extension}";

                //Creamos la ruta de la carpeta y nos aseguramos que exista la carpeta, para poder copiar el archivo
                string carpeta = Path.Combine(Application.StartupPath, "FotosContacto");
                Directory.CreateDirectory(carpeta);

                string destino = Path.Combine(carpeta, nombre);
                File.Copy(origen, destino, true);

                // Actualiza la imagen y la carga
                currentContact.Foto = destino;
                using (var temp = Image.FromFile(destino))
                {
                    pictureBoxFoto.Image = new Bitmap(temp);
                }
            }
        }


        private void LoadPhoto(Contact c)
        {
            // Carga la imagen si existe en el pictureBox
            pictureBoxFoto.Image = File.Exists(c.Foto)
                ? Image.FromFile(c.Foto)
                : null;
        }
        private void ResetCombos()
        {
            // Reseteamos los combos del cumpleaños para que no aparezcan seleccionados de un expanded a otro
            comboDia.SelectedIndex = -1;
            comboAnio.SelectedIndex = -1;
            comboMes.SelectedIndex = -1;
        }

        
    }
}
