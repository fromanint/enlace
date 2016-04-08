namespace Liverpool_new.Formularios
{
    partial class Basicos
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
            this.GAcciones = new System.Windows.Forms.GroupBox();
            this.Bajar = new System.Windows.Forms.Button();
            this.Subir = new System.Windows.Forms.Button();
            this.Nuevo = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Eliminar_todo = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.GInformacion = new System.Windows.Forms.GroupBox();
            this.lbModelos = new System.Windows.Forms.ListBox();
            this.lblregistro = new System.Windows.Forms.Label();
            this.dtBasicos = new System.Data.DataSet();
            this.gbPonerInfo = new System.Windows.Forms.GroupBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.Modificar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.GAcciones.SuspendLayout();
            this.GInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBasicos)).BeginInit();
            this.gbPonerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GAcciones
            // 
            this.GAcciones.Controls.Add(this.Bajar);
            this.GAcciones.Controls.Add(this.Subir);
            this.GAcciones.Controls.Add(this.Nuevo);
            this.GAcciones.Controls.Add(this.Eliminar);
            this.GAcciones.Controls.Add(this.Modificar);
            this.GAcciones.Controls.Add(this.Eliminar_todo);
            this.GAcciones.Controls.Add(this.Guardar);
            this.GAcciones.Location = new System.Drawing.Point(222, 12);
            this.GAcciones.Name = "GAcciones";
            this.GAcciones.Size = new System.Drawing.Size(143, 273);
            this.GAcciones.TabIndex = 52;
            this.GAcciones.TabStop = false;
            this.GAcciones.Text = "Acciones";
            // 
            // Bajar
            // 
            this.Bajar.Location = new System.Drawing.Point(33, 137);
            this.Bajar.Name = "Bajar";
            this.Bajar.Size = new System.Drawing.Size(75, 23);
            this.Bajar.TabIndex = 45;
            this.Bajar.Text = "Bajar";
            this.Bajar.UseVisualStyleBackColor = true;
            this.Bajar.Click += new System.EventHandler(this.Bajar_Click);
            // 
            // Subir
            // 
            this.Subir.Location = new System.Drawing.Point(33, 108);
            this.Subir.Name = "Subir";
            this.Subir.Size = new System.Drawing.Size(75, 23);
            this.Subir.TabIndex = 44;
            this.Subir.Text = "Subir";
            this.Subir.UseVisualStyleBackColor = true;
            this.Subir.Click += new System.EventHandler(this.Subir_Click);
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(33, 19);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(75, 23);
            this.Nuevo.TabIndex = 35;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(33, 49);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 37;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Eliminar_todo
            // 
            this.Eliminar_todo.Location = new System.Drawing.Point(33, 237);
            this.Eliminar_todo.Name = "Eliminar_todo";
            this.Eliminar_todo.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_todo.TabIndex = 43;
            this.Eliminar_todo.Text = "Eliminar todo";
            this.Eliminar_todo.UseVisualStyleBackColor = true;
            this.Eliminar_todo.Click += new System.EventHandler(this.Eliminar_todo_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(33, 207);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 36;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // GInformacion
            // 
            this.GInformacion.Controls.Add(this.lbModelos);
            this.GInformacion.Location = new System.Drawing.Point(12, 3);
            this.GInformacion.Name = "GInformacion";
            this.GInformacion.Size = new System.Drawing.Size(181, 282);
            this.GInformacion.TabIndex = 51;
            this.GInformacion.TabStop = false;
            this.GInformacion.Text = "Infromación";
            // 
            // lbModelos
            // 
            this.lbModelos.FormattingEnabled = true;
            this.lbModelos.Location = new System.Drawing.Point(8, 19);
            this.lbModelos.Name = "lbModelos";
            this.lbModelos.Size = new System.Drawing.Size(167, 251);
            this.lbModelos.TabIndex = 0;
            // 
            // lblregistro
            // 
            this.lblregistro.AutoSize = true;
            this.lblregistro.Location = new System.Drawing.Point(337, 229);
            this.lblregistro.Name = "lblregistro";
            this.lblregistro.Size = new System.Drawing.Size(0, 13);
            this.lblregistro.TabIndex = 50;
            // 
            // dtBasicos
            // 
            this.dtBasicos.DataSetName = "dtBasicos";
            // 
            // gbPonerInfo
            // 
            this.gbPonerInfo.Controls.Add(this.btnCancelar);
            this.gbPonerInfo.Controls.Add(this.btnAceptar);
            this.gbPonerInfo.Controls.Add(this.txtColor);
            this.gbPonerInfo.Controls.Add(this.lblColor);
            this.gbPonerInfo.Controls.Add(this.txtModelo);
            this.gbPonerInfo.Controls.Add(this.lblModelo);
            this.gbPonerInfo.Location = new System.Drawing.Point(12, 3);
            this.gbPonerInfo.Name = "gbPonerInfo";
            this.gbPonerInfo.Size = new System.Drawing.Size(181, 282);
            this.gbPonerInfo.TabIndex = 52;
            this.gbPonerInfo.TabStop = false;
            this.gbPonerInfo.Text = "Infromación";
            this.gbPonerInfo.Visible = false;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(6, 58);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(45, 13);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(57, 55);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(105, 20);
            this.txtModelo.TabIndex = 1;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(56, 100);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(106, 20);
            this.txtColor.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(5, 103);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color:";
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(33, 79);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(75, 23);
            this.Modificar.TabIndex = 40;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(9, 146);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 23);
            this.btnAceptar.TabIndex = 46;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(98, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(64, 23);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Basicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 297);
            this.Controls.Add(this.gbPonerInfo);
            this.Controls.Add(this.GAcciones);
            this.Controls.Add(this.GInformacion);
            this.Controls.Add(this.lblregistro);
            this.Name = "Basicos";
            this.Text = "Basicos";
            this.Load += new System.EventHandler(this.Basicos_Load);
            this.GAcciones.ResumeLayout(false);
            this.GInformacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtBasicos)).EndInit();
            this.gbPonerInfo.ResumeLayout(false);
            this.gbPonerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GAcciones;
        private System.Windows.Forms.Button Bajar;
        private System.Windows.Forms.Button Subir;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Eliminar_todo;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.GroupBox GInformacion;
        private System.Windows.Forms.ListBox lbModelos;
        private System.Windows.Forms.Label lblregistro;
        private System.Data.DataSet dtBasicos;
        private System.Windows.Forms.GroupBox gbPonerInfo;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}