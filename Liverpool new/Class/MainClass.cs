using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Liverpool_new.Class
{
    public class MainClass
    {
        public List<Pedido> pedidosarchivo = new List<Pedido>(); //Todos los pedidos del archivo
        public List<Pedido> pedido = new List<Pedido>();//Pedido Seleccionado
       // public List<Modelo> modelo = new List<Modelo>();
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
        public List<string> AbrirArchivo(string NombreArchivo)
        {
            pedidosarchivo.Clear();
            pedido.Clear();
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
                    return Regresa_NoPedidos();


            }

           
        }
    
        

        //leer archivo CSV
        
        List<string> ArchivoCSV(string NombreArchivo) {
            StreamReader sr = new StreamReader(NombreArchivo);
            pedido.Clear();
         //   modelo.Clear();
            while (sr.Peek() != -1)
            {
                char[] delimiterChars = { ',' };

                try
                {
                    string lineas = sr.ReadLine();
                    string[] settemporal = lineas.Split(delimiterChars);
                    string talla = settemporal[9];
                    Modelo mod = new Modelo(settemporal[7], settemporal[8], VerificaTalla(talla), settemporal[13], settemporal[5], settemporal[16]);                    
                    AgregarListaPedido(settemporal[0], int.Parse(settemporal[18]), mod, int.Parse(settemporal[19]));
                  //  AgregarListaModelo(settemporal[7], settemporal[8], settemporal[9], settemporal[13], settemporal[5], settemporal[16]);             
                }
                catch
                {
                }
            }

       /*     List<Modelo> ModNoRep = EliminarRepetidos(true,true) ;
            modelo = ModNoRep;*/
            sr.Close();
            return Regresa_NoPedidos();
        }
        //Abrir archivo TXt
        List<string> ArchivoTXT(string NombreArchivo) {
           StreamReader sr = new StreamReader(NombreArchivo);
            pedido.Clear();
            //modelo.Clear();
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
            return Regresa_NoPedidos();
        }

        public List<string> Regresa_NoPedidos()
        {
            List<string> no_pedidos= new List<string>();
            List<Pedido> no_pedidos_pedido = EliminarRepetidos(pedidosarchivo,false);
            foreach (Pedido ped in no_pedidos_pedido)
            {
                no_pedidos.Add(ped.GetNoPedido());
            }
            return no_pedidos;
        }

        public List<string> Seleccion_Pedido(string pedido_seleccionado)
        {
            pedido.Clear();
            List<string> modelos = new List<string>();
            foreach (Pedido ped in pedidosarchivo)
            {
                if (ped.GetNoPedido() == pedido_seleccionado)
                {
                    pedido.Add(ped);
                    modelos.Add(ped.ObtenerModelo() + ped.ObtenerColorChar());
                }
            }
            modelos = modelos.Distinct().ToList();
            return modelos;
        }

        public bool TieneBasicos()
        {
            
            ControlBasicos cb = new ControlBasicos();
            DataSet dtbasicos = new DataSet();
            cb.Iniciar(dtbasicos);
            List<string> listabasicos = cb.ListaBasicosString();
            foreach (Pedido ped in pedido)
            {
                foreach (string s in listabasicos)
                {
                    string x = ped.ObtenerModelo() + ped.ObtenerColorChar();
                    if (x == s)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        string VerificaTalla(string talla)
        {
            if (talla == "3X" || talla == "3x")
            {
                talla = "4T";
            }
            if (talla.IndexOf("T") < 0 && talla.IndexOf("t") < 0)
            { talla += "T"; }
          
            return talla;
        }

        
        //Hacer listas 
        void AgregarListaPedido(string no, int tie, Modelo mod, int cant) {
            string nopedido = no.Replace("  ", string.Empty);
            Pedido temporal = new Pedido(nopedido, tie, mod, cant);
            pedidosarchivo.Add(temporal);
        }



        //Crear archivo de etiquetas Zebra M4
        public bool Crear_Etiquetas(bool basicos) {
            string ruta = "Output//Etiquetas//";
            List<Modelo> modelos = new List<Modelo>();
            foreach (Pedido ped in pedido)
            {
                modelos.Add(ped.ObtenerModeloClass());
            }
            List<Modelo> modelo = OrdenarListaModelo(modelos, basicos);
             modelo = EliminarRepetidos(modelo,false, false);
            foreach (Modelo mod in modelo)
            {
                ruta += mod.ObtenerModelo() + "-";
            }
            ruta = ruta.Remove(ruta.Length-1);
            CrearDirectorio(ruta);
            return CrearArchivosEtiquetas(ruta,modelos);
        }
        bool CrearArchivosEtiquetas(string ruta, List<Modelo> modelo)
        {
            
            try
            {
               foreach (Modelo mod in modelo)
                {
                    string path = ruta + "//" + mod.ObtenerModelo()+ mod.ObtenerColorChar() + mod.ObtenerTalla()  + ".468";
                    string archivo = PlantillaEtiquetas(mod);
                    File.WriteAllText(path, archivo);
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
        public string CrearPedidoExcel(bool basicos)
        {
            HojaPedidoExcel hpe = new HojaPedidoExcel();
            List<Modelo> listamodelo = new List<Modelo>();
            foreach (Pedido ped in pedido)
            {
                Modelo mod = new Modelo(ped.ObtenerModelo(), ped.ObtenerColor(), ped.ObtenerTalla());
                listamodelo.Add(mod);
            }
            listamodelo = OrdenarListaModelo(listamodelo,basicos);
            listamodelo = EliminarRepetidos(listamodelo,true);

            string msg = hpe.Iniciar(OrdenarPedidoTienda(pedido),listamodelo);
           // string msg = hpe.Iniciar(OrdenarPedidoTienda(),OrdenarListaModelo());
            return msg;
        }

        public List<Modelo> EliminarRepetidos(List<Modelo> modelo,bool talla = false, bool color = false) {
            List<Modelo> filtro = new List<Modelo>();
            filtro.Add(modelo[0]);
            for(int i =0;i< modelo.Count()-1;i++)
               {
             
                if (!modelo[i+1].Equals(modelo[i],talla,color))
                {
                    Modelo mod = modelo[i+1];
                    filtro.Add(mod);
                }   
            }
            return filtro;
        }
        
        public List<Pedido> EliminarRepetidos(List<Pedido> lista,bool tienda = false) {
            List<Pedido> filtro = new List<Pedido>();
            OrdenarListaPedido(lista);
            filtro.Add(lista[0]);
            for (int i = 0; i < lista.Count() - 1; i++)
            {

                if (!lista[i + 1].Equals(lista[i], tienda))
                {
                    Pedido ped = lista[i + 1];
                    filtro.Add(ped);
                }
            }
            return filtro;
        }

        //Ordenamientos
        public List<Pedido> OrdenarListaPedido(List<Pedido> lista) {
            List<Pedido> SortedList = lista.OrderBy(o => o.GetNoPedido()).ToList();
            return SortedList;
        } 
        public List<Pedido> OrdenarPedidoTienda(List<Pedido> lista) {
            List<Pedido> SortedList = pedido.OrderBy(o => o.ObtenerTienda()).ToList();            
            return SortedList;
        }

        public List<Modelo> OrdenarListaModelo(List<Modelo> modelo, bool basicos = false)
        {
            List<Modelo> SortedList = new List<Modelo>();
            if (basicos)
            {
               // SortedList = modelo.OrderBy(o => o.ObtenerModelo()).ThenBy(o => o.ObtenerColor()).ThenBy(o => o.ObtenerTalla()).ToList();
                ControlBasicos cb = new ControlBasicos();
                DataSet lbasicos = new DataSet();
                cb.Iniciar(lbasicos);
                List<string> modBasicos = cb.ListaBasicosString();
                foreach (string s in modBasicos)
                {
                    IEnumerable<Modelo> ConsultaModelos =
                     from modelos in modelo
                     where modelos.ObtenerModelo()+modelos.ObtenerColorChar() == s
                     select modelos;
                    SortedList.AddRange(ConsultaModelos.ToList());
                }
            }
            else { 
                SortedList = modelo.OrderBy(o => o.ObtenerModelo()).ThenBy(o => o.ObtenerColor()).ThenBy(o => o.ObtenerTalla()).ToList();
            }
            return SortedList;
        }

 


    }
}
