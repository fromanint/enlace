using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Xceed.Words.NET;

namespace Liverpool_new.Class
{
    public class Etiquetas_Embarque
    {
        DataSet ListaTiendas = new DataSet();
        ControlTiendas DetalleTiendas = new ControlTiendas();
        List<int> tiendaspedido = new List<int>();

        DocX oWordDoc;

        public string Crear_Etiquetas_Embarque(List<int> tiendas, string pedido, string fecha, int eti_x_hoja = 8)
        {
            bool non = false;
            tiendaspedido = tiendas;
            int repeticiones = (tiendaspedido.Count - 1) / eti_x_hoja;
            string msg = "";
            if (tiendaspedido.Count % 2 != 0)
            {
                non = true;
            }
            msg = AbrirDocumento();
            if (msg == "")
            {
                msg = CrearDocumento(pedido, fecha, non, repeticiones);

                if (msg == "")
                {
                    msg = GuardarDocumento(pedido);
                }
            }
            return msg;
        }

        public string LeerArchivoCSV(string rutaArchivoCSV)
        {
            try
            {
                List<string> lines = File.ReadAllLines(rutaArchivoCSV).ToList();
                Dictionary<int, List<string>> tiendaContenedores = new Dictionary<int, List<string>>();

                for (int i = 2; i < lines.Count; i++)
                {
                    string[] columns = lines[i].Split(',');

                    int ordenCompra = int.Parse(columns[0]);
                    int tienda = int.Parse(columns[2]);
                    string fechaEntrega = columns[11];
                    string contenedor = columns[15];

                    if (!tiendaContenedores.ContainsKey(tienda))
                    {
                        tiendaContenedores[tienda] = new List<string>();
                    }

                    if (!tiendaContenedores[tienda].Contains(contenedor))
                    {
                        tiendaContenedores[tienda].Add(contenedor);
                    }
                }

                tiendaspedido.Clear();
                foreach (var item in tiendaContenedores)
                {
                    tiendaspedido.Add(item.Key);

                }

                return "";
            }
            catch (Exception ex)
            {
                return "Error al leer el archivo CSV: " + ex.Message;
            }
        }



        string CrearDocumento(string pedido, string fecha, bool non, int max, int max_eti = 4)
        {
            try
            {
                string plantilla1 = System.Windows.Forms.Application.StartupPath.ToString() + "\\Resources\\Plantillas\\PLANTILLA1.dotx";
                string plantilla2 = System.Windows.Forms.Application.StartupPath.ToString() + "\\Resources\\Plantillas\\PLANTILLA2.dotx";
                int index = 0;
                for (int i = 0; i < max; i++)
                {
                    index = i;
                    InsertarPlantilla(plantilla1);
                    ReemplazarPlantilla(tiendaspedido[i]);
                    for (int j = 1; j < max_eti; j++)
                    {
                        index += max;
                        ReemplazarPlantilla(tiendaspedido[index], "XX2", "YY2", "TIENDA2");
                        index += max;
                        InsertarPlantilla(plantilla1);
                        ReemplazarPlantilla(tiendaspedido[index]);
                    }
                    index += max;
                    ReemplazarPlantilla(tiendaspedido[index], "XX2", "YY2", "TIENDA2");
                }
                index++;
                for (int i = index; i < tiendaspedido.Count - 1; i++)
                {
                    index = i;
                    InsertarPlantilla(plantilla1);
                    ReemplazarPlantilla(tiendaspedido[i]);
                    i++;
                    ReemplazarPlantilla(tiendaspedido[i], "XX2", "YY2", "TIENDA2");
                }
                if (non)
                {
                    InsertarPlantilla(plantilla2);
                    ReemplazarPlantilla(tiendaspedido[tiendaspedido.Count - 1]);
                }
                BuscarReemplazar("DD-MM-AA", fecha);
                BuscarReemplazar("12345678", pedido);
                return "";
            }
            catch { return "Ha ocurrido un error al generar el archivo"; }

        }
        void InsertarPlantilla(string path)
        {
            using (DocX plantilla = DocX.Load(path))
            {
                oWordDoc.InsertDocument(plantilla, false);
            }
        }

        void ReemplazarPlantilla(int no_tienda, string rno_caja = "XX1", string rcant_caja = "YY1", string rtienda = "TIENDA1", int no_caja = 1, int cant_cajas = 1)
        {
            BuscarReemplazar(rno_caja, no_caja.ToString("D2"));
            BuscarReemplazar(rcant_caja, cant_cajas.ToString("D2"));
            BuscarReemplazar(rtienda, no_tienda.ToString("D3") + "       " + DetalleTiendas.ObtenerNombre(no_tienda.ToString()));
        }

        string AbrirDocumento()
        {
            try
            {
                oWordDoc = DocX.Create("Documento.docx");
                DetalleTiendas.Iniciar(ListaTiendas);
                return "";
            }
            catch
            {
                return "No se pudo Abrir el archivo";
            }
        }

        string GuardarDocumento(string pedido)
        {
            try
            {
                MainClass mc = new MainClass();
                string path = "Output\\" + pedido;
                mc.CrearDirectorio(path);
                path = "\\" + path + "\\" + pedido;
                oWordDoc.SaveAs(System.Windows.Forms.Application.StartupPath + path + ".docx");
                return "Archivo Guardado en: " + path + ".docx";
            }
            catch { return ("No se ha podido guardar el archivo, presione enter y elija otro nombre"); }
        }

        void BuscarReemplazar(string buscar, string encontrado)
        {
            oWordDoc.ReplaceText(buscar, encontrado);

        }
    }
}
