
using System.Collections.Generic;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
namespace Program_Grafica
{
    class Parte : IDibujable
    {
        private Dictionary<string, Punto> Puntos { get; set; }
        private Punto Centro { get; set; }

        //properties
        public Dictionary<string, Punto> LPuntos { get { return Puntos; } set { Puntos = value; } }
        public Punto Centro_Masa { get{ return Centro; } set { Centro = value; } }

        public Parte()
        {
            this.Puntos = new Dictionary<string, Punto>();
            this.Centro = new Punto(new Vector3(0,0,0), new Vector3(0,0,0));
        }
        public Parte(Parte p)
        {
            this.Puntos = p.LPuntos;
            this.Centro = p.Centro_Masa;
        }

        public void Add(string key, Punto p)
        {
            this.Puntos.Add(key, p);
        }

        public Punto GetElemento(string key)
        {
            return this.Puntos[key];
        }
        public void Remove(string key)
        {
            this.Puntos.Remove(key);
        }

        public void SumOrigen(Punto origen)
        {
            this.Centro.Sum(origen);
        }
        public int CantElements()
        {
            return this.Puntos.Count * 6;
        }

        public int CantPuntos()
        {
            return this.Puntos.Count;
        }
        public float[] ToArray()
        {
            List<float> _vertices = new() { };
            foreach (Punto p in this.Puntos.Values)
            {
                _vertices.Add(p.X + this.Centro.X);
                _vertices.Add(p.Y + this.Centro.Y);
                _vertices.Add(p.Z + this.Centro.Z);
                _vertices.Add(p.Color_X);
                _vertices.Add(p.Color_Y);
                _vertices.Add(p.Color_Z);
            }

            return _vertices.ToArray();
        }

        public void Dibujar()
        {

            GL.BufferData(BufferTarget.ArrayBuffer, this.CantElements() * sizeof(float), this.ToArray(), BufferUsageHint.StaticDraw);
            GL.DrawArrays(PrimitiveType.LineLoop, 0, this.CantPuntos());

        }
    }
}
