using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using Program_Grafica.Common;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Program_Grafica
{
    class Game : GameWindow
    {
        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private Shader _shader;
        private Matrix4 _view;
        private Matrix4 _projection;
        public Escenario escenario;

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings) {
            escenario = new Escenario();
        }
        public static Objeto DeSerializeObjeto(string filename)
        {
            string jsonString = File.ReadAllText("Objetos/" + filename);
            return JsonSerializer.Deserialize<Objeto>(jsonString);

        }
        public void CargarDatos()
        {
            DirectoryInfo _directory = new DirectoryInfo(@"Objetos");
            FileInfo[] files = _directory.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                escenario.Add(file.Name, DeSerializeObjeto(file.Name));
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);


            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            CargarDatos();
            
           
            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            //_projection = Matrix4.CreateOrthographicOffCenter(-1f, 1f, -1f, 1f, 0.1f, 100.0f);
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
            base.OnLoad();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BindVertexArray(_vertexArrayObject);
            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(45.0f));

            _shader.Use();
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);
            escenario.Dibujar();
            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(_vertexBufferObject);

            GL.DeleteProgram(_shader.Handle);


            base.OnUnload();
        }
    }
}