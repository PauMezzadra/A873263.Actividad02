using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A873263.Actividad02
{
    class Producto
    {
        public int Codigo { get; private set; }
        public string NombreProducto { get; private set; }
        public int StockInicial { get; private set; }

        public Producto(int elCodigo, string elNombre, int elStock)
        {
            Codigo = elCodigo;
            NombreProducto = elNombre;
            StockInicial = elStock;
        }
    }
}
