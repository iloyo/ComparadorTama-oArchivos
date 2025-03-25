namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable de diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles declarados
        private System.Windows.Forms.TextBox txtFilesBefore;
        private System.Windows.Forms.TextBox txtFilesAfter;
        private System.Windows.Forms.TextBox txtReportFolder;
        private System.Windows.Forms.Button btnSelectBefore;
        private System.Windows.Forms.Button btnSelectAfter;
        private System.Windows.Forms.Button btnSelectReportFolder;
        private System.Windows.Forms.Button btnGenerateReport;

        /// <summary>
        /// Limpiar los recursos que están en uso.
        /// </summary>
        /// <param name="disposing">Indica si los recursos administrados deben ser eliminados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método necesario para la configuración de los controles del formulario.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFilesBefore = new System.Windows.Forms.TextBox();
            this.txtFilesAfter = new System.Windows.Forms.TextBox();
            this.txtReportFolder = new System.Windows.Forms.TextBox();
            this.btnSelectBefore = new System.Windows.Forms.Button();
            this.btnSelectAfter = new System.Windows.Forms.Button();
            this.btnSelectReportFolder = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFilesBefore
            // 
            this.txtFilesBefore.Location = new System.Drawing.Point(49, 140);
            this.txtFilesBefore.Name = "txtFilesBefore";
            this.txtFilesBefore.ReadOnly = false;
            this.txtFilesBefore.Size = new System.Drawing.Size(400, 26);
            this.txtFilesBefore.TabIndex = 0;
            // 
            // txtFilesAfter
            // 
            this.txtFilesAfter.Location = new System.Drawing.Point(49, 193);
            this.txtFilesAfter.Name = "txtFilesAfter";
            this.txtFilesAfter.ReadOnly = false;
            this.txtFilesAfter.Size = new System.Drawing.Size(400, 26);
            this.txtFilesAfter.TabIndex = 2;
            // 
            // txtReportFolder
            // 
            this.txtReportFolder.Location = new System.Drawing.Point(49, 250);
            this.txtReportFolder.Name = "txtReportFolder";
            this.txtReportFolder.ReadOnly = false;
            this.txtReportFolder.Size = new System.Drawing.Size(400, 26);
            this.txtReportFolder.TabIndex = 4;
            // 
            // btnSelectBefore
            // 
            this.btnSelectBefore.Location = new System.Drawing.Point(485, 136);
            this.btnSelectBefore.Name = "btnSelectBefore";
            this.btnSelectBefore.Size = new System.Drawing.Size(289, 34);
            this.btnSelectBefore.TabIndex = 1;
            this.btnSelectBefore.Text = "Seleccionar Antes Despligue";
            this.btnSelectBefore.UseVisualStyleBackColor = true;
            // 
            // btnSelectAfter
            // 
            this.btnSelectAfter.Location = new System.Drawing.Point(485, 189);
            this.btnSelectAfter.Name = "btnSelectAfter";
            this.btnSelectAfter.Size = new System.Drawing.Size(289, 34);
            this.btnSelectAfter.TabIndex = 3;
            this.btnSelectAfter.Text = "Seleccionar Después Despliegue";
            this.btnSelectAfter.UseVisualStyleBackColor = true;
            // 
            // btnSelectReportFolder
            // 
            this.btnSelectReportFolder.Location = new System.Drawing.Point(485, 242);
            this.btnSelectReportFolder.Name = "btnSelectReportFolder";
            this.btnSelectReportFolder.Size = new System.Drawing.Size(289, 34);
            this.btnSelectReportFolder.TabIndex = 5;
            this.btnSelectReportFolder.Text = "Seleccionar Ruta de Informe";
            this.btnSelectReportFolder.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(153, 317);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(550, 40);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Generar Reporte";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Validador de Reportes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(816, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilesBefore);
            this.Controls.Add(this.btnSelectBefore);
            this.Controls.Add(this.txtFilesAfter);
            this.Controls.Add(this.btnSelectAfter);
            this.Controls.Add(this.txtReportFolder);
            this.Controls.Add(this.btnSelectReportFolder);
            this.Controls.Add(this.btnGenerateReport);
            this.Name = "Form1";
            this.Text = "Validación de Reportes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}
