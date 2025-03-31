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
            var filesBefore = Directory.GetFiles(txtFilesBefore.Text, "*.csv", SearchOption.AllDirectories)
                                       .Select(f => new FileInfo(f))
                                       .ToList();

            var filesAfter = Directory.GetFiles(txtFilesAfter.Text, "*.csv", SearchOption.AllDirectories)
                                      .Select(f => new FileInfo(f))
                                      .ToList();

            Debug.WriteLine($"Archivos Antes: {filesBefore.Count}");
            Debug.WriteLine($"Archivos Después: {filesAfter.Count}");

            StringBuilder csvContent = new StringBuilder();

            // Agregar encabezado
            csvContent.AppendLine("Archivo Antes,Tamaño Antes,Lineas Antes,Archivo Después,Tamaño Después,Lineas Después,Coincidencias de Global Interaction ID");

            // Mezclar ambas listas en una sola lista continua
            int maxCount = Math.Max(filesBefore.Count, filesAfter.Count);
            for (int i = 0; i < maxCount; i++)
            {
                string fileBeforeName = i < filesBefore.Count ? filesBefore[i].Name : "";
                string fileBeforeSize = i < filesBefore.Count ? filesBefore[i].Length.ToString() : "0";
                int lineasAntes = i < filesBefore.Count ? File.ReadAllLines(filesBefore[i].FullName).Length : 0;

                // Obtener los IDs de Global Interaction del archivo antes
                HashSet<string> globalIdsBefore = i < filesBefore.Count ? GetGlobalInteractionIds(filesBefore[i]) : new HashSet<string>();

                // Obtener el archivo correspondiente en la carpeta después
                string fileAfterName = "";
                string fileAfterSize = "0";
                int lineasDespues = 0;
                HashSet<string> globalIdsAfter = new HashSet<string>();

                if (i < filesAfter.Count)
                {
                    fileAfterName = filesAfter[i].Name;
                    fileAfterSize = filesAfter[i].Length.ToString();
                    lineasDespues = File.ReadAllLines(filesAfter[i].FullName).Length;

                    // Obtener los IDs de Global Interaction del archivo después
                    globalIdsAfter = GetGlobalInteractionIds(filesAfter[i]);
                }

                // Contar coincidencias de Global Interaction IDs
                int coincidencias = globalIdsBefore.Intersect(globalIdsAfter).Count();

                csvContent.AppendLine($"{fileBeforeName},{fileBeforeSize},{lineasAntes},{fileAfterName},{fileAfterSize},{lineasDespues},{coincidencias} Coincidencias");
            }

            // Guardar el CSV
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string csvFilePath = Path.Combine(txtReportFolder.Text, $"Validacion_{timestamp}.csv");
            File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.UTF8);

            MessageBox.Show($"Reporte generado en: {csvFilePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private HashSet<string> GetGlobalInteractionIds(FileInfo file)
        {
            HashSet<string> globalIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase); 

            if (file.Exists)
            {
                var lines = File.ReadAllLines(file.FullName);
                if (lines.Length > 0)
                {
                    // Obtener el índice de la columna "Global Interaction ID"
                    var headers = lines[0].Split(',');
                    int idIndex = Array.IndexOf(headers, "Global Interaction ID");

                    if (idIndex >= 0)
                    {
                        // Leer los IDs de las líneas restantes
                        for (int i = 1; i < lines.Length; i++)
                        {
                            var values = lines[i].Split(',');
                            if (values.Length > idIndex)
                            {
                                string id = values[idIndex].Trim();
                                if (!string.IsNullOrEmpty(id))
                                {
                                    globalIds.Add(id); // Agregar el ID a la colección
                                }
                            }
                        }
                    }
                }
            }

            return globalIds;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {

        }
    }
}