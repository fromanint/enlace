using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Liverpool_new.Class;

namespace Liverpool_new.Formularios
{


    public partial class Tiendas : Form 
    {
        ControlTiendas ct = new ControlTiendas();
        int index;
        bool nuevo = false;

        public Tiendas()
        {
            InitializeComponent();
        }

        private void Tiendas_Load(object sender, EventArgs e)
        {
            if (ct.Iniciar(ListaTiendas))
            {
                ImprimeResultado();
                GInformacion.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el archivo que contiene las tiendas");
                GControles2.Show();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }

        private void ImprimeResultado()
        {
            try
            {
                txtNo_tienda.Text = ct.ObtenerNumero(index);
                CBTipo.Text = ct.ObtenerTipo(index);
                txtNombre.Text = ct.ObtenerNombre(index);
                if (index == 0)
                {
                    Anterior.Enabled = false;
                    Siguiente.Enabled = true;
                }
                else
                {
                    if (index == ct.TotalTiendas()-1)
                    {
                        Siguiente.Enabled = false;
                        Anterior.Enabled = true;
                    }
                    else
                    {
                        Anterior.Enabled = true;
                        Siguiente.Enabled = true;
                    }
                }
               lblReg.Text = (index + 1) + " de: " + ct.TotalTiendas();
            }
            catch
            {
                lblReg.Text = (index + 1) + " de: " + ct.TotalTiendas();
                
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            GControles2.Show();
            GInformacion.Enabled = true;
            CBTipo.SelectedIndex = 0;
            txtNombre.Text = "";
            txtNo_tienda.Text = "";
            nuevo = true;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            GControles2.Hide();
            GInformacion.Enabled = false;
            if (nuevo)
            {
                string exito = ct.Nuevo(txtNo_tienda.Text,CBTipo.Text,txtNombre.Text);
                if (exito != "")
                {
                    MessageBox.Show(exito);
                    ImprimeResultado();
                }
                else
                {
                    lblReg.Text = (index + 1) + " de: " + ct.TotalTiendas();
                    MessageBox.Show("Se ha agregado correctamente");
                }
                
            }
            else {
                ct.Modificar(txtNo_tienda.Text, CBTipo.Text, txtNombre.Text,index);
                txtNo_tienda.Enabled = false;
            }
            
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            GControles2.Hide();
            GInformacion.Enabled = false;
            if (nuevo)
            {
                index = 0;
                ImprimeResultado();
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            GControles2.Show();
            GInformacion.Enabled = true;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            int aux = ct.Buscar(txtbuscar.Text);
            if (aux != -1)
            {
                index = aux;
                ImprimeResultado();
            }
            else
            {
                MessageBox.Show("Tienda no Encontrada");
            }
        }

        private void Primero_Click(object sender, EventArgs e)
        {
            index = 0;
            ImprimeResultado();
        }

        private void Anterior_Click(object sender, EventArgs e)
        {
            index--;
            ImprimeResultado();
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            index++;
            ImprimeResultado();
        }

        private void Ultimo_Click(object sender, EventArgs e)
        {
            index = ct.TotalTiendas() - 1;
            ImprimeResultado();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string aux = ct.ObtenerNumero(index);
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar la tienda: " + aux, "AVISO:", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                index = ct.Eliminar(index);
                if(index == -1)
                {
                    index = 0;
                }
                ImprimeResultado();
                MessageBox.Show("La tienda " + aux + " se ha eliminado");
              
            }
        }

        private void Eliminar_todo_Click(object sender, EventArgs e)
        {
            string aux = ct.ObtenerNumero(index);
            DialogResult result = MessageBox.Show("Se  van a eliminar todas las tiendas seguro que desea hacerlo:", "AVISO", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ct.Vaciar();
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string msg = ct.Guardar();
            MessageBox.Show(msg);
        }

        private void Tiendas_FormClosing(object sender, EventArgs e)
        {
            string aux = ct.ObtenerNumero(index);
            DialogResult result = MessageBox.Show("Guardar los cambios realizados:", "AVISO", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                MessageBox.Show(ct.Guardar());
            }
        }
        
    }
}
