using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Hacha : Arma
    {
        private float probabilidadDeCritico;


        public Hacha(float probabilidadDeCritico, string nombre, int dañoBase) : base(nombre, dañoBase)
        {
            this.probabilidadDeCritico = probabilidadDeCritico;
        }


        public override double dañoInfligido()
        {
             return golpeCritico() ? dañoBase * 2 : dañoBase;
        }

        public bool golpeCritico()
        {
            Random r = new Random(100);
            double pro = r.NextDouble()+1;

            return pro > 0 && pro < probabilidadDeCritico ? true : false; 
        }


        public override void equiparMunicion(Flecha f)
        {
            throw new Exception("Este arma no funciona con municion");
        }
    }
}
