using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSelectBefore.Click += btnSelectBefore_Click;
            btnSelectAfter.Click += btnSelectAfter_Click;
            btnSelectReportFolder.Click += btnSelectReportFolder_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;
        }

        private void btnSelectBefore_Click(object sender, EventArgs e)
        {
            SelectFolder(txtFilesBefore);
        }

        private void btnSelectAfter_Click(object sender, EventArgs e)
        {
            SelectFolder(txtFilesAfter);
        }

        private void btnSelectReportFolder_Click(object sender, EventArgs e)
        {
            string initialDirectory = string.IsNullOrWhiteSpace(txtFilesAfter.Text) ? "C:\\" : txtFilesAfter.Text;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = initialDirectory;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtReportFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void SelectFolder(TextBox textBox)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilesBefore.Text) || string.IsNullOrWhiteSpace(txtFilesAfter.Text) || string.IsNullOrWhiteSpace(txtReportFolder.Text))
            {
                MessageBox.Show("Debe seleccionar todas las rutas antes de generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Debug.WriteLine($"Ruta Antes: {txtFilesBefore.Text}");
            Debug.WriteLine($"Ruta Después: {txtFilesAfter.Text}");

            // Obtener archivos de cada carpeta
            var filesBefore = Directory.GetFiles(txtFilesBefore.Text, "*.*", SearchOption.AllDirectories)
                                       .Select(f => new FileInfo(f))
                                       .ToList();

            var filesAfter = Directory.GetFiles(txtFilesAfter.Text, "*.*", SearchOption.AllDirectories)
                                      .Select(f => new FileInfo(f))
                                      .ToList();

            Debug.WriteLine($"Archivos Antes: {filesBefore.Count}");
            Debug.WriteLine($"Archivos Después: {filesAfter.Count}");

            StringBuilder csvContent = new StringBuilder();

            // Agregar encabezado
            csvContent.AppendLine("Archivo Antes,Tamaño Antes,Archivo Después,Tamaño Después");

            // Mezclar ambas listas en una sola lista continua
            int maxCount = Math.Max(filesBefore.Count, filesAfter.Count);
            for (int i = 0; i < maxCount; i++)
            {
                string fileBeforeName = i < filesBefore.Count ? filesBefore[i].Name : "";
                string fileBeforeSize = i < filesBefore.Count ? filesBefore[i].Length.ToString() : "0";
                string fileAfterName = i < filesAfter.Count ? filesAfter[i].Name : "";
                string fileAfterSize = i < filesAfter.Count ? filesAfter[i].Length.ToString() : "0";

                csvContent.AppendLine($"{fileBeforeName},{fileBeforeSize},{fileAfterName},{fileAfterSize}");
            }

            // Guardar el CSV
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string csvFilePath = Path.Combine(txtReportFolder.Text, $"Validacion_{timestamp}.csv");
            File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.UTF8);

            MessageBox.Show($"Reporte generado en: {csvFilePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}






