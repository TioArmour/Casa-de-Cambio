using System;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class CasaCambio : Form
    {
        Logica.Archivos Doc = new Archivos();
        public CasaCambio()
        {
            InitializeComponent();
        }

        private void btnCrearArchivo_Click(object sender, EventArgs e)
        {
            Form Crear = new CrearArchivos();
            Crear.ShowDialog();
        }

        private void CasaCambio_Load(object sender, EventArgs e)
        {
            gbProcesoCompraVenta.Enabled = false;
            gbTotalesDia.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            cbArchivo.Items.Clear();
            Doc.DocumentosCreados(cbArchivo);
        }

        private void btnInicioDia_Click(object sender, EventArgs e)
        {
            string montoInicialBs = txtMontoInicialBs.Text;
            string montoInicialUSD = txtMontoInicialUSD.Text;
            string TCC = txtTCC.Text;
            string TCV = txtTCV.Text;
            string fecha = txtFecha.Text;
            if(montoInicialBs != "" && montoInicialUSD != "" && TCC != "" && TCV != "" && fecha != "")
            {
                
                string[] informacion = { $"Fecha: {fecha}", $"Monto Inicial Bs: {montoInicialBs}", $"Monto Inicial USD: {montoInicialUSD}", $"TCC: {TCC}", $"TCV: {TCV}"};
                try
                {
                    Transacciones Op = new Transacciones(double.Parse(montoInicialBs),double.Parse(montoInicialUSD), double.Parse(TCC), double.Parse(TCV), double.Parse(montoInicialUSD), double.Parse(montoInicialUSD));
                    DateTime.Parse(txtFecha.Text);
                    txtFecha.Enabled = false;
                    cbArchivo.Enabled = false;
                    btnCrearArchivo.Enabled = false;
                    btnExaminar.Enabled = false;
                    gbProcesoCompraVenta.Enabled = true;
                    gbDatosDia.Enabled = false;
                    txtCompraBs.Enabled = false;
                    txtVentaBs.Enabled = false;
                    Doc.Guardar(cbArchivo.Text, informacion);
                    txtMontoTotalBs.Text = txtMontoInicialBs.Text;
                    txtMontoTotalUSD.Text = txtMontoInicialUSD.Text;
                }
                catch
                {
                    MessageBox.Show("La información introducida es incorrecta. Inténtalo nuevamente");
                }
            }
            else
            {
                MessageBox.Show("Falta Información.");
            }
            
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string montoInicialBs = txtMontoInicialBs.Text;
            string montoInicialUSD = txtMontoInicialUSD.Text;
            string montoTotalBs = txtMontoTotalBs.Text;
            string montoTotalUSD = txtMontoTotalUSD.Text;
            string TCC = txtTCC.Text;
            string TCV = txtTCV.Text;
            Transacciones Op = new Transacciones(double.Parse(montoInicialBs), double.Parse(montoInicialUSD), double.Parse(TCC), double.Parse(TCV), double.Parse(montoTotalUSD), double.Parse(montoTotalBs));
            double[] montoCompraBs = Op.CompraDolares(txtCompraUSD, Op);
            txtCompraBs.Text = Convert.ToString(montoCompraBs[0]);
            txtMontoTotalBs.Text = Convert.ToString(montoCompraBs[1]);
            txtMontoTotalUSD.Text = Convert.ToString(montoCompraBs[2]);
            if (montoCompraBs[0] != 0)
            {
                string[] datosGuadar = { $"Compra {txtCompraUSD.Text} $us --> {txtCompraBs.Text} Bs." };
                lstOperaciones.Items.Insert(0, ($"Compra {txtCompraUSD.Text} $us --> {txtCompraBs.Text}  Bs."));
                Doc.Guardar(cbArchivo.Text, datosGuadar);
            }
            txtCompraUSD.Clear();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            string montoInicialBs = txtMontoInicialBs.Text;
            string montoInicialUSD = txtMontoInicialUSD.Text;
            string montoTotalBs = txtMontoTotalBs.Text;
            string montoTotalUSD = txtMontoTotalUSD.Text;
            string TCC = txtTCC.Text;
            string TCV = txtTCV.Text;
            Transacciones Op = new Transacciones(double.Parse(montoInicialBs), double.Parse(montoInicialUSD), double.Parse(TCC), double.Parse(TCV), double.Parse(montoTotalUSD), double.Parse(montoTotalBs));
            double[] montoVentaBs = Op.VentaDolares(txtVentaUSD, Op);
            txtVentaBs.Text = Convert.ToString(montoVentaBs[0]);
            txtMontoTotalBs.Text = Convert.ToString(montoVentaBs[1]);
            txtMontoTotalUSD.Text = Convert.ToString(montoVentaBs[2]);
            if(montoVentaBs[0] != 0)
            {
                string[] datosGuadar = { $"Venta {txtVentaUSD.Text} $us --> {txtVentaBs.Text} Bs." };
                lstOperaciones.Items.Insert(0, ($"Venta {txtVentaUSD.Text} $us --> {txtVentaBs.Text}  Bs."));
                Doc.Guardar(cbArchivo.Text, datosGuadar);
            }
            txtVentaUSD.Clear();
            
        }
    }
}
