using AgendaContactos.Componentes;
using System.Runtime.CompilerServices;

namespace Agenda
{
    public partial class FormAgenda : Form
    {
        public FormAgenda()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Cuando se cierra el formulario
            base.OnFormClosing(e);
            uc.GuardarContactos(); //Aseguramos la persistencia
            uc.LimpiarFotosNoUsadas();//Limpiamos la carpeta de imagenes que no usamos

        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
