using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Liverpool_new.Class
{
    public class HojaPedidoExcel
    {
        enum celdas
        {
            A = 1, B, C, D, E, F, G, H, I, J, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
            AA, AB, AC, AD, AE, AF, AG, AH, AI, AJ, AL, AM, AN, AO, AP, AQ, AR, AS, AT, AU, AV, AW, AX, AY, AZ,
            BA, BB, BC, BD, BE, BF, BG, BH, BI, BJ, BL, BM, BN, BO, BP, BQ, BR, BS, BT, BU, BV, BW, BX, BY, BZ
        };

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel._Worksheet xlWorkSheet;
        Excel.Range rng;
        object misValue = System.Reflection.Missing.Value;

        List<Pedido> pedido = new List<Pedido>();
 
        Dictionary<int, string> encabezado = new Dictionary<int, string>();

        public string Iniciar(List<Pedido> ped,List<Modelo> mod) {
            string msg = "";
            pedido = ped;
            msg = AbrirDocumento();
            if (msg == "")
            {
                msg = CrearDocumento(mod);
                if (msg == "")
                {
                    msg = GuardarDocumento(pedido[0].GetNoPedido());
                }
            }
            
            //Obtenerceldas por numero
            /*celdas cel = (celdas)1;
            Console.Write(cel);*/
            return msg;
        }


        string CrearDocumento(List<Modelo> modelo)
        {
            try{
                CrearEncabezado(modelo);

                return "";
            }catch { return "No se ha podido generar el contenido"; }
            
        }

        string GuardarDocumento(string pedido)
        {

            try
            {
                MainClass mc = new MainClass();
                string path = "\\Output\\" + pedido;
                mc.CrearDirectorio(path);
                path += "\\" + pedido;
                
                xlWorkBook.SaveAs(System.Windows.Forms.Application.StartupPath + path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                return "Archivo Guardado en: " + path + ".xlsx";
            }
            catch { return ("No se ha podido guardar el archivo presione enter y elija otro nombre"); }

        }
        string AbrirDocumento()
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlApp.Visible = true;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.ActiveSheet;//.Worksheets.get_Item(1);
                return "";
            }
            catch
            {
                return "No se pudo Abrir el archivo";
            }
        }

        //Funciones para el contenido
        List<int> CrearEncabezado(List<Modelo> modelo) {
            List<int> ColumnaNegra = new List<int>();
            int j = 3;
            encabezado.Add(1, "Tienda");           
            encabezado.Add(2, "");
            ColumnaNegra.Add(2);
            for (int i = 0; i < modelo.Count - 1; i++,j++)
            {
                encabezado.Add(j, modelo[i].ObtenerTalla());
                j++;
                i++;
                try
                {
                    while (modelo[i].Equals(modelo[i - 1], false, true))
                    {
                        encabezado.Add(j, modelo[i].ObtenerTalla());
                        i++;
                        j++;
                    }
                }
                catch { }
               
                i--;
                encabezado.Add(j, modelo[i].ObtenerModelo() + modelo[i].ObtenerColorChar());
                ColumnaNegra.Add(j-1);
                
            }

            for (int i = 0; i < encabezado.Count - 1; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = encabezado.; 
            }

            return ColumnaNegra;
        }

    }
}
