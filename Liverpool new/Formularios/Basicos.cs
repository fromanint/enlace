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
    public partial class Basicos : Form
    {

        ControlBasicos cb = new ControlBasicos();
        List<Modelo> modelos = new List<Modelo>();
        int index = -1;
        void ImprimirResultado(bool limpiar =true)
        {
            if (limpiar)
            { modelos = cb.ListaBasicos(); }

            lbModelos.Items.Clear();
            foreach (Modelo mod in modelos)
            {
                lbModelos.Items.Add(mod.ObtenerModelo() + mod.ObtenerColorChar());
            }
        }

        public Basicos()
        {
            InitializeComponent();
        }

        private void Basicos_Load(object sender, EventArgs e)
        {
            cb.Iniciar(dtBasicos);
            ImprimirResultado();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            gbPonerInfo.Show();                       
            txtColor.Text = "";
            txtModelo.Text = "";
            index = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            gbPonerInfo.Hide();
            if (index == -1) //nuevo
            {
                string exito = cb.Nuevo(txtModelo.Text, txtColor.Text);
                   
                if (exito != "")
                {
                    MessageBox.Show(exito);
                   
                    //ImprimeResultado();
                }
                else
                {
                    ImprimirResultado();
                    MessageBox.Show("Se ha agregado correctamente");
                }

            }
            else
            {
                //ct.Modificar(txtNo_tienda.Text, CBTipo.Text, txtNombre.Text, index);
                //txtNo_tienda.Enabled = false;
            }
            index = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbPonerInfo.Hide();
            index = -1;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string msg = cb.Guardar(modelos);
            MessageBox.Show(msg);
        }

        private void Eliminar_todo_Click(object sender, EventArgs e)
        {
            cb.Vaciar();
            ImprimirResultado();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            cb.Eliminar(lbModelos.SelectedIndex);
            ImprimirResultado();
        }

        private void Subir_Click(object sender, EventArgs e)
        {

            int selectedIndex = lbModelos.SelectedIndex;
            if (selectedIndex > 0)
            {
                Modelo mod = modelos[selectedIndex];
                modelos.RemoveAt(selectedIndex);
                modelos.Insert(selectedIndex-1, mod);
            }
            ImprimirResultado(false);
            lbModelos.SetSelected(selectedIndex - 1,true);
        }

        private void Bajar_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbModelos.SelectedIndex;
            if (selectedIndex < lbModelos.Items.Count - 1 & selectedIndex != -1)
            {
                Modelo mod = modelos[selectedIndex];
                modelos.RemoveAt(selectedIndex);
                modelos.Insert(selectedIndex + 1, mod);
                ImprimirResultado(false);
                lbModelos.SetSelected(selectedIndex + 1, true);

            }
            
        }
    }
}
