using System;
using System.Collections.Generic;
using OpenTK.Mathematics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Grafica
{
    class Escenario : IDibujable
    {
        private Dictionary<string, Objeto> Objetos { get; set; }
        private Punto Centro { get; set; }

        //properties
        public Dictionary<string, Objeto> LObjetos { get { return Objetos; } set { Objetos = value; } }
        public Punto Centro_Masa { get { return Centro; } set { Centro = value; } }


        public Escenario()
        {
            this.Objetos = new Dictionary<string, Objeto>();
            this.Centro = new Punto(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        }

        public Escenario(Escenario esc)
        {
            this.Objetos = esc.LObjetos;
            this.Centro = esc.Centro_Masa;
        }

        public void Add(string key, Objeto obj)
        {
            this.Objetos.Add(key, obj);
        }

        public Objeto GetElemento(string key)
        {
            return this.Objetos[key];
        }

        public void Remove(string key)
        {
            this.Objetos.Remove(key);
        }


        public void Dibujar()
        {
            foreach (Objeto obj in this.Objetos.Values)
            {
                obj.Dibujar();
            }

        }

    }
}
