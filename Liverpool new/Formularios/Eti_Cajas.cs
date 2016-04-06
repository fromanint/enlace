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
    public partial class Eti_Cajas : Form
    {
        
        public Eti_Cajas()
        {
            InitializeComponent();
        }

        private void Eti_Cajas_Load(object sender, EventArgs e)
        {
            ListaTiendas.Items.Clear();
            List<int> pedido = Principal.mc.pedido.Select(x => x.ObtenerTienda()).Distinct().ToList(); 

            for (int i =0; i<=pedido.Count-1;i++)
            {
                int tienda = pedido[i]; 
                ListaTiendas.Items.Add(tienda.ToString());
                ListaTiendas.SetItemChecked(i, true);
            }
        }
        //seleccionar todo
        private void check_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= ListaTiendas.Items.Count - 1; i++)
            {
                ListaTiendas.SetItemChecked(i, true);
            }
        }

        private void uncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= ListaTiendas.Items.Count - 1; i++)
            {
                ListaTiendas.SetItemChecked(i, false);
            }
        }

        private void Generar_Click(object sender, EventArgs e)
        {
            Control_Eti_Cajas cec = new Control_Eti_Cajas();
            List<int> listaTiendas = new List<int>();
         
            for (int i = 0; i <= ListaTiendas.Items.Count - 1; i++)
            {
                if (ListaTiendas.GetItemCheckState(i) == CheckState.Checked)
                {
                    listaTiendas.Add(int.Parse(ListaTiendas.Items[i].ToString()));
                  //  listaTiendas.Add(int.Parse(ListaTiendas.SelectedValue.ToString()));
                }
            }
            string msg = cec.Crear_Etiquetas_Embarque(listaTiendas, Principal.mc.pedido[0].GetNoPedido(),fechaa.Value.ToString("dd-MM-yy"));
            MessageBox.Show(msg);
        }
    }
}
