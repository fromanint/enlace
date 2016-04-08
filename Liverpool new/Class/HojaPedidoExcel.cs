using System;
using System.Collections.Generic;
using System.Data;
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
            A = 1, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
            AA, AB, AC, AD, AE, AF, AG, AH, AI, AJ, AK, AL, AM, AN, AO, AP, AQ, AR, AS, AT, AU, AV, AW, AX, AY, AZ,
            BA, BB, BC, BD, BE, BF, BG, BH, BI, BJ, BK, BL, BM, BN, BO, BP, BQ, BR, BS, BT, BU, BV, BW, BX, BY, BZ
        };

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel._Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;

        List<Pedido> pedido = new List<Pedido>();
        List<Modelo> modelo = new List<Modelo>();

        int renglon; //Guardar el ultimo renglon
        //diccionario columna de excel , (string poner excel(talla), string modelo no+ char);
        Dictionary<int, Tuple<string,string>> encabezado = new Dictionary<int, Tuple<string, string>>();

        public string Iniciar(List<Pedido> ped,List<Modelo> mod) {
            string msg = "";
            pedido = ped;
            modelo = mod;
            msg = AbrirDocumento();
            if (msg == "")
            {
                msg = CrearDocumento();
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


        string CrearDocumento()
        {
            string msg = "";
            msg = CrearContenido();
            return msg;
           
            
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

        string CrearContenido (){
            string msg = "";
            List<int> ColumnaNegra=CrearEncabezado(modelo);
            List<int> RenglonColor=LlenarTiendas();
            SacarTotales();
            DarFormato(ColumnaNegra,RenglonColor);
            return msg;
    }
        List<int> CrearEncabezado(List<Modelo> modelo) {
            List<int> ColumnaNegra = new List<int>();
            int j = 3;
            encabezado.Add(1, Tuple.Create("Tienda",""));           
            encabezado.Add(2, Tuple.Create("",""));
            ColumnaNegra.Add(2);
            for (int i = 0; i < modelo.Count - 1; i++,j++)
            {

                encabezado.Add(j, Tuple.Create(modelo[i].ObtenerTalla(), modelo[i].ObtenerModelo() + modelo[i].ObtenerColorChar()));
                j++;
                i++;
                try
                {
                    while (modelo[i].Equals(modelo[i - 1], false, true))
                    {
                        encabezado.Add(j, Tuple.Create(modelo[i].ObtenerTalla(), modelo[i].ObtenerModelo() + modelo[i].ObtenerColorChar()));
                        i++;
                        j++;
 
                    }
                }
                catch { }
               
                i--;
                
                encabezado.Add(j, Tuple.Create(modelo[i].ObtenerModelo() + modelo[i].ObtenerColorChar(),""));
                ColumnaNegra.Add(j);
                
            }
            encabezado.Add(j, Tuple.Create("Total", ""));
            j++;
            encabezado.Add(j, Tuple.Create("Cajas", ""));
            int renglon =0;
            foreach (var en in encabezado)
            {
                renglon++;
                xlWorkSheet.Cells[1, renglon] = en.Value.Item1;
            }

            return ColumnaNegra;
        }

        List<int> LlenarTiendas()
        {
            List<int> RenglonColor = new List<int>();
            ControlTiendas ct = new ControlTiendas();
            DataSet tipotiend = new DataSet();
            ct.Iniciar(tipotiend);
            int no_renglon = 2;
            int no_columna = 1;
            for (int i = 0; i < pedido.Count-1; i++, no_renglon++)
            {
                no_columna = 1;
                xlWorkSheet.Cells[no_renglon, no_columna] = pedido[i].ObtenerTienda();
                no_columna++;
                string tipo = ct.ObtenerTipo(pedido[i].ObtenerTienda().ToString());
                xlWorkSheet.Cells[no_renglon, no_columna] = tipo;
                //Agregar columnas Fabricas
                if (tipo == "f" || tipo == "F")
                {
                    RenglonColor.Add(no_renglon);
                }
               
                try
                {
                    while (pedido[i].Equals(pedido[i + 1], true))
                    {
                        no_columna = BuscarColumnaModeloTalla(pedido[i].ObtenerModelo() + pedido[i].ObtenerColorChar(), pedido[i].ObtenerTalla());
                        xlWorkSheet.Cells[no_renglon, no_columna] = pedido[i].ObtenerCantidad();
                        i++;
                    }
                }
                catch { }

                    if (pedido[i].Equals(pedido[i - 1], true))
                    {
                        no_columna = BuscarColumnaModeloTalla(pedido[i].ObtenerModelo() + pedido[i].ObtenerColorChar(), pedido[i].ObtenerTalla());
                        xlWorkSheet.Cells[no_renglon, no_columna] = pedido[i].ObtenerCantidad();
                    }
        



            }
            renglon = no_renglon;
            return RenglonColor;
        }

        int BuscarColumnaModeloTalla(string mod, string tall)
        {
            int i = 1;
            foreach (var en in encabezado)
            {
                if (tall.Equals(en.Value.Item1) && mod.Equals(en.Value.Item2))
                {
                    return i; 
                }
                i++;
            }
            return 0;
        }

        int BuscarColumna(string buscar)
        {
            int i = 1;
            foreach (var en in encabezado)
            {
                if (buscar.Equals(en.Value.Item1))
                {
                    return i;
                }
                i++;
            }
            return 0;
        } 

        void SacarTotales()
        {
            int no_columna = BuscarColumna("Total");
            
            //total por tienda
            for (int i = 2;  i < renglon; i++)
            {
                xlWorkSheet.Cells[i, no_columna].FormulaLocal = "=SUMA(" + (celdas)3 + i + ":"+(celdas)(no_columna-2)+i+")";
                xlWorkSheet.Cells[i, no_columna+1].FormulaLocal = "=si(" + (celdas)(no_columna) + i + "<5,\"M\",si(" + (celdas)(no_columna) + i + "<20,\"I\",\"G\"))";                
            }

            //total por modelo
            for (int i = 3; i < no_columna; i++)
            {
                xlWorkSheet.Cells[renglon, i].FormulaLocal = "=SUMA(" + (celdas)i  + "2:" + (celdas)i + (renglon-1) + ")";  
            }
            //total liverpool
            renglon++;
            xlWorkSheet.Cells[renglon, 2] = "liv";
            xlWorkSheet.Cells[renglon, 2].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            for (int i = 3; i < no_columna; i++)
            {
                xlWorkSheet.Cells[renglon, i].FormulaLocal = "=SUMAR.si(B2:B"+(renglon-2) + ",\"l\"," + (celdas)i + "2:" + (celdas)i + (renglon - 2) + ")"; 
            }
            //total fabricas
            renglon++;
            xlWorkSheet.Cells[renglon, 2] = "fab";
            xlWorkSheet.Cells[renglon, 2].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            for (int i = 3; i < no_columna; i++)
            {
                xlWorkSheet.Cells[renglon, i].FormulaLocal = "=SUMAR.si(B2:B" + (renglon - 3) + ",\"f\"," + (celdas)i + "2:" + (celdas)i + (renglon - 3) + ")";
            }

            //contarcajas
            renglon -= 2;
          
            xlWorkSheet.Cells[renglon, no_columna].FormulaLocal = "M";
            xlWorkSheet.Cells[renglon, no_columna+1].FormulaLocal = "=Contar.si(" + (celdas)(no_columna+1) + 2 + ":" + (celdas)(no_columna+1) + (renglon-1) + ","+ (celdas)no_columna+(renglon);
            renglon++;
            xlWorkSheet.Cells[renglon, no_columna].FormulaLocal = "I";
            xlWorkSheet.Cells[renglon, no_columna + 1].FormulaLocal = "=Contar.si(" + (celdas)(no_columna + 1) + 2 + ":" + (celdas)(no_columna + 1) + (renglon-2) + "," + (celdas)no_columna + (renglon);
            renglon++;
            xlWorkSheet.Cells[renglon, no_columna].FormulaLocal = "G";
            xlWorkSheet.Cells[renglon, no_columna + 1].FormulaLocal = "=Contar.si(" + (celdas)(no_columna + 1) + 2 + ":" + (celdas)(no_columna + 1) + (renglon-3) + "," + (celdas)no_columna + (renglon);
            renglon++;

        }



        void DarFormato(List<int> columaNegra, List<int> renglonColor)
        {
            Excel.Range rng = xlWorkSheet.get_Range("A1:" +(celdas)encabezado.Count + renglon);
            rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rng.EntireColumn.AutoFit();


            foreach (int rc in renglonColor)
            {
                rng = xlWorkSheet.get_Range("A" + rc + ":" + (celdas)encabezado.Count + rc);
                rng.Interior.ColorIndex = 33;
            }

            foreach (int cn in columaNegra)
            {
                xlWorkSheet.Cells[1, cn].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                rng = xlWorkSheet.get_Range((celdas) cn +"1:" + (celdas)cn + renglon);
                rng.Interior.Color = 0;
            }

           
        }

    }
}
