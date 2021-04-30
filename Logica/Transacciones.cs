using System.Windows.Forms;

namespace Logica
{
    public class Transacciones
    {

        double montoInicialBs;
        double montoInicialUSD;
        double TCC;
        double TCV;
        double montoTotalUSD;
        double montoTotalBs;
        double montoBs;

        public Transacciones(double montoInicialBs, double montoInicialUSD, double TCC, double TCV, double montoTotalUSD, double montoTotalBs)
        {
            this.montoInicialBs = montoInicialBs;
            this.montoInicialUSD = montoInicialUSD;
            this.TCC = TCC;
            this.TCV = TCV;
            this.montoTotalBs = montoTotalBs;
            this.montoTotalUSD = montoTotalUSD;
        }

        public double[] CompraDolares(TextBox compraUSD, Transacciones informacion)
        {

            if (compraUSD.Text != "")
            {
                try
                {
                    montoBs = informacion.TCC * double.Parse(compraUSD.Text);
                    if (montoBs <= informacion.montoTotalBs)
                    {
                        informacion.montoTotalBs -= montoBs;
                        informacion.montoTotalUSD += double.Parse(compraUSD.Text);
                        double[] Compra = { montoBs, informacion.montoTotalBs, informacion.montoTotalUSD};
                        return Compra;
                    }
                    else
                    {
                        MessageBox.Show("No es posible realizar la compra.");
                        double[] Compra = { 0, informacion.montoTotalBs, informacion.montoTotalUSD };
                        return Compra;
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la operación. Inténtalo nuevamente.");
                    double[] Compra = { 0, informacion.montoTotalBs, informacion.montoTotalUSD };
                    return Compra;
                }
            }
            else
            {
                MessageBox.Show("Debes introducir un valor.");
                double[] Compra = { 0, informacion.montoTotalBs, informacion.montoTotalUSD };
                return Compra;
            }
        }

        public double[] VentaDolares(TextBox ventaUSD, Transacciones informacion)
        {

            if (ventaUSD.Text != "")
            {
                try
                {
                    montoBs = informacion.TCV * double.Parse(ventaUSD.Text);
                    if (informacion.montoTotalUSD >= double.Parse(ventaUSD.Text))
                    {
                        informacion.montoTotalUSD -= double.Parse(ventaUSD.Text);
                        informacion.montoTotalBs += montoBs;
                        double[] venta = { montoBs, informacion.montoTotalBs, informacion.montoTotalUSD };
                        return venta;
                    }
                    else
                    {
                        MessageBox.Show("No es posible realizar la venta.");
                        double[] venta = { montoBs, informacion.montoTotalBs, informacion.montoTotalUSD };
                        return venta;
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la operación. Inténtalo nuevamente.");
                    double[] venta = { montoBs, informacion.montoTotalBs, informacion.montoTotalUSD };
                    return venta;
                }
            }
            else
            {
                MessageBox.Show("Debes introducir un valor.");
                double[] venta = { montoBs, informacion.montoTotalBs, informacion.montoTotalUSD };
                return venta;
            }
        }
    }
}
