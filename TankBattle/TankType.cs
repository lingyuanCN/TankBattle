using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public abstract class TankType
    {
        public const int WIDTH = 4;
        public const int HEIGHT = 3;
        public const int NUM_TANKS = 1;

        public abstract int[,] DrawTank(float angle);

        public static void DrawLine(int[,] graphic, int X1, int Y1, int X2, int Y2)
        {
            int dx = X2 - X1;
            int dy = Y2 - Y1;
            int x;
            int y;
            if (dx == 0)
            {
                for(y = 0; y < graphic.GetLength(1); y++)
                {
                    if ((y >= Y1 && y <= Y2) || (y >= Y2 && y <= Y1))
                    {
                        graphic[X1, y] = 1;
                    }
                }
            }
            else
            {
                for (x = 0; x < graphic.Length; x++)
                {
                    y = Y1 + dy * (x - X1) / dx;
                    if ((x >= X1 && x <= X2) || (x >= X2 && x <= X1))
                    {
                        graphic[x, y] = 1;
                    }
                }
            }

            //throw new NotImplementedException();
        }

        public Bitmap CreateTankBitmap(Color tankColour, float angle)
        {
            int[,] tankGraphic = DrawTank(angle);
            int height = tankGraphic.GetLength(0);
            int width = tankGraphic.GetLength(1);

            Bitmap bmp = new Bitmap(width, height);
            Color transparent = Color.FromArgb(0, 0, 0, 0);
            Color tankOutline = Color.FromArgb(255, 0, 0, 0);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tankGraphic[y, x] == 0)
                    {
                        bmp.SetPixel(x, y, transparent);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, tankColour);
                    }
                }
            }

            // Outline each pixel
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    if (tankGraphic[y, x] != 0)
                    {
                        if (tankGraphic[y - 1, x] == 0)
                            bmp.SetPixel(x, y - 1, tankOutline);
                        if (tankGraphic[y + 1, x] == 0)
                            bmp.SetPixel(x, y + 1, tankOutline);
                        if (tankGraphic[y, x - 1] == 0)
                            bmp.SetPixel(x - 1, y, tankOutline);
                        if (tankGraphic[y, x + 1] == 0)
                            bmp.SetPixel(x + 1, y, tankOutline);
                    }
                }
            }

            return bmp;
        }

        public abstract int GetTankHealth();

        public abstract string[] GetWeapons();

        public abstract void ShootWeapon(int weapon, PlayerTank playerTank, Game currentGame);

        public static TankType GetTank(int tankNumber)
        {
            return new Tank_T1();
            throw new NotImplementedException();
        }

        //factory method???
        private class Tank_T1 : TankType
        {
            private int tankHealth;
            private string[] weapons;
            public override int[,] DrawTank(float angle)
            {
                int x, y;
                double radius = angle * Math.PI / 180.0;
                int[,] graphic = 
                    { 
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                       { 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0 },
                       { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                y = (int)(6 + Math.Sin(radius));
                x = (int)(7 + Math.Cos(radius));
                DrawLine(graphic, 7, 6, x, y);
                return graphic;
                //TankType.DrawLine(graphic,)
                throw new NotImplementedException();
            }

            public override int GetTankHealth()
            {
                tankHealth = 100;
                return tankHealth;
                throw new NotImplementedException();
            }

            public override string[] GetWeapons()
            {
                weapons = new string[] { "Standard shell" };
                return weapons;
                throw new NotImplementedException();
            }

            public override void ShootWeapon(int weapon, PlayerTank playerTank, Game currentGame)
            {
                throw new NotImplementedException();
            }
        }
    }
}
