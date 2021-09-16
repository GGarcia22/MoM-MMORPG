using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Espada : Arma
    {
        public Espada(string nombre, int dañoBase) : base(nombre, dañoBase)
        {

        }

        public override double dañoInfligido()
        {
            return dañoBase;
        }


        public override void equiparMunicion(Flecha f)
        {
            throw new Exception("Este arma no funciona con municion");
        }
    }
}
