using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A873263.Actividad02
{
    class Program
    {
        static void Main(string[] args)
        {
            AppControl miAppControl = new AppControl();
            miAppControl.Iniciar();
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
