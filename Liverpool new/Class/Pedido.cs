using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liverpool_new.Class
{
    public class Pedido
    {
        string nopedido; //1
        int tienda;      //2
        Modelo modelo;      //3
        int cantidad;    //5
            //6


        public Pedido(string no, int tie, Modelo mod, int cant)
        {
            nopedido = no;
            tienda = tie;
            modelo = mod;
            cantidad = cant;
            
        }

        public string GetNoPedido() {return nopedido;}
        public int ObtenerTienda() { return tienda; }
        public char ObtenerColorChar() { return modelo.ObtenerColorChar(); }
        public string ObtenerColor() { return modelo.ObtenerColor(); }
        public string ObtenerModelo() { return modelo.ObtenerModelo(); }
        public string ObtenerTalla() { return modelo.ObtenerTalla(); }
        public int ObtenerCantidad() { return cantidad; }
        public Modelo ObtenerModeloClass() { return modelo; }


        public bool Equals(Pedido other,  bool tien)
        {
            if (tien)
            {
                return tienda == other.tienda && string.Equals(nopedido, other.nopedido);
            }
            return string.Equals(nopedido, other.nopedido);
        }


    }
}
