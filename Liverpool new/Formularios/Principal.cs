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
        public static MainClass mc = new MainClass();


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
            
        }

        private void btnEmbarque_Click(object sender, EventArgs e)
        {
            Eti_Cajas frm = new Eti_Cajas();
            frm.Show();
       
        }

        private void btnPedidoExcel_Click(object sender, EventArgs e)
        {
            string msg = mc.CrearPedidoExcel();
            MessageBox.Show(msg);
        }

        private void btnEtiVestidos_Click(object sender, EventArgs e)
        {
            List<string> modelos = new List<string> ();
            if (mc.Crear_Etiquetas())
            { MessageBox.Show("Archivos Creados"); }
            else
            { MessageBox.Show("No se han podido crear los archivos"); }

        }



        private void txtPedido_Click(object sender, System.EventArgs e)
        {

        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
          
        }
        //control para llenar la checklist de modelos
        void LlenarChecklistModelos()
        {
            List<Modelo> modelos = mc.EliminarRepetidos(false,true);
            cmodelos.Items.Clear();

                cmodelos.Items.Add(modelos[0].ObtenerModelo());

            for (int i = 0; i < modelos.Count()-1; i++)
            {
                if (!modelos[i + 1].Equals(modelos[i], false, false))
                {
                    cmodelos.Items.Add(modelos[i+1].ObtenerModelo());
                }
                else
                {
                    cmodelos.Items.Add(modelos[i+1].ObtenerModelo() +  " " + modelos[i+1].ObtenerColorChar());
                }    
            }       
            for (int i = 0; i < cmodelos.Items.Count; i++)
            { cmodelos.SetItemChecked(i, true); }

        }

        private void cmodelos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            List<string> pedidos = new List<string>();
            if (AbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                //string nopedido = mc.AbrirArchivo(AbrirArchivo.FileName);
                List<string> nopedido = mc.AbrirArchivo(AbrirArchivo.FileName);
                if (nopedido.Count != 0)
                {
                    foreach (string s in nopedido)
                    { 
                    cbPedidos.Items.Add(s);
                    
                    }
                    cbPedidos.SelectedIndex = 0;

                    LlenarChecklistModelos();
                    
                    Operaciones.Show();
                    InfoBox.Show();
                }
                else
                {
                    Operaciones.Hide();
                    InfoBox.Hide();
                    MessageBox.Show("No es un archivo valido");
                }
            }
        }

        private void cbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBasicos_Click(object sender, EventArgs e)
        {
            Basicos frm = new Basicos();
            frm.Show();
        }
    }
}
