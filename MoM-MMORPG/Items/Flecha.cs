using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Flecha : Utilizable 
    {
        private String nombre;
        private int daño;
        private int stock;

        public Flecha(String nombre, int daño, int stock)
        {
            this.nombre = nombre;
            this.daño = daño;
            this.stock = stock;
        }

        public void equiparItem(Personaje p)
        {
            p.equiparFlechas(this);
        }

        public int getDaño()
        {
            return daño;
        }

        public int getStock()
        {
            return stock;
        }

        public void setStock(int valor)
        {
            this.stock = this.stock - valor;
        }

        public String getNombre()
        {
            return this.nombre;
        }
    }
}
