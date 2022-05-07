using OpenTK.Mathematics;
namespace Program_Grafica
{
    class Punto
    {
        private float EjeX { get; set; }
        private float EjeY { get; set; }
        private float EjeZ { get; set; }
        private float ColorX { get; set; }
        private float ColorY { get; set; }
        private float ColorZ { get; set; }
        //properties
        public float X { get { return EjeX; } set { EjeX = value; } }
        public float Y { get { return EjeY; } set { EjeY = value; } }
        public float Z { get { return EjeZ; } set { EjeZ = value; } }
        public float Color_X { get { return ColorX; } set { ColorX = value; } }
        public float Color_Y { get { return ColorY; } set { ColorY = value; } }
        public float Color_Z { get { return ColorZ; } set { ColorZ = value; } }

        public Punto() : this(0, 0, 0, 0, 0, 0) { }
        public Punto(float x, float y, float z, float colorX, float colorY, float colorZ)
        {
            this.EjeX = x;
            this.EjeY = y;
            this.EjeZ = z;
            this.ColorX = colorX;
            this.ColorY = colorY;
            this.ColorZ = colorZ;
        }

        public Punto(Vector3 punto, Vector3 color)
        {
            this.EjeX = punto.X;
            this.EjeY = punto.Y;
            this.EjeZ = punto.Z;
            this.ColorX = color.X;
            this.ColorY = color.Y;
            this.ColorZ = color.Z;
        }

        public Punto(Punto p)
        {
            this.EjeX = p.X;
            this.EjeY = p.Y;
            this.EjeZ = p.Z;
            this.ColorX = p.Color_X;
            this.ColorY = p.Color_Y;
            this.ColorZ = p.Color_Z;
        }

        public void Sum(Punto p)
        {
            this.EjeX += p.X;
            this.EjeY += p.Y;
            this.EjeZ += p.Z;
            this.ColorX += p.Color_X;
            this.ColorY += p.Color_Y;
            this.ColorZ += p.Color_Z;
        }

    }
}
