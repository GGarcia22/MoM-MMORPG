using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Arco : Arma
    {
        private Flecha flechas = null;


        public Arco(string nombre, int dañoBase) : base(nombre, dañoBase)
        {
        }

        public override double dañoInfligido()
        {
            int daño = 0;
            int flechaUsada = 1;
            
            if (flechas != null)
            {
                daño = dañoBase + flechas.getDaño();
                flechas.setStock(flechaUsada);
            }
            return daño;
        }

        public override void equiparMunicion(Flecha f)
        {
            this.flechas = f;
        }
    }
}
