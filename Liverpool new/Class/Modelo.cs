using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liverpool_new.Class
{
    public class Modelo
    {
        public string modelo ;
        string color;
        string talla;
        string fecha_embarque;
        string sku_barras;
        string sku;
        string precio;


        public Modelo(string mod, string col, string tall = "", string fecha = "", string codigo = "", string pre = "")
        {
            talla = fecha_embarque = sku = precio = "";
            modelo = mod;
            color = col;
            talla = tall;
            if (codigo != "")
            { sku_barras = codigo.Insert(codigo.Length - 1, "-"); 
            sku = codigo; }
            precio = pre;
            if(fecha != "") { 
            fecha = fecha.Remove(6, 2);
            fecha = fecha.Remove(0, 3);
            fecha_embarque = fecha;
            }
            if (talla.Length >= 3)
            {
                talla = talla.Substring(0, 3);
            }
            
        }
        public Modelo()
        { }

        public bool Equals(Modelo other, bool tall, bool col)
        {
            if (tall && col)
            {
                return string.Equals(modelo, other.modelo) && string.Equals(color, other.color) && string.Equals(talla, other.talla);
            }
            if (tall)
            {
                return string.Equals(modelo, other.modelo) && string.Equals(talla, other.talla);
            }
            if (col){
                return string.Equals(modelo, other.modelo) && string.Equals(color, other.color);
            }

            return string.Equals(modelo, other.modelo);
        }



        public char ObtenerColorChar() { return color[0]; }
        public string ObtenerModelo() { return modelo; }
        public string ObtenerColor(){ return color; }
        public string ObtenerTalla() { return talla; }
        public string ObtenerSku_barras() { return sku_barras; }
        public string ObtenerSku() { return sku; }
        public string ObtenerPrecio() { return precio;}
        public string ObtenerFecha_embarque() { return fecha_embarque; }


    }




}
