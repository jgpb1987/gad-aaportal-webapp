using ClosedXML.Excel;
using gad.aaportal.commons.Dto;
using System.Net.Http.Json;

namespace gad.admin.app
{
    public partial class CargaMasiva : Form
    {
        string[] paquetes =
        {
            "6282", "6281", "7728", "7730","7731","7732","6279","7736","7742"
            , 
            //"7733","7738","7739" ANALIZAR SI ES POSIBLE
        };

        string rutaArchivo = string.Empty;

        public CargaMasiva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
                ofd.Title = "Seleccionar archivo Excel";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = ofd.FileName;
                    lblFilePath.Text = rutaArchivo;
                }
            }
        }

        private async Task LeerDatosAsync(string rutaArchivo)
        {
            List<string> rucs = new List<string>();

            using (var stream = new FileStream(
                rutaArchivo,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);

                    if (worksheet.RangeUsed() == null)
                        return;

                    foreach (var row in worksheet.RowsUsed().Skip(1))
                    {
                        var celda = row.Cell(1);

                        if (!celda.IsEmpty())
                            rucs.Add(celda.GetValue<string>().Trim());
                    }
                }
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = rucs.Count;
            progressBar1.Value = 0;

            foreach (var ruc in rucs)
            {
                await ConsumoDinardap(ruc);

                progressBar1.Value += 1;
                lblProgreso.Text = $"{progressBar1.Value} / {progressBar1.Maximum}";
            }
        }

        public async Task ConsumoDinardap(string identificacion)
        {
            foreach (var paquete in paquetes)
            {
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var parametros = new { identificacion = identificacion, paquete = paquete };
                var resp = await http.PostAsJsonAsync("api/Dinardap/PaqueteIndividual", parametros);
                resp.EnsureSuccessStatusCode();
                var result = await resp.Content.ReadFromJsonAsync<ConsumoDinardapResult>();
            }
        }

        private async void btnProcesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivo))
            {
                MessageBox.Show("Seleccione un archivo primero.");
                return;
            }
            DateTime fechaInicio = DateTime.Now;
            lblInicio.Text = "Inicio: " + fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
            lblFin.Text = "";
            btnProcesar.Enabled = false;
            await LeerDatosAsync(rutaArchivo);
            DateTime fechaFin = DateTime.Now;
            lblFin.Text = "Fin: " + fechaFin.ToString("yyyy-MM-dd HH:mm:ss");
            TimeSpan duracion = fechaFin - fechaInicio;
            MessageBox.Show($"Proceso finalizado en {duracion.TotalSeconds:F2} segundos");
            btnProcesar.Enabled = true;
        }
    }
}
