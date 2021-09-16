using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    abstract class Arma :  Utilizable
    {
        public String nombre;
        public int dañoBase;

        protected Arma(string nombre, int dañoBase)
        {
            this.nombre = nombre;
            this.dañoBase = dañoBase;
        }

        public void equiparItem(Personaje p)
        {
            p.setArma(this);
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public abstract double dañoInfligido();


        public abstract void equiparMunicion(Flecha f);


    }
}
