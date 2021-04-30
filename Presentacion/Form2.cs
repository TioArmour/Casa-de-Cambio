using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
