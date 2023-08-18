using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Xceed.Words.NET;
using System.Diagnostics;


namespace Liverpool_new.Class
{
    public class Etiquetas_Embarque
    {
        DataSet ListaTiendas = new DataSet();
        ControlTiendas DetalleTiendas = new ControlTiendas();
        List<int> tiendaspedido = new List<int>();
        List<string> contenedores = new List<string>();
        List<int> no_Contendor = new List<int>();
        List<int> max_Contendor = new List<int>();

        DocX oWordDoc;

        public string Crear_Etiquetas_Embarque(Dictionary<int, List<string>> tiendaContenedores, string pedido, string fecha, int eti_x_hoja = 8)
        {
            bool non = false;
            tiendaspedido.Clear(); // Limpiar lista tiendaspedido
            contenedores.Clear();
            no_Contendor.Clear();
            max_Contendor.Clear();
            foreach (var tc in tiendaContenedores)
            {
                int tienda = tc.Key;
                List<string> conte = tc.Value;
                int cantidadContenedores = conte.Count; // ver la cantidad de contendores
                int cont_Contendor = 1; //contador de contenedores
                foreach (string contenedor in conte)
                {
                    if(contenedor != "")
                    { 
                        tiendaspedido.Add(tienda); // Agregar número de tienda
                        contenedores.Add(contenedor); // Agregar contenedor
                        max_Contendor.Add(cantidadContenedores);
                        no_Contendor.Add(cont_Contendor);
                        cont_Contendor++;
                    }

                }
            }
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
                string ordenCompra = "";
                string fechaEntrega = "";
                for (int i = 2; i < lines.Count; i++)
                {
                    string[] columns = lines[i].Split(',');

                    ordenCompra = columns[0];
                    int tienda = int.Parse(columns[2]);
                    fechaEntrega = columns[17];
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
                if(ordenCompra != "" && fechaEntrega!= "")
                { 
                return Crear_Etiquetas_Embarque(tiendaContenedores, ordenCompra, fechaEntrega, 8);
                }
                else
                { if (ordenCompra == "")
                        return ("Hay un problema con la orden de compra");
                    else
                        return ("Hay un problema con la fecha de entrega");
                }


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
                    ReemplazarPlantilla(tiendaspedido[i],i+1);
                    for (int j = 1; j < max_eti; j++)
                    {
                        index += max;
                        ReemplazarPlantilla(tiendaspedido[index],index+1, "XX2", "YY2", "TIENDA2", "CONT-Y");
                        index += max;
                        InsertarPlantilla(plantilla1);
                        ReemplazarPlantilla(tiendaspedido[index], index + 1);
                    }
                    index += max;
                    ReemplazarPlantilla(tiendaspedido[index], index + 1, "XX2", "YY2", "TIENDA2", "CONT-Y");
                }
                index++;
                for (int i = index; i < tiendaspedido.Count - 1; i++)
                {
                    index = i;
                    InsertarPlantilla(plantilla1);
                    ReemplazarPlantilla(tiendaspedido[i],i+1);
                    i++;
                    ReemplazarPlantilla(tiendaspedido[i],i+1, "XX2", "YY2", "TIENDA2", "CONT-Y");
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
            catch (Exception ex) // Añade la variable ex para capturar la excepción
            {
                return "Ha ocurrido un error al generar el archivo: " + ex.Message + "\n" + ex.StackTrace;
            }

        }
        void InsertarPlantilla(string path)
        {
            using (DocX plantilla = DocX.Load(path))
            {
                // Encuentra el índice del último párrafo del documento actual
                int lastIndex = oWordDoc.Paragraphs.Count - 1;

                // Si el documento actual no está vacío, inserta un salto de página antes de la plantilla
                if (lastIndex >= 0)
                {
                    // Inserta un salto de página en el último párrafo del documento
                  //  oWordDoc.Paragraphs[lastIndex].Append("\n");
                }

                // Inserta el contenido de la plantilla al final del documento
                oWordDoc.InsertDocument(plantilla, true, false);
            }
        }


        void ReemplazarPlantilla(int no_tienda, int no_caja = 1, string rno_caja = "XX1", string rcant_caja = "YY1", string rtienda = "TIENDA1", string idContenedor = "CONT-X")
        {
            // BuscarReemplazar(rno_caja, no_caja.ToString("D2"));
            BuscarReemplazar(rno_caja, no_Contendor[no_caja - 1].ToString("D2"));
            BuscarReemplazar(rcant_caja,  max_Contendor[no_caja - 1].ToString("D2"));
            BuscarReemplazar(rtienda, no_tienda.ToString("D3") + "       " + DetalleTiendas.ObtenerNombre(no_tienda.ToString()));
            BuscarReemplazar(idContenedor, contenedores[no_caja - 1]); // Añadido para reemplazar el contenedor
        }


        string AbrirDocumento()
        {
            try
            {
                oWordDoc = DocX.Create("Documento.docx");
                DetalleTiendas.Iniciar(ListaTiendas);

                // Establecer márgenes personalizados
                oWordDoc.MarginLeft = 10; // margen izquierdo de 30 pt
                oWordDoc.MarginRight = 10; // margen derecho de 30 pt
                oWordDoc.MarginTop = 10; // margen superior de 30 pt
                oWordDoc.MarginBottom = 10; // margen inferior de 30 pt
                                            // Cambiar el tamaño del papel a Carta
                oWordDoc.PageWidth = 612; // Ancho del tamaño Carta en puntos (8.5 pulgadas)
                oWordDoc.PageHeight = 792; // Altura del tamaño Carta en puntos (11 pulgadas)
                return "";
            }
            catch (Exception ex)
            {
                return "No se pudo Abrir el archivo: " + ex.Message;
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
                string fullPath = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + path + ".docx");
                oWordDoc.SaveAs(fullPath);
                // Iniciar Microsoft Word y abrir el documento guardado
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "winword.exe";
                startInfo.Arguments = "\"" + fullPath + "\"";
                Process.Start(startInfo);

                return "Archivo Guardado en: " + fullPath;
            }
            catch { return ("No se ha podido guardar el archivo, presione enter y elija otro nombre"); }
        }

        void BuscarReemplazar(string buscar, string encontrado)
        {
            oWordDoc.ReplaceText(buscar, encontrado);

        }
    }
}
