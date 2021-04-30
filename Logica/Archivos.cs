using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Logica
{
    public class Archivos
    {
        public void CrearArchivo(string nombreArchivo)
        {
            string ruta = @"C:\Users\omarc\OneDrive - Escuela Militar de Ingenieria\3° Semestre Ing. Mec\Programacion II\VisualStudio\AvanceP2\CasaDeCambio\Archivos\" + nombreArchivo + ".txt";
            try
            {
                if (!File.Exists(ruta))
                {
                    File.Create(ruta);
                    MessageBox.Show("El archivo se ha creado con éxito");
                }
                else
                {
                    MessageBox.Show("No se ha podido crear el archivo porque ya existe un archivo con ese nombre");
                }
            }
            catch
            {
                MessageBox.Show("No se ha podido crear el archivo");
            }
        }

        public void DocumentosCreados(ComboBox listaDocumentos)
        {
            string ruta = @"C:\Users\omarc\OneDrive - Escuela Militar de Ingenieria\3° Semestre Ing. Mec\Programacion II\VisualStudio\AvanceP2\CasaDeCambio\Archivos";
            try
            {
                var files = from retrievedFile in Directory.GetFiles(ruta, "*.txt", SearchOption.AllDirectories)
                            select new
                            {
                                File = retrievedFile
                            };
                foreach (var file in files)
                {
                    listaDocumentos.Items.Add(file.File);
                }
            }
            catch
            {
                MessageBox.Show("No ha sido posible encontar los archivos.");
            }
        }

        public void Guardar(string ruta, string[] informacion)
        {
            try
            {
                //Abrimos el archivo para escribir informacion
                using (StreamWriter files = new StreamWriter(ruta, true))
                {
                    foreach (string dato in informacion)
                    {
                        files.WriteLine(dato);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al guardar la información");
            }
        }
    }
}
