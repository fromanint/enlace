using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Word = Microsoft.Office.Interop.Word;

namespace Liverpool_new.Class
{
    public class Control_Eti_Cajas
    {
        Object oMissing = System.Reflection.Missing.Value;
        //OBJECTS OF FALSE AND TRUE
        Object oTrue = true;
        Object oFalse = false;

        //CREATING OBJECTS OF WORD AND DOCUMENT
        Word.Application oWord = new Word.Application();
        Word.Document oWordDoc;
        Word.Range rng;



        DataSet ListaTiendas = new DataSet();
        ControlTiendas DetalleTiendas = new ControlTiendas();
        List<int> tiendaspedido = new List<int>();

        public string Crear_Etiquetas_Embarque(List<int> tiendas, string pedido, string fecha, int eti_x_hoja= 8)
        {
            bool non= false;
            tiendaspedido = tiendas;
            int repeticiones = (tiendaspedido.Count-1)/eti_x_hoja;
            string msg = "";
            if (tiendaspedido.Count % 2 != 0)
            {
                non=true;
            }
            msg = AbrirDocumento();
            if (msg == "")
            {
                msg = CrearDocumento(pedido, fecha,non, repeticiones);
            
                if (msg == "")
                {
                    msg = GuardarDocumento(pedido);
                }
            }
            return msg;
        }

        string CrearDocumento(string pedido, string fecha, bool non, int max, int max_eti = 4) {
            try { 
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
            for (int i = index; i < tiendaspedido.Count-1; i++)
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
                ReemplazarPlantilla(tiendaspedido[tiendaspedido.Count-1]);
            }
                BuscarReemplazar("DD-MM-AA", fecha);
                BuscarReemplazar("12345678", pedido);
                return "";
            }
            catch { return "Ha ocurrido un error al generar el archivo"; }

        }

        void InsertarPlantilla(string path)
        {
            rng.InsertFile(path, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            object start = oWordDoc.Content.End -1;
            object end = oWordDoc.Content.End;
            rng = oWordDoc.Range(ref start, ref end);
        }

        void ReemplazarPlantilla(int no_tienda, string rno_caja = "XX1", string rcant_caja= "YY1", string rtienda = "TIENDA1" ,int no_caja = 1, int cant_cajas = 1) {
            BuscarReemplazar(rno_caja, no_caja.ToString("D2"));
            BuscarReemplazar(rcant_caja, cant_cajas.ToString("D2"));
            BuscarReemplazar(rtienda, no_tienda.ToString("D3") + "       " + DetalleTiendas.ObtenerNombre(no_tienda.ToString()));
        }

        string AbrirDocumento()
        {
            try
            { int posx = 14, posy = 14;
                oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                oWordDoc.Activate();
                oWordDoc.PageSetup.LeftMargin = posx;
                oWordDoc.PageSetup.RightMargin = 9;
                oWordDoc.PageSetup.BottomMargin = posx;
                oWordDoc.PageSetup.TopMargin = posy;
                oWordDoc.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;
                object start = oWordDoc.Content.Start;
                object end = oWordDoc.Content.End;
                oWord.Visible = true;
                rng = oWordDoc.Range(ref start, ref end);
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
                oWordDoc.SaveAs2(System.Windows.Forms.Application.StartupPath + path, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                return "Archivo Guardado en: " + path + ".docx";
            }
            catch { return ("No se ha podido guardar el archivo presione enter y elija otro nombre"); }
            
        }
        void BuscarReemplazar(string buscar, string encontrado)
        {

            Word.Find findObject = oWord.Selection.Find;
            findObject.ClearFormatting();
            findObject.Text = buscar;
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = encontrado;
            object replaceAll = Word.WdReplace.wdReplaceAll;
            findObject.Execute(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref replaceAll, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

        }
    }
}
