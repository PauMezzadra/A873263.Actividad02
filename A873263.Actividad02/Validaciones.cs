using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A873263.Actividad02
{
    class Validaciones
    {
        public static string PedirStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("No puede ser vacío");
                }
            } while (valor == "");

            return valor;
        }

        public static int PedirInt(string mensaje)
        {
            int valor;
            bool valido = false;
            string mensError = "Debe ingresar un número";

            do
            {
                Console.WriteLine(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            return valor;
        }
    }
}
