using System;
using System.IO;
using System.Windows.Forms;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
namespace Program_Grafica
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearGame();
        }

        public static void CrearGame()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1920, 1080),
                Title = "LearnOpenTK - Creating a Window",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };
            using var game = new Game(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }

        private void cargarObjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog guardar_objeto = new OpenFileDialog();

            guardar_objeto.InitialDirectory = @"C:\Users\yordi\Descargas";
            guardar_objeto.Filter = "txt files (*.txt)|*.txt";
            guardar_objeto.FilterIndex = 2;
            guardar_objeto.RestoreDirectory = true;
            guardar_objeto.Title = "Guardar Objeto";
            if (guardar_objeto.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = guardar_objeto.FileName;
                    string ruta_final = @"C:\Users\yordi\source\repos\Program-Grafica\Program-Grafica\bin\Debug\net5.0-windows\Objetos\" + guardar_objeto.SafeFileName;

                    File.Copy(str_RutaArchivo, ruta_final);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        
    }
}
