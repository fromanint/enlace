using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Liverpool_new.Class
{
    public class MainClass
    {
        public List<Pedido> pedido = new List<Pedido>();
        public List<Modelo> modelo = new List<Modelo>();
        public string NombreArchivo;

        //Al Abrir por primera Vez crear directorio para archivos de Salida
        public void CrearDirectorio(string ruta = "Output")
        {
            if (Directory.Exists(ruta))
            { 
                Console.WriteLine("That path exists already.");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(ruta);
            }
        }

        //Abrir archivo
        public string AbrirArchivo(string NombreArchivo)
        {
            string extension = Path.GetExtension(NombreArchivo);
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
            StreamReader sr = new StreamReader(NombreArchivo);
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

            List<Modelo> ModNoRep = EliminarRepetidos(true,true) ;
            modelo = ModNoRep;
            sr.Close();
            return Regresa_NoPedido();
        }
        //Abrir archivo TXt
        string ArchivoTXT(string NombreArchivo) {
           StreamReader sr = new StreamReader(NombreArchivo);
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

        
        //Hacer listas 
        void AgregarListaPedido(string no, int tie, int mod, string tall, int cant, string col) {
            string nopedido = no.Replace("  ", string.Empty);
            string talla = tall;
            Pedido temporal = new Pedido(nopedido, tie, mod, talla, cant, col);
            pedido.Add(temporal);
        }
        void AgregarListaModelo(string mod, string col, string tall, string fecha, string codigo, string pre) {
            if (tall.IndexOf("T") < 0 && tall.IndexOf("t") < 0)
            { tall += "T"; }
            if (tall == "3X" || tall == "3x")
            {
                tall = "4T";
            }
            Modelo temporal = new Modelo(mod, col, tall, fecha, codigo, pre);
            modelo.Add(temporal);
        }
        //Crear archivo de etiquetas Zebra M4
        public bool Crear_Etiquetas() {
            string ruta = "Output//Etiquetas//";
            List<Modelo> modelos = EliminarRepetidos(false, false);
            foreach (Modelo mod in modelos)
            {
                ruta += mod.ObtenerModelo() + "-";
            }
            ruta = ruta.Remove(ruta.Length-1);
            CrearDirectorio(ruta);
            return CrearArchivosEtiquetas(ruta);
        }
        bool CrearArchivosEtiquetas(string ruta)
        {
            try
            {
                foreach (Modelo mod in modelo)
                {
                    string path = ruta + "//" + mod.ObtenerModelo() + mod.ObtenerTalla() + mod.ObtenerColorChar() + ".468";
                    string archivo = PlantillaEtiquetas(mod);
                    File.WriteAllText(path, archivo);
                       // StreamWriter file = new StreamWriter(path);
                        //file.WriteLine(archivo);


                }
                return true;
            }
            catch {
                return false;
            }
        }
        //plantilla etiqeutas
        string PlantillaEtiquetas(Modelo mod)
        {
            string archivo = "L2" + Environment.NewLine;
            archivo += "2" + Environment.NewLine;
            archivo += "104380609-9" + Environment.NewLine;
            archivo += "" + Environment.NewLine;
            archivo += "" + Environment.NewLine;
            archivo += "^XA" + Environment.NewLine;
            archivo += "^CW1,DOWNLD1" + Environment.NewLine;
            archivo += "^CW2,DOWNLD2" + Environment.NewLine;
            archivo += "^CW3,DOWNLD3" + Environment.NewLine;
            archivo += "^CW4,DOWNLD4" + Environment.NewLine;
            archivo += "^COY,0^MMT^MD+0" + Environment.NewLine;
            archivo += "^XZ" + Environment.NewLine;
            archivo += "^XA" + Environment.NewLine;
            archivo += "^PR3^FS" + Environment.NewLine;
            archivo += "^BY2,3.0" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT40,250^ABN,17,7^FDMod " + mod.ObtenerModelo() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT160,250^ABN,17,7^FD" + mod.ObtenerColor() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT230,250^ABN,17,7^FD" + mod.ObtenerTalla() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT300,257^ABB,11,7^FD" + mod.ObtenerFecha_embarque() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT300,285^ABB,11,7^FD" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT110,290^A0N,22,22^FD" + mod.ObtenerSku_barras() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT60,340^B2N,41,N,N,N^FD" + mod.ObtenerSku() + "" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT40,380^ABN,22,14^FD    $" + mod.ObtenerPrecio() + ".00" + Environment.NewLine;
            archivo += "^FS" + Environment.NewLine;
            archivo += "^FT93,420^ADN,14,10^FDINCLUYE IVA^FS" + Environment.NewLine;
            archivo += "@" + Environment.NewLine;
            archivo += "^PQ2" + Environment.NewLine;
            archivo += "^XZ" + Environment.NewLine;

            return archivo;
        }
        //Crear Hoja de excel para pedidos
        public string CrearPedidoExcel()
        {
            HojaPedidoExcel hpe = new HojaPedidoExcel();
            string msg = hpe.Iniciar(OrdenarPedidoTienda(),OrdenarListaModelo());
            return msg;
        }

        //Filtros
        public List<Modelo> EliminarRepetidos(bool talla = false, bool color = false) {
            List<Modelo> filtro = new List<Modelo>();
            filtro.Add(modelo[0]);
            for(int i =0;i<modelo.Count()-1;i++)
               {
             
                if (!modelo[i+1].Equals(modelo[i],talla,color))
                {
                    Modelo mod = modelo[i+1];
                    filtro.Add(mod);
                }   
            }
            return filtro;
        }
        public List<Pedido> EliminarRepetidos(bool tienda = false) {
            List<Pedido> filtro = new List<Pedido>();
            filtro.Add(pedido[0]);
            for (int i = 0; i < pedido.Count() - 1; i++)
            {

                if (!pedido[i + 1].Equals(pedido[i], tienda))
                {
                    Pedido ped = pedido[i + 1];
                    filtro.Add(ped);
                }
            }
            return filtro;
        }

        //Ordenamientos
        public List<Pedido> OrdenarListaPedido() {
            List<Pedido> SortedList = pedido.OrderBy(o => o.GetNoPedido()).ToList();
            return SortedList;
        } 
        public List<Pedido> OrdenarPedidoTienda() {
            List<Pedido> SortedList = pedido.OrderBy(o => o.ObtenerTienda()).ToList();            
            return SortedList;
        }
        public List<Modelo> OrdenarListaModelo()
        {
            List<Modelo> SortedList = modelo.OrderBy(o => o.ObtenerModelo()).ThenBy(o => o.ObtenerTalla()).ThenBy(o=>o.ObtenerColor()).ToList();
            return SortedList;
        }
        public List<Modelo> OrdenEspecialModelo()
        {
            List<Modelo> SortedList = modelo.OrderBy(o => o.ObtenerModelo()).ThenBy(o => o.ObtenerColor()).ToList();
            return SortedList;
        }



    }
}
