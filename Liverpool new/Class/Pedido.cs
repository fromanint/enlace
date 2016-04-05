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
        int modelo;      //3
        string talla;    //4
        int cantidad;    //5
        string color;    //6


        public Pedido(string no, int tie, int mod, string tall, int cant, string col)
        {
            nopedido = no;
            tienda = tie;
            modelo = mod;
            talla = tall;
            cantidad = cant;
            color = col;
        }

        public string GetNoPedido() {
            return nopedido;
        }

        public int ObtenerTienda()
        {
            return tienda;
        }

        public bool Equals(Pedido other,  bool tien)
        {
            if (tien)
            {
                return tienda == other.tienda;
            }


            return string.Equals(nopedido, other.nopedido);
        }


    }
}
