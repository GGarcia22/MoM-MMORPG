using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Comida : Utilizable
    {
        private String nombre;
        private int vidaQueCura;
        private int cantidad;

        public Comida(String nombre, int vidaQueCura, int cantidad)
        {
            this.nombre = nombre;
            this.vidaQueCura = vidaQueCura;
            this.cantidad = cantidad;
        }

        public void equiparItem(Personaje p)
        {
            p.comer(this);
        }

        public int getVidaCurada()
        {
            return vidaQueCura;
        }

        public void setCant(int cant)
        {
            this.cantidad = this.cantidad - cant;
        }

        public String getNombre()
        {
            return this.nombre;
        }


    }
}
