using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A873263.Actividad02
{
    class AppControl
    {
        public void Iniciar()
        {
            const string opcionAlta = "A";
            const string opcionPedido = "P";
            const string opcionEntrega = "E";
            const string opcionConsulta = "C";
            const string opcionSalir = "S";

            string opcionMenu = "";
            int elCodigo;
            string elNombre;
            int elStock;
            List<Producto> productos = new List<Producto>();
            int codigoBuscar;
            int cantidadBajaOAlta;
            int nuevoStock;
            Producto productoEncontrado;

            do
            {
                opcionMenu = Validaciones.PedirStrNoVac("Ingrese una opción:\n"
                        + opcionAlta + "- Alta Producto\n"
                        + opcionPedido + "- Cargar Pedido\n"
                        + opcionEntrega + "- Cargar Entrega\n"
                        + opcionConsulta + "- Consultar Stock\n"
                        + opcionSalir + "- Salir");

                switch (opcionMenu)
                {
                    case opcionAlta:
                        elCodigo = Validaciones.PedirInt("Ingrese el código del producto");
                        elNombre = Validaciones.PedirStrNoVac("Ingrese el nombre del producto");
                        elStock = Validaciones.PedirInt("Ingrese el stock inicial de dicho producto");
                        if (elStock < 0)
                        {
                            Console.WriteLine("No se puede cargar stock negativo");
                        }
                        else
                        {
                            productos.Add(new Producto(elCodigo, elNombre, elStock));
                            Console.WriteLine("El producto fue agregado con éxito");
                        }
                        break;

                    case opcionPedido:
                        codigoBuscar = Validaciones.PedirInt("Ingrese el código del producto vendido");
                        productoEncontrado = null;
                        productoEncontrado = GetProducto(productos, codigoBuscar);
                        if (productoEncontrado == null)
                        {
                            Console.WriteLine("No hay registrado un producto con ese código");
                        }
                        else
                        {
                            elNombre = productoEncontrado.NombreProducto;
                            cantidadBajaOAlta = Validaciones.PedirInt("Ingrese la cantidad de productos vendidos");
                            if (cantidadBajaOAlta < 0)
                            {
                                Console.WriteLine("No pueden ser cantidades negativas");
                            }
                            else
                            {
                                nuevoStock = productoEncontrado.StockInicial - cantidadBajaOAlta;
                                if (nuevoStock < 0)
                                {
                                    Console.WriteLine("No cuenta con stock suficiente para efectuar esta venta");
                                }
                                else
                                {
                                    productos.Remove(productoEncontrado);
                                    productos.Add(new Producto(codigoBuscar, elNombre, nuevoStock));
                                    Console.WriteLine("El stock ha sido actualizado");
                                    if (nuevoStock == 0)
                                    {
                                        Console.WriteLine("Ud. se ha quedado sin stock de este producto, debe reponer stock");
                                    }
                                }
                            }
                        }
                        break;

                    case opcionEntrega:
                        codigoBuscar = Validaciones.PedirInt("Ingrese el código del producto del cual se ha recibido una entrega");
                        productoEncontrado = null;
                        productoEncontrado = GetProducto(productos, codigoBuscar);
                        if (productoEncontrado == null)
                        {
                            Console.WriteLine("No hay registrado un producto con ese código");
                        }
                        else
                        {
                            elNombre = productoEncontrado.NombreProducto;
                            cantidadBajaOAlta = Validaciones.PedirInt("Ingrese la cantidad de productos recibidos");
                            if (cantidadBajaOAlta < 0)
                            {
                                Console.WriteLine("No pueden ser cantidades negativas");
                            }
                            else
                            {
                                nuevoStock = productoEncontrado.StockInicial + cantidadBajaOAlta;
                                productos.Remove(productoEncontrado);
                                productos.Add(new Producto(codigoBuscar, elNombre, nuevoStock));
                                Console.WriteLine("El stock ha sido actualizado");
                            }
                        }
                        break;

                    case opcionConsulta:
                        codigoBuscar = Validaciones.PedirInt("Ingrese el código por el cual desea consultar");
                        productoEncontrado = null;
                        productoEncontrado = GetProducto(productos, codigoBuscar);
                        if (productoEncontrado == null)
                        {
                            Console.WriteLine("No hay registrado un producto con ese código");
                        }
                        else
                        {
                            Console.WriteLine($"Código del producto: {productoEncontrado.Codigo}\n" +
                                                $"Nombre del producto: {productoEncontrado.NombreProducto}\n" +
                                                $"Stock del producto: {productoEncontrado.StockInicial}");
                        }
                        break;

                    case opcionSalir:
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

            } while (opcionMenu != opcionSalir);

            foreach (Producto prod in productos)
            {
                Console.WriteLine($"Código: {prod.Codigo} - Nombre: {prod.NombreProducto} - Stock: {prod.StockInicial}");
            }

        }

        public Producto GetProducto(List<Producto> elProducto, int elCodigo)
        {
            return elProducto.Find
                (
                    delegate (Producto prod)
                    {
                        return prod.Codigo == elCodigo;
                    }
                );
        }

    }
}
