using System;

namespace MoM_MMORPG
{
    class Program
    {
        static void Main(string[] args)
        {

            Juego mom = new Juego("Moon of Marcraft");

            Arma espada = new Espada("espada", 25);
            Armadura armadura1 = new Armadura("armadura", 10);
            Personaje p1 = new Personaje("guerrero", 100, Estado.Vivo, espada, armadura1);

            Arma hacha = new Hacha(35 ,"hacha", 30);
            Armadura armadura2 = new Armadura("armadura", 10);
            Personaje p2 = new Personaje("barbaro", 100, Estado.Vivo, hacha, armadura2);

            Arma arco = new Arco("arco", 20);
            Armadura armadura3 = new Armadura("armadura", 5);
            Personaje p3 = new Personaje("arquero", 100, Estado.Vivo, arco, armadura3);

            Arma espadon = new Espada("espadon", 25);
            Armadura armaduraX = new Armadura("armadura", 15);
            Personaje enemigo = new Personaje("enemigo", 100, Estado.Vivo, espadon, armaduraX);

            p1.agregarItems(new Comida("manzana", 10, 1));
            p1.agregarItems(new Arco("arco", 15));
            p1.agregarItems(new Flecha("flecha", 5, 10));

            mom.cargarEnemigo(enemigo);
            mom.cargarPersonajes(p1);
            mom.cargarPersonajes(p2);
            mom.cargarPersonajes(p3);

            mom.iniciarJuego();
        }
    }
}
