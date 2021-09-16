using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG.Menus
{
    class MenuInventario
    {
        public const int OPCION_1 = 1;
        private const String NOMBRE_1 = "Equipar item";
        public const int OPCION_2 = 2;
        private const String NOMBRE_2 = "Desequipar arma";
        public const int OPCION_3 = 3;
        private const String NOMBRE_3 = "Salir del inventario";

        public static void mostrarMenu()
        {
            Console.WriteLine("Que deseas hacer ? ");
            Console.WriteLine(OPCION_1 + "► " + NOMBRE_1 + "\n" + OPCION_2 + "► " + NOMBRE_2 + "\n" + OPCION_3 + "► " + NOMBRE_3);
        }
    }
}
