using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Armadura : Utilizable
    {
        private String nombre;
        private double defensa;

        public Armadura(String nombre, double defensa)
        {
            this.nombre = nombre;
            this.defensa = defensa;
        }

        public void equiparItem(Personaje p)
        {
            p.setArmadura(this);
        }

        public double getArmadura()
        {
            return this.defensa;
        }

        public String getNombre()
        {
            return this.nombre;
        }
    }
}
