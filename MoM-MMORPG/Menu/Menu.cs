using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Menu
    {

        public const int OPCION_1 = 1;
        private const String NOMBRE_1 = "Atacar";
        public const int OPCION_2 = 2;
        private const String NOMBRE_2 = "Inventario ";
        public const int OPCION_3 = 3;
        private const String NOMBRE_3 = "Escapar";

        public static void mostrarMenu()
        {
            Console.WriteLine("Que podemos hacer? ");
            Console.WriteLine(OPCION_1 + "► " + NOMBRE_1 + "\n" + OPCION_2 + "► " + NOMBRE_2 + "\n" + OPCION_3 + "► " + NOMBRE_3);
        }
    }
}
