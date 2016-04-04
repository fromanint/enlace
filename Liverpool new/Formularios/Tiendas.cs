using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liverpool_new.Formularios
{


    public partial class Tiendas : Form
    {

        DataTable tablatiendas;
        int apunta = 0;
        public Tiendas()
        {
            InitializeComponent();
        }

        private void Tiendas_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = "Resources\\Listatiendas.xml";
                ListaTiendas.ReadXml(filePath);
                tablatiendas = ListaTiendas.Tables[0];
                tablatiendas.Columns[0].Unique = true;
                tablatiendas.Columns[0].AllowDBNull = false;
                tablatiendas.Columns[0].ReadOnly = true;
                apunta = 0;
                ImprimeResultado();
                GInformacion.Enabled = false;
            }
            catch
            {
                MessageBox.Show("No se ha podido cargar el archivo que contiene las tiendas");
                Gcontrol.Hide();
            }


        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }




        private void ImprimeResultado()
        {
            try
            {
                txtNo_tienda.Text = tablatiendas.Rows[apunta][0].ToString();
                CBTipo.Text = tablatiendas.Rows[apunta][1].ToString();
                txtNombre.Text = tablatiendas.Rows[apunta][2].ToString();
                if (apunta == 0)
                {
                    Anterior.Enabled = false;
                    siguiente.Enabled = true;
                }
                else
                {
                    if (apunta == tablatiendas.Rows.Count - 1)
                    {
                        siguiente.Enabled = false;
                        Anterior.Enabled = true;
                    }
                    else
                    {
                        Anterior.Enabled = true;
                        siguiente.Enabled = true;
                    }
                }
                lblregistro.Text = (apunta + 1) + " de: " + tablatiendas.Rows.Count.ToString();
            }
            catch
            {
                Nuevo.Visible = true;
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            GControles2.Show();
            GInformacion.Enabled = true;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            GControles2.Hide();
            GInformacion.Enabled = false;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            GControles2.Hide();
            GInformacion.Enabled = false;
        }
    }
}
