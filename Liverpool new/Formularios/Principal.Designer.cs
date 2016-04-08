namespace Liverpool_new
{
    partial class Principal
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
            this.Operaciones = new System.Windows.Forms.GroupBox();
            this.btnEmbarque = new System.Windows.Forms.Button();
            this.btnEtiVestidos = new System.Windows.Forms.Button();
            this.btnPedidoExcel = new System.Windows.Forms.Button();
            this.cmodelos = new System.Windows.Forms.CheckedListBox();
            this.Administrar = new System.Windows.Forms.GroupBox();
            this.btnBasicos = new System.Windows.Forms.Button();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnVersion = new System.Windows.Forms.Button();
            this.AbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.Abrir = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.GroupBox();
            this.cbPedidos = new System.Windows.Forms.ComboBox();
            this.Operaciones.SuspendLayout();
            this.Administrar.SuspendLayout();
            this.InfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Operaciones
            // 
            this.Operaciones.Controls.Add(this.btnEmbarque);
            this.Operaciones.Controls.Add(this.btnEtiVestidos);
            this.Operaciones.Controls.Add(this.btnPedidoExcel);
            this.Operaciones.Location = new System.Drawing.Point(33, 173);
            this.Operaciones.Name = "Operaciones";
            this.Operaciones.Size = new System.Drawing.Size(526, 81);
            this.Operaciones.TabIndex = 0;
            this.Operaciones.TabStop = false;
            this.Operaciones.Text = "Operaciones";
            // 
            // btnEmbarque
            // 
            this.btnEmbarque.Location = new System.Drawing.Point(256, 21);
            this.btnEmbarque.Name = "btnEmbarque";
            this.btnEmbarque.Size = new System.Drawing.Size(99, 51);
            this.btnEmbarque.TabIndex = 1;
            this.btnEmbarque.Text = "Generar Etiquetas Embarque";
            this.btnEmbarque.UseVisualStyleBackColor = true;
            this.btnEmbarque.Click += new System.EventHandler(this.btnEmbarque_Click);
            // 
            // btnEtiVestidos
            // 
            this.btnEtiVestidos.Location = new System.Drawing.Point(133, 21);
            this.btnEtiVestidos.Name = "btnEtiVestidos";
            this.btnEtiVestidos.Size = new System.Drawing.Size(99, 51);
            this.btnEtiVestidos.TabIndex = 2;
            this.btnEtiVestidos.Text = "Generar Etiquetas  Vestido";
            this.btnEtiVestidos.UseVisualStyleBackColor = true;
            this.btnEtiVestidos.Click += new System.EventHandler(this.btnEtiVestidos_Click);
            // 
            // btnPedidoExcel
            // 
            this.btnPedidoExcel.Location = new System.Drawing.Point(10, 21);
            this.btnPedidoExcel.Name = "btnPedidoExcel";
            this.btnPedidoExcel.Size = new System.Drawing.Size(99, 51);
            this.btnPedidoExcel.TabIndex = 0;
            this.btnPedidoExcel.Text = "Generar Pedido Excel";
            this.btnPedidoExcel.UseVisualStyleBackColor = true;
            this.btnPedidoExcel.Click += new System.EventHandler(this.btnPedidoExcel_Click);
            // 
            // cmodelos
            // 
            this.cmodelos.FormattingEnabled = true;
            this.cmodelos.Location = new System.Drawing.Point(275, 19);
            this.cmodelos.Name = "cmodelos";
            this.cmodelos.Size = new System.Drawing.Size(101, 124);
            this.cmodelos.TabIndex = 4;
            // 
            // Administrar
            // 
            this.Administrar.Controls.Add(this.btnBasicos);
            this.Administrar.Controls.Add(this.btnTienda);
            this.Administrar.Location = new System.Drawing.Point(590, 12);
            this.Administrar.Name = "Administrar";
            this.Administrar.Size = new System.Drawing.Size(189, 213);
            this.Administrar.TabIndex = 1;
            this.Administrar.TabStop = false;
            this.Administrar.Text = "Administrar";
            // 
            // btnBasicos
            // 
            this.btnBasicos.Location = new System.Drawing.Point(41, 55);
            this.btnBasicos.Name = "btnBasicos";
            this.btnBasicos.Size = new System.Drawing.Size(116, 28);
            this.btnBasicos.TabIndex = 1;
            this.btnBasicos.Text = "Modelos Basicos";
            this.btnBasicos.UseVisualStyleBackColor = true;
            this.btnBasicos.Click += new System.EventHandler(this.btnBasicos_Click);
            // 
            // btnTienda
            // 
            this.btnTienda.Location = new System.Drawing.Point(41, 19);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(116, 28);
            this.btnTienda.TabIndex = 0;
            this.btnTienda.Text = "Tiendas";
            this.btnTienda.UseVisualStyleBackColor = true;
            this.btnTienda.Click += new System.EventHandler(this.btnTienda_Click);
            // 
            // btnVersion
            // 
            this.btnVersion.Location = new System.Drawing.Point(704, 231);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(75, 23);
            this.btnVersion.TabIndex = 2;
            this.btnVersion.Text = "Version";
            this.btnVersion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnVersion.UseVisualStyleBackColor = true;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // AbrirArchivo
            // 
            this.AbrirArchivo.Filter = "Archivo de texto|*.txt|Archivo delimitado por comas|*.csv";
            this.AbrirArchivo.FilterIndex = 2;
            // 
            // Abrir
            // 
            this.Abrir.Location = new System.Drawing.Point(33, 12);
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(75, 23);
            this.Abrir.TabIndex = 3;
            this.Abrir.Text = "Abrir Archivo";
            this.Abrir.UseVisualStyleBackColor = true;
            this.Abrir.Click += new System.EventHandler(this.Abrir_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.Controls.Add(this.cbPedidos);
            this.InfoBox.Controls.Add(this.cmodelos);
            this.InfoBox.Location = new System.Drawing.Point(166, 12);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(393, 155);
            this.InfoBox.TabIndex = 5;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "Informacion";
            this.InfoBox.Visible = false;
            // 
            // cbPedidos
            // 
            this.cbPedidos.FormattingEnabled = true;
            this.cbPedidos.Location = new System.Drawing.Point(51, 37);
            this.cbPedidos.Name = "cbPedidos";
            this.cbPedidos.Size = new System.Drawing.Size(121, 21);
            this.cbPedidos.TabIndex = 5;
            this.cbPedidos.SelectedIndexChanged += new System.EventHandler(this.cbPedidos_SelectedIndexChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.Abrir);
            this.Controls.Add(this.btnVersion);
            this.Controls.Add(this.Administrar);
            this.Controls.Add(this.Operaciones);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Operaciones.ResumeLayout(false);
            this.Administrar.ResumeLayout(false);
            this.InfoBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Operaciones;
        private System.Windows.Forms.Button btnPedidoExcel;
        private System.Windows.Forms.GroupBox Administrar;
        private System.Windows.Forms.Button btnEmbarque;
        private System.Windows.Forms.Button btnEtiVestidos;
        private System.Windows.Forms.Button btnTienda;
        private System.Windows.Forms.Button btnVersion;
        private System.Windows.Forms.OpenFileDialog AbrirArchivo;
        private System.Windows.Forms.CheckedListBox cmodelos;
        private System.Windows.Forms.Button btnBasicos;
        private System.Windows.Forms.Button Abrir;
        private System.Windows.Forms.GroupBox InfoBox;
        private System.Windows.Forms.ComboBox cbPedidos;
    }
}

