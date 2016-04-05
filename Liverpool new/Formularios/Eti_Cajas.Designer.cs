namespace Liverpool_new.Formularios
{
    partial class Eti_Cajas
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
            this.check = new System.Windows.Forms.Button();
            this.uncheck = new System.Windows.Forms.Button();
            this.lblfecha = new System.Windows.Forms.Label();
            this.fechaa = new System.Windows.Forms.DateTimePicker();
            this.lblprincipal = new System.Windows.Forms.Label();
            this.Generar = new System.Windows.Forms.Button();
            this.ListaTiendas = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(457, 349);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(98, 44);
            this.check.TabIndex = 13;
            this.check.Text = "Seleccionar     todo";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // uncheck
            // 
            this.uncheck.Location = new System.Drawing.Point(561, 349);
            this.uncheck.Name = "uncheck";
            this.uncheck.Size = new System.Drawing.Size(98, 44);
            this.uncheck.TabIndex = 12;
            this.uncheck.Text = "Deseleccionar todo";
            this.uncheck.UseVisualStyleBackColor = true;
            this.uncheck.Click += new System.EventHandler(this.uncheck_Click);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(575, 12);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(84, 13);
            this.lblfecha.TabIndex = 11;
            this.lblfecha.Text = "Elige una fecha:";
            // 
            // fechaa
            // 
            this.fechaa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaa.Location = new System.Drawing.Point(672, 9);
            this.fechaa.MinDate = new System.DateTime(2012, 9, 7, 0, 0, 0, 0);
            this.fechaa.Name = "fechaa";
            this.fechaa.Size = new System.Drawing.Size(92, 20);
            this.fechaa.TabIndex = 10;
            // 
            // lblprincipal
            // 
            this.lblprincipal.AutoSize = true;
            this.lblprincipal.Location = new System.Drawing.Point(37, 12);
            this.lblprincipal.Name = "lblprincipal";
            this.lblprincipal.Size = new System.Drawing.Size(256, 13);
            this.lblprincipal.TabIndex = 9;
            this.lblprincipal.Text = "Seleccione solo las tiendas que lleven una sola caja:";
            // 
            // Generar
            // 
            this.Generar.Location = new System.Drawing.Point(665, 349);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(98, 44);
            this.Generar.TabIndex = 7;
            this.Generar.Text = "Generar";
            this.Generar.UseVisualStyleBackColor = true;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            // 
            // ListaTiendas
            // 
            this.ListaTiendas.AllowDrop = true;
            this.ListaTiendas.CheckOnClick = true;
            this.ListaTiendas.FormattingEnabled = true;
            this.ListaTiendas.HorizontalScrollbar = true;
            this.ListaTiendas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "61",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.ListaTiendas.Location = new System.Drawing.Point(40, 42);
            this.ListaTiendas.MultiColumn = true;
            this.ListaTiendas.Name = "ListaTiendas";
            this.ListaTiendas.Size = new System.Drawing.Size(724, 289);
            this.ListaTiendas.TabIndex = 8;
            // 
            // Eti_Cajas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.check);
            this.Controls.Add(this.uncheck);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.fechaa);
            this.Controls.Add(this.lblprincipal);
            this.Controls.Add(this.ListaTiendas);
            this.Controls.Add(this.Generar);
            this.DoubleBuffered = true;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Eti_Cajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eti_Cajas";
            this.Load += new System.EventHandler(this.Eti_Cajas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button uncheck;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.DateTimePicker fechaa;
        private System.Windows.Forms.Label lblprincipal;
        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.CheckedListBox ListaTiendas;
    }
}