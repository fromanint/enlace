using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Liverpool_new.Formularios;
using Liverpool_new.Class;

namespace Liverpool_new
{
    public partial class Principal : Form
    {
        public MainClass mc = new MainClass();


        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Operaciones.Hide();
            mc.CrearDirectorio();
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {

            About frm = new About();
            frm.Show();
        }

        private void btnTienda_Click(object sender, EventArgs e)
        {
            Tiendas frm = new Tiendas();
            frm.Show();
            Hide();
        }

        private void btnEmbarque_Click(object sender, EventArgs e)
        {
            Eti_Cajas frm = new Eti_Cajas();
            frm.Show();
            Hide();
        }

        private void btnPedidoExcel_Click(object sender, EventArgs e)
        {
            mc.Crear_Pedido();
        }

        private void btnEtiVestidos_Click(object sender, EventArgs e)
        {
           
        }



        private void txtPedido_Click(object sender, System.EventArgs e)
        {
            if (AbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string nopedido = mc.AbrirArchivo(AbrirArchivo.FileName);

                if (nopedido != "No es un archivo valido")
                {
                    txtPedido.Text = nopedido;
                    LlenarChecklistModelos();
                    Operaciones.Show();
                }
                else
                {
                    MessageBox.Show("No es un archivo valido");
                }
            }
        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
          
        }

        void LlenarChecklistModelos()
        {
            List<Modelo> modelos = mc.EliminarRepetidos(false,true);
            cmodelos.Items.Clear();
            for (int i = 0; i < modelos.Count()-1; i++)
            {
                if (!modelos[i + 1].Equals(modelos[i], false, false))
                {
                    cmodelos.Items.Add(modelos[i].ObtenerModelo());
                }
                else
                {
                    cmodelos.Items.Add(modelos[i].ObtenerModeloColor());
                }
                    
            }
            
        }
    }
}
