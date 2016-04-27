using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Liverpool_new.Class
{
    class ControlBasicos
    {

        DataTable tablaBasicos;
        string filePath = "Resources\\Listabasicos.xml";
        public bool Iniciar(DataSet listabasicos)
        {
            try
            {
                
                
                listabasicos.ReadXml(filePath);
                DataTable dt = listabasicos.Tables[0];
                dt.Columns[0].Unique = true;
                dt.Columns[0].AllowDBNull = false;
                dt.Columns[0].ReadOnly = true;

                tablaBasicos = dt.Clone();
                //change data type of column
                tablaBasicos.Columns[0].DataType = typeof(Int32);
                //import row to cloned datatable
                foreach (DataRow row in dt.Rows)
                {
                    tablaBasicos.ImportRow(row);
                }
                return true;
            }
            catch
            {
                return false;

            }
        }

        bool VerificarDatos(string modelo, string color)
        {
            return modelo != "" && color != "";
        }

        int Buscar(string modelo, string color) {
            for (int i = 0; i <= tablaBasicos.Rows.Count - 1; i++)
            {
                if (tablaBasicos.Rows[i][1].ToString().Equals(modelo) && tablaBasicos.Rows[i][2].ToString().Equals(color))
                {
                    return i;
                }
            }

            return -1;
        }

        public List<Modelo> ListaBasicos() {
            List<Modelo> basicos = new List<Modelo>();
            foreach (DataRow mod in tablaBasicos.Rows)
            {
                Modelo modelo = new Modelo(mod[1].ToString(), mod[2].ToString());
                basicos.Add(modelo);
            }
            return basicos;
        }

        public List<string> ListaBasicosString() {
            List<string> basicos = new List<string>();
            foreach (DataRow mod in tablaBasicos.Rows)
            {
                string s1 = mod[1].ToString();
                string s2= mod[2].ToString();
                basicos.Add(s1+s2[0]);
            }
            return basicos;
        }

        public string Guardar(List<Modelo> modelos)
        {
            tablaBasicos.Rows.Clear();
            for (int i = 0; i < modelos.Count; i++)
            {
                DataRow nuevafila = tablaBasicos.NewRow();
                nuevafila[0] = i+1;
                nuevafila[1] = modelos[i].ObtenerModelo();
                nuevafila[2] = modelos[i].ObtenerColor();
                tablaBasicos.Rows.Add(nuevafila);
            }
            try
            {
                tablaBasicos.WriteXml(filePath);
                return "Se ha guardado las tiendas correctamente";
            }
            catch
            {
                return "No se han podido guardar las tiendas";
            }
        }

        public string Modificar(string modelo, string color, int index)
        {
            if (VerificarDatos(modelo, color))
            {
                tablaBasicos.Rows[index][1] = modelo;
                tablaBasicos.Rows[index][2] = color;
                return "";
            }
            else
            {
                return "No se han insertado todos los datos";
            }
        }

        public string Nuevo(string modelo, string color)
        {
            if (VerificarDatos(modelo,color))
            {
                if (Buscar(modelo,color) == -1)
                {
                    DataRow nuevafila = tablaBasicos.NewRow();
                    nuevafila[0] = tablaBasicos.Rows.Count+1;
                    nuevafila[1] = modelo;
                    nuevafila[2] = color;
                    try
                    {
                        tablaBasicos.Rows.Add(nuevafila);
                        DataView dv = new DataView(tablaBasicos);
                        dv.Sort = "Orden";
                        DataTable dt = dv.ToTable();
                        tablaBasicos = dt;
                        return "";
                    }
                    catch
                    {
                        return "Ha ocurrido un error a la hora de insertar";
                    }

                }
                else
                {
                    return "La tienda esta repetida";
                }
            }
            else
            {
                return "No se han insertado todos los datos";
            }
        }

        public int Eliminar(int index)
        {
            tablaBasicos.Rows[index].Delete();
            return index - 1;
        }

        public void Vaciar()
        {
            tablaBasicos.Clear();
        }



    }

}
