using AgendaContactos.Clases;
using AgendaContactos.Componentes;
using System.Diagnostics.Contracts;

namespace AgendaContactos
{
    public partial class Form1 : Form
    {


        public Form1()
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


    }
}