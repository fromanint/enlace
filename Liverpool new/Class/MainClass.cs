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
            while (sr.Peek() != -1)
            {
                char[] delimiterChars = { ',' };

                try
                {
                    string lineas = sr.ReadLine();
                    string[] settemporal = lineas.Split(delimiterChars);
                        string aux;
                        string nopedido = settemporal[0].Replace("  ", string.Empty);
                        int tienda = int.Parse(settemporal[2]);
                        int modelo = int.Parse(settemporal[5]);
                        aux = settemporal[7];
                        string talla = aux.Replace("T", string.Empty);        
                        int cantidad = int.Parse(settemporal[12]);
                        string color = settemporal[6];
                        Pedido temporal = new Pedido(nopedido, tienda, modelo, talla, cantidad, color);
                    pedido.Add(temporal);                  
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
            while (sr.Peek() != -1) { 
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
