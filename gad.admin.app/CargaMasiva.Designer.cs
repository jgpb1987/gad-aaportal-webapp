namespace gad.admin.app
{
    partial class CargaMasiva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            lblFilePath = new Label();
            progressBar1 = new ProgressBar();
            btnProcesar = new Button();
            lblLote = new Label();
            lblInicio = new Label();
            lblFin = new Label();
            lblProgreso = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(49, 28);
            button1.Name = "button1";
            button1.Size = new Size(240, 38);
            button1.TabIndex = 0;
            button1.Text = "Seleccionar archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(49, 91);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(59, 20);
            lblFilePath.TabIndex = 1;
            lblFilePath.Text = "Archivo";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(49, 171);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(944, 29);
            progressBar1.TabIndex = 2;
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(753, 28);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(240, 38);
            btnProcesar.TabIndex = 3;
            btnProcesar.Text = "Procesar";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Location = new Point(49, 234);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(41, 20);
            lblLote.TabIndex = 4;
            lblLote.Text = "Lote:";
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Location = new Point(412, 234);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(48, 20);
            lblInicio.TabIndex = 5;
            lblInicio.Text = "Inicio:";
            // 
            // lblFin
            // 
            lblFin.AutoSize = true;
            lblFin.Location = new Point(753, 234);
            lblFin.Name = "lblFin";
            lblFin.Size = new Size(31, 20);
            lblFin.TabIndex = 6;
            lblFin.Text = "Fin:";
            // 
            // lblProgreso
            // 
            lblProgreso.AutoSize = true;
            lblProgreso.Location = new Point(49, 148);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new Size(68, 20);
            lblProgreso.TabIndex = 7;
            lblProgreso.Text = "Progreso";
            // 
            // CargaMasiva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 337);
            Controls.Add(lblProgreso);
            Controls.Add(lblFin);
            Controls.Add(lblInicio);
            Controls.Add(lblLote);
            Controls.Add(btnProcesar);
            Controls.Add(progressBar1);
            Controls.Add(lblFilePath);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "CargaMasiva";
            Text = "CargaMasiva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblFilePath;
        private ProgressBar progressBar1;
        private Button btnProcesar;
        private Label lblLote;
        private Label lblInicio;
        private Label lblFin;
        private Label lblProgreso;
    }
}