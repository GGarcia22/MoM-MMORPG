using System;
using System.Collections.Generic;
using System.Text;

namespace MoM_MMORPG
{
    class Personaje
    {
        private String nombre;
        private double vida;
        private const int VIDAMIN = 0;
        private const int VIDAMAX = 100;
        private Estado estadoVida;
        private Arma arma;
        private Armadura armadura;
        private List<Utilizable> inventario;

        public Personaje(string nombre, double vida, Estado estadoVida, Arma arma, Armadura armadura)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.estadoVida = estadoVida;
            this.arma = arma;
            this.armadura = armadura;
            this.inventario = new List<Utilizable>();
        }


        // ------------------------------GETTERS Y SETTERS----------------------------------

        public String getNombre()
        {
            return this.nombre;
        }


        public void setArma(Arma a)
        {
            this.arma = a;
        }

        public void setArmadura(Armadura a)
        {
            this.armadura = a;
        }


        public void setEstado(Estado e)
        {
            this.estadoVida = e;

        }

        public Estado getEstado()
        {
            return this.estadoVida;
        }


        public double getVida()
        {
            return this.vida;
        }

        public void setVida(double vida)
        {
            this.vida = vida;
        }

        public double getArmadura()
        {
            return this.armadura.getArmadura();
        }

        public void restarVida(double vida)
        {
            this.vida -= vida;
            limiteVida(this.vida);
            setEstado(estado(this.vida));
        }

        public double dañoInflingido()
        {
            return arma.dañoInfligido();
        }


        //------------------------------METODOS VARIOS-------------------------------------


        public void mostrarItems()
        {
            foreach (Utilizable u in this.inventario)
            {
                Console.WriteLine("► " + u.getNombre());
            }
        }



        public Utilizable buscarItem(String nombre)
        {
            Utilizable itemEncontrado = null;
            int i = 0;
            while (i < inventario.Count && itemEncontrado == null)
            {
                Utilizable u = this.inventario[i];       //trae el objeto segun la posicion 
                if (u.getNombre().Equals(nombre))
                {
                    itemEncontrado = u;
                    this.inventario.RemoveAt(i);
                }
                i++;
            }
            return itemEncontrado;
        }


        public void comer(Comida c)
        {
            int comidaUsada = 1;

            if (this.vida < 100)
            {
                this.vida = this.vida + c.getVidaCurada();
                c.setCant(comidaUsada);
                limiteVida(this.vida);
                Console.WriteLine("Comiendo...");
            }
            else
            {
                Console.WriteLine("Ya estas lleno...");
            }


        }



        public void equiparFlechas(Flecha f)
        {
            try
            {
                arma.equiparMunicion(f);
                Console.WriteLine("Equipaste flechas en tu arco.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }


        public void agregarItems(Utilizable u)
        {
            this.inventario.Add(u);
        }


        public void equiparItem(String nombre)
        {
            Utilizable item = this.buscarItem(nombre);

            if (item != null)
            {
                item.equiparItem(this);
            }
        }

        public void desequiparArma()
        {
            this.arma = null;
        }


        //-------------------------------METODOS DE PELEA------------------------------------


        public void limiteVida(double vida)
        {
            if (vida > VIDAMAX)
            {
                setVida(VIDAMAX);
            }
            else if (vida < VIDAMIN)
            {
                setVida(VIDAMIN);
            }
        }

        public Estado estado(double vida)
        {
            Estado e = this.estadoVida;
            if (vida <= 0)
            {
                e = Estado.Muerto;
            }
            else if (vida <= 50)
            {
                e = Estado.Herido;
            }
            else
            {
                e = Estado.Vivo;
            }
            return e;
        }


        public Arma hacerDaño(Personaje p)
        {
            Arma armaNull = this.arma;
            if (armaNull != null)
            {
                double daño = estadoVida == Estado.Herido ? arma.dañoInfligido() * 0.5 : arma.dañoInfligido();
                p.restarVida(daño - p.armadura.getArmadura());
            }
            else
            {
                Console.WriteLine("No tienes un arma equipada.");
            }
            return armaNull;
        }



    }
}
