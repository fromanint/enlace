using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liverpool_new.Class;

namespace Liverpool_new.Formularios
{
    public class MainClass
    {
        public List<Pedido> pedido = new List<Pedido>();
        public List<Modelo> modelo = new List<Modelo>();
        public string NombreArchivo;

        //Abrir archivo
        public string AbrirArchivo(string NombreArchivo)
        {
            string extension = System.IO.Path.GetExtension(NombreArchivo);
            switch (extension)
            {
                case ".csv":
                    return ArchivoCSV(NombreArchivo);
                  
                case ".txt":
                    return ArchivoTXT(NombreArchivo);
                   
                case ".CSV":
                    return ArchivoCSV(NombreArchivo);
              
                case ".TXT":
                    return ArchivoTXT(NombreArchivo);
         
                default:
                    return Regresa_NoPedido();
                 

            }

           
        }
    
        

        //leer archivo CSV
        
        string ArchivoCSV(string NombreArchivo) {
            System.IO.StreamReader sr = new System.IO.StreamReader(NombreArchivo);
            pedido.Clear();
            modelo.Clear();
            while (sr.Peek() != -1)
            {
                char[] delimiterChars = { ',' };

                try
                {
                    string lineas = sr.ReadLine();
                    string[] settemporal = lineas.Split(delimiterChars);
                    AgregarListaPedido(settemporal[0], int.Parse(settemporal[18]), int.Parse(settemporal[7]), settemporal[9], int.Parse(settemporal[19]), settemporal[8]);
                    AgregarListaModelo(settemporal[7], settemporal[8], settemporal[9], settemporal[13], settemporal[5], settemporal[16]);              
                }
                catch
                {
                }



            }
            sr.Close();
            return Regresa_NoPedido();
        }

        string ArchivoTXT(string NombreArchivo) {
            System.IO.StreamReader sr = new System.IO.StreamReader(NombreArchivo);
            pedido.Clear();
            modelo.Clear();
            while (sr.Peek() != -1)
            {
                 try
                {
                    string lineas = sr.ReadLine();

                }
                catch
                {
                }



            }
            sr.Close();
            return Regresa_NoPedido();
        }

        public string Regresa_NoPedido()
        {
            if (pedido.Count != 0)
                return pedido[0].GetNoPedido();
            else
                return "No es un archivo valido";
        }

        void AgregarListaPedido(string no, int tie, int mod, string tall, int cant, string col) {
            string nopedido = no.Replace("  ", string.Empty);
            string talla = tall.Replace("T", string.Empty);
            Pedido temporal = new Pedido(nopedido, tie, mod, talla, cant, col);
            pedido.Add(temporal);
        }
        void AgregarListaModelo(string mod, string col, string tall, string fecha, string codigo, string pre) {
            if (tall.IndexOf("T") < 0 || tall.IndexOf("t") < 0)
            { tall += "T"; }
            Modelo temporal = new Modelo(mod, col, tall, fecha, codigo, pre);
            modelo.Add(temporal);
        }
        //Crear hoja de excel
        public void Crear_Pedido() {

        }
        //Crear archivo de etiquetas Zebra M4
        public void Crear_Etiquetas() {
        }
        //Crear archivo de etiquetas de embarque
        public void Crear_Etiquetas_Embarque()
        {
        }


    }
}
