using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenGL.Net
{
   public class DDA
    {
        static int y1,y2;
        static int x1,x2;
        public static void dda(int _x1,int _y1, int _x2, int _y2)
        {
            y1 = _y1;
            x1 = _x1;
            y2 = _y2;
            x2 = _x2;
            double i = 0.01;

            int count = 1;

            using (var game = new GameWindow())
            {
                
                GL.Begin(PrimitiveType.Points);

                Thread.Sleep(10);
                Console.WriteLine("1111111111111111111111111");

                GL.Color3(Color.Red);

                GL.Vertex2(100, 100);
                

                GL.End();

                game.Load += (sender, e) =>
                {
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };



                game.UpdateFrame += (sender, e) =>
                {

                    count = count + 1;

                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                    Thread.Sleep(1);

                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0.0f, 1000, 1000, 0.0f, 0.0f, 1.0f);
              
                    float y = y1;
                    float m = (y2 - y1) / (x2 - x1);
                    GL.Begin(PrimitiveType.Points);
                    for (int x = x1; x <= x2; x++, y += m)
                    {
                        m = (y2 - y1) / (x2 - x1);
                        GL.Color3(Color.Red);
                        GL.Vertex2(x, Math.Round(y));
                    }
                      
                        GL.End();
                    
                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }

    public class Bresenham
    {
        static int y1, y2;
        static int x1, x2;
        public static void bresenham(int _x1, int _y1, int _x2, int _y2)
        {
            y1 = _y1;
            x1 = _x1;
            y2 = _y2;
            x2 = _x2;
            double i = 0.01;

            int count = 1;

            using (var game = new GameWindow())
            {

                GL.Begin(PrimitiveType.Points);

                Thread.Sleep(10);
                Console.WriteLine("1111111111111111111111111");

                GL.Color3(Color.Red);

                GL.Vertex2(100, 100);


                GL.End();

                game.Load += (sender, e) =>
                {
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };



                game.UpdateFrame += (sender, e) =>
                {

                    count = count + 1;

                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                    Thread.Sleep(1);

                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0.0f, 1000, 1000, 0.0f, 0.0f, 1.0f);
                    GL.Begin(PrimitiveType.Points);

                    int x_err = 0, y_err = 0; // функции погрешностей по х и у
                    int dx = x2 - x1; int dy = y2 - y1; // приращения по х и у на всем отрезке
                    int incX = 0; int incY = 0; // шаги приращения по х и у =0
                    if (dx > 0) { incX = 1; } else if (dx != 0) { incX = -1; } // шаг приращения по х
                    if (dy > 0) { incY = 1; } else if (dy != 0) { incY = -1; } // шаг приращения по у
                    dx = Math.Abs(dx); dy = Math.Abs(dy);
                    int d;
                    if (dx > dy) {  d = dx; } else { d = dy; } // выбор max(dx,dy) в качестве тестовой величины
                    int x = x1, y = y1; GL.Vertex2(x, y); // установка пикселя в начале отрезка
                    for (int j = 1; j <= d; j++)
                    {
                        x_err += dx; y_err += dy; // приращение ошибки при перемещении на пиксель
                        if (x_err >= d) { x += incX; x_err -= d; } // условие шага по х
                        if (y_err >= d) { y += incY; y_err -= d; } // условие шага по у (+0.5d,-0.5d)!!!
                        GL.Vertex2(x, y);
                    }
                    GL.Color3(Color.Red);
                    GL.Vertex2(x, y);

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
    
    public class Krug
    {
        static int y1, y2;
        static int x1, x2;
        public static void krugBres()
        {
           
            double i = 0.01;

            int count = 1;  

            using (var game = new GameWindow())
            {

                GL.Begin(PrimitiveType.Points);

                Thread.Sleep(10);
                Console.WriteLine("1111111111111111111111111");

                GL.Color3(Color.Red);

                GL.Vertex2(100, 100);


                GL.End();

                game.Load += (sender, e) =>
                {
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };



                game.UpdateFrame += (sender, e) =>
                {

                    count = count + 1;

                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                    Thread.Sleep(1);

                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0.0f, 1000, 1000, 0.0f, 0.0f, 1.0f);
                    GL.Begin(PrimitiveType.Points);
                   int  x = 400;
                    int y = 400;
                    int r = 400;
                    int yd = r;
                    int xd = 0;
                    int d = 2 - 2 * r;
                    while (xd <= yd)
                    {
                        GL.Color3(Color.Red);
                        GL.Vertex2(x + xd, y + yd);
                        GL.Color3(Color.Blue);
                        GL.Vertex2(x - xd, y + yd); GL.Color3(Color.White);
                        GL.Vertex2(x + xd, y - yd); GL.Color3(Color.Green);
                        GL.Vertex2(x - xd, y - yd); GL.Color3(Color.Gray);
                        GL.Vertex2(x + yd, y + xd); GL.Color3(Color.Aqua);
                        GL.Vertex2(x - yd, y + xd); GL.Color3(Color.DarkOrchid);
                        GL.Vertex2(x + yd, y - xd); GL.Color3(Color.Ivory);
                        GL.Vertex2(x - yd, y - xd);
                        

                        if (d < 0)
                            d += (2 * xd) + 3;
                        else
                        {
                            d += (2 * (xd - yd)) + 5;
                            yd -= 1;
                        }
                        xd++;
                    }
                      
                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }

    public class Krug2
    {
        static int y1, y2;
        static int x1, x2;
        public static void krug2()
        {

            double i = 0.01;

            int count = 1;

            using (var game = new GameWindow())
            {

                GL.Begin(PrimitiveType.Points);

                Thread.Sleep(10);
                Console.WriteLine("1111111111111111111111111");

                GL.Color3(Color.Red);

                GL.Vertex2(100, 100);


                GL.End();

                game.Load += (sender, e) =>
                {
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };



                game.UpdateFrame += (sender, e) =>
                {

                    count = count + 1;

                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                    Thread.Sleep(1);

                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0.0f, 1000, 1000, 0.0f, 0.0f, 1.0f);
                    GL.Begin(PrimitiveType.Points);
                    int x = 400;
                    int y = 400;
                    int r = 400;
                    GL.Vertex2(x, y);
                    for (int j = 0; j < 360; j++)
                    {
                        GL.Vertex2(x + Math.Cos(j) * r, y + Math.Sin(j) * r);
                    }

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
        }
}

