using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Juego
    {
        private String nombre;
        private Personaje pjPrincipal;
        private List<Personaje> personajes;
        private Personaje enemigo;

        public Juego(String nombre)
        {
            this.nombre = nombre;
            this.personajes = new List<Personaje>();

        }

        public void mostrarTitulo()
        {
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                              "" +
                              "░░░░░░░░░░░░░░░░░░░░░░░░ Moon Of Marcraft ░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                              "" +
                              "  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        }

        public void separador()
        {
            Console.WriteLine("----------------------------------------------------------------");

        }

        public void iniciarJuego()
        {
            elegirPersonaje();
        }

        public void elegirPersonaje()
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    mostrarTitulo();
                    separador();
                    Menus.MenuElegirPersonaje.mostrarMenu();
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Has elegido al Guerrero");
                            cargarPersonaje(buscarPersonaje("guerrero"));
                            menuPersonaje();
                            break;

                        case 2:
                            Console.WriteLine("Has elegido al Barbaro");
                            cargarPersonaje(buscarPersonaje("barbaro"));
                            menuPersonaje();
                            break;

                        case 3:
                            Console.WriteLine("Has elegido la Arquero");
                            cargarPersonaje(buscarPersonaje("arquero"));
                            menuPersonaje();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();

        }


        public void menuPersonaje()
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    separador();
                    Console.WriteLine("o () xxxx [{::::::::::::::::::>  PELEA  o () xxxx [{::::::::::::::::::>");
                    barrasVida();
                    Menu.mostrarMenu();
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Lanzando ataque!");
                            duelo(this.pjPrincipal, this.enemigo);
                            break;

                        case 2:
                            Console.WriteLine("Viendo Inventario...");
                            this.pjPrincipal.mostrarItems();
                            menuInvenario();
                            break;

                        case 3:
                            Console.WriteLine("Escapando!");
                            salirJuego();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();

        }


        public void menuInvenario()
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    separador();
                    Menus.MenuInventario.mostrarMenu();
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Que item deseas equipar?");
                            String item = Console.ReadLine();
                            this.pjPrincipal.equiparItem(item);
                            menuPersonaje();
                            break;

                        case 2:
                            Console.WriteLine("Ya no tienes un arma equipada");
                            this.pjPrincipal.desequiparArma();
                            menuPersonaje();
                            break;
                        case 3:
                            Console.WriteLine("Cerrando inventario...");
                            menuPersonaje();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();

        }



        public Personaje buscarPersonaje(String nombre)
        {
            Personaje pjEncontrado = null;
            
                
                int i = 0;
                while (i < this.personajes.Count && pjEncontrado == null)
                {
                    Personaje p = this.personajes[i];
                    if (p.getNombre().Equals(nombre))
                    {
                        pjEncontrado = p;
                    }
                    i++;
                }
            return pjEncontrado;
        }

        public void salirJuego()
        {
            Console.WriteLine("► GAME OVER ◄");
            Environment.Exit(0);
        }

        public void mensajeVictoria()
        {
            Console.WriteLine("► Has Ganado La Batalla! ◄");
            Environment.Exit(0);
        }

        public void duelo(Personaje p, Personaje enemigo)
        {
            ataque(p, enemigo);
            ataqueEnemigo(p, enemigo);
        }

        public void barrasVida()
        {
            separador();
            Console.WriteLine("TU ESTADO: " + this.pjPrincipal.getEstado() + " ► " + this.pjPrincipal.getVida() + "/100 ♥ - Armadura ► "+ this.pjPrincipal.getArmadura());
            separador();
            Console.WriteLine("ESTADO DEL ENEMIGO: " + this.enemigo.getEstado() + " ► " + this.enemigo.getVida() + "/100 ♥ - Armadura ► " + this.enemigo.getArmadura());
            separador();
        }


        public void ataque(Personaje p, Personaje enemigo)
        {
            p.hacerDaño(enemigo);
            if (enemigo.getEstado() == Estado.Muerto)
            {
                Console.WriteLine("Has vencido a tu enemigo!");
                salirJuego();
            }
        }

        public void ataqueEnemigo(Personaje p, Personaje enemigo)
        {
            Console.WriteLine("Es el turno del enemigo!");
            enemigo.hacerDaño(p);
            if (p.getEstado() == Estado.Muerto)
            {
                Console.WriteLine("Has muerto...");
                salirJuego();
            }
        }


        //----------------------------Cargar Personajes e inventario-----------------------------------------

        public void cargarPersonajes(Personaje p)
        {
            this.personajes.Add(p);
        }

        public void cargarEnemigo(Personaje e)
        {
            this.enemigo = e;
        }

        public void cargarPersonaje(Personaje p)
        {
            this.pjPrincipal = p;
        }
    }
}


