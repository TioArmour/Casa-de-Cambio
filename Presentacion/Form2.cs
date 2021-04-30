using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class CrearArchivos : Form
    {
        Logica.Archivos Doc = new Logica.Archivos();
        public CrearArchivos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Doc.CrearArchivo(txtNombreArchivo.Text);
        }
    }
}
