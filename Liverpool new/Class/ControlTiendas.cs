using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Liverpool_new.Class
{
    public class ControlTiendas
    {
        DataTable tablatiendas;
        public bool Iniciar(DataSet listaTiendas) {
            try
            {
                string filePath = "Resources\\Listatiendas.xml";
                listaTiendas.ReadXml(filePath);
                tablatiendas = listaTiendas.Tables[0];
                tablatiendas.Columns[0].Unique = true;
                tablatiendas.Columns[0].AllowDBNull = false;
                tablatiendas.Columns[0].ReadOnly = true;
                return true;
            }
            catch
            {
                return false;
              
            }
        }

        public string ObtenerNumero(int index) {
            return tablatiendas.Rows[index][0].ToString();
        }

        public string ObtenerTipo(int index)
        {
            return tablatiendas.Rows[index][1].ToString();
        }

        public string ObtenerNombre(int index)
        {
            return tablatiendas.Rows[index][2].ToString();
        }

        public int TotalTiendas()
        {
            return tablatiendas.Rows.Count;
        }

        public string Nuevo(string no_tienda, string tipo, string nombre)
        {
            if (VerificarDatos(no_tienda, tipo, nombre))
            {
                if (Buscar(no_tienda) == -1)
                {
                    DataRow nuevafila = tablatiendas.NewRow();
                    nuevafila[0] = no_tienda;
                    nuevafila[1] = tipo;
                    nuevafila[2] = nombre;
                    try {
                        tablatiendas.Rows.Add(nuevafila);
                        DataView dv = new DataView(tablatiendas);
                        dv.Sort = "No_tienda";
                        DataTable dt = dv.ToTable();
                        tablatiendas = dt;
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

        public string Modificar(string no_tienda,string tipo, string nombre, int index)
        {
           if (VerificarDatos(no_tienda, tipo, nombre))
            {
                tablatiendas.Rows[index][1] = tipo;
                tablatiendas.Rows[index][2] = nombre;
                return "";
            }
            else
            {
                return "No se han insertado todos los datos";
            }
        }
    

        private bool VerificarDatos(string no_tienda, string tipo, string nombre)
        {
            return no_tienda != "" && tipo != "" && nombre != "";
        }

        public int Buscar(string no_tienda)
        {
            
            for (int i = 0; i <= tablatiendas.Rows.Count - 1; i++)
            {
                if (tablatiendas.Rows[i][0].ToString() == no_tienda)
                {
                    return i;
                }
            }

            return -1;
        }

        public string Guardar() {
            try
            {

                tablatiendas.WriteXml("Resources\\Listatiendas.xml");
                return "Se ha guardado las tiendas correctamente";
            }
            catch
            {
                return "No se han podido guardar las tiendas";
            }

            
            

        }

        public int Eliminar(int index)
        {
            tablatiendas.Rows[index].Delete();
            return index - 1;
        }

        public void Vaciar()
        {
            tablatiendas.Clear();
        }
    }
}
