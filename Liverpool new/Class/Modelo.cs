using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liverpool_new.Class
{
    public class Modelo
    {
        string modelo;
        string color;
        string talla;
        string fecha_embarque;
        string sku_barras;
        string sku;
        string precio;

        
        public Modelo(string mod, string col, string tall, string fecha, string codigo, string pre)
        {
            modelo = mod;
            color = col;
            talla = tall;
            fecha_embarque = fecha;
            sku_barras = codigo.Insert(codigo.Length-1,"-");
            sku = codigo;
            precio = pre;   
        }
        public Modelo()
        { }

        public bool Equals(Modelo other, bool tall)
        {
            if(!tall)
            {
                return string.Equals(modelo, other.modelo);
            }
            return string.Equals(modelo, other.modelo) && string.Equals(talla, other.talla);

        }

        public string ObtenerModelo()
        {
            return modelo;
        }


    }




}
