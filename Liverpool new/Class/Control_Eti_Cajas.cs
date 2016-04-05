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

        public string Crear_Etiquetas_Embarque(List<int> tiendas, string pedido)
        {
            bool non= false;
            int repeticiones = (tiendas.Count) / 2;
            if (tiendas.Count % 2 != 0)
            {
                non=true;
            }
            AbrirDocumento();
            if (non)
            {
                string oTemplatePath = System.Windows.Forms.Application.StartupPath.ToString() + "\\Resources\\Plantillas\\PLANTILLA2.dotx";
                rng.InsertFile(oTemplatePath, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                BuscarReemplazar("XX1", "01");
                BuscarReemplazar("YY1", "01");
                BuscarReemplazar("TIENDA1", DetalleTiendas.ObtenerNombre(tiendas[tiendas.Count - 1].ToString()));
                
            }
            return "";
        }

        void AbrirDocumento()
        {
            int posx = 14, posy = 14;
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
