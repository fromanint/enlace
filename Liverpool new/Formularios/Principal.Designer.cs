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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmbarque = new System.Windows.Forms.Button();
            this.btnEtiVestidos = new System.Windows.Forms.Button();
            this.btnPedidoExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnVersion = new System.Windows.Forms.Button();
            this.AbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEmbarque);
            this.groupBox1.Controls.Add(this.btnEtiVestidos);
            this.groupBox1.Controls.Add(this.btnPedidoExcel);
            this.groupBox1.Location = new System.Drawing.Point(33, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operaciones";
            // 
            // btnEmbarque
            // 
            this.btnEmbarque.Location = new System.Drawing.Point(379, 30);
            this.btnEmbarque.Name = "btnEmbarque";
            this.btnEmbarque.Size = new System.Drawing.Size(99, 51);
            this.btnEmbarque.TabIndex = 1;
            this.btnEmbarque.Text = "Generar Etiquetas Embarque";
            this.btnEmbarque.UseVisualStyleBackColor = true;
            this.btnEmbarque.Click += new System.EventHandler(this.btnEmbarque_Click);
            // 
            // btnEtiVestidos
            // 
            this.btnEtiVestidos.Location = new System.Drawing.Point(203, 30);
            this.btnEtiVestidos.Name = "btnEtiVestidos";
            this.btnEtiVestidos.Size = new System.Drawing.Size(99, 51);
            this.btnEtiVestidos.TabIndex = 2;
            this.btnEtiVestidos.Text = "Generar Etiquetas  Vestido";
            this.btnEtiVestidos.UseVisualStyleBackColor = true;
            this.btnEtiVestidos.Click += new System.EventHandler(this.btnEtiVestidos_Click);
            // 
            // btnPedidoExcel
            // 
            this.btnPedidoExcel.Location = new System.Drawing.Point(19, 30);
            this.btnPedidoExcel.Name = "btnPedidoExcel";
            this.btnPedidoExcel.Size = new System.Drawing.Size(99, 51);
            this.btnPedidoExcel.TabIndex = 0;
            this.btnPedidoExcel.Text = "Generar Pedido Excel";
            this.btnPedidoExcel.UseVisualStyleBackColor = true;
            this.btnPedidoExcel.Click += new System.EventHandler(this.btnPedidoExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTienda);
            this.groupBox2.Location = new System.Drawing.Point(590, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 213);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Administrar";
            // 
            // btnTienda
            // 
            this.btnTienda.Location = new System.Drawing.Point(39, 29);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(125, 37);
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
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(117, 41);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(159, 20);
            this.txtPedido.TabIndex = 3;
            this.txtPedido.Text = "Abrir Pedido";
            this.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPedido.Click += new System.EventHandler(this.txtPedido_Click);
            this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(345, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(84, 109);
            this.checkedListBox1.TabIndex = 4;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.btnVersion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPedidoExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEmbarque;
        private System.Windows.Forms.Button btnEtiVestidos;
        private System.Windows.Forms.Button btnTienda;
        private System.Windows.Forms.Button btnVersion;
        private System.Windows.Forms.OpenFileDialog AbrirArchivo;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

