using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    /// <summary>
    /// TankType is an abstract class representing a generic tank model. 
    /// You will need to create at least one concrete class inheriting from it for this game to work. 
    /// Different tanks can have different graphics, weapons, armour etc.
    /// </summary>
    public abstract class TankType
    {
        public const int WIDTH = 4;
        public const int HEIGHT = 3;
        public const int NUM_TANKS = 1;

        /// <summary>
        /// This method draws the tank into an array and returns it.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public abstract int[,] DrawTank(float angle);

        /// <summary>
        /// This method draws a line on the row-major two-dimensional array 'graphic' connecting X1,Y2 to X2,Y2.
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="X1"></param>
        /// <param name="Y1"></param>
        /// <param name="X2"></param>
        /// <param name="Y2"></param>
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
                        graphic[y, X1] = 1;
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
                        graphic[y, x] = 1;
                    }
                }
            }
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

        /// <summary>
        /// This abstract method gets the starting durability of this type of tank. 
        /// </summary>
        /// <returns></returns>
        public abstract int GetTankHealth();

        /// <summary>
        /// This abstract method returns an array containing a list of weapons that this tank has.
        /// </summary>
        /// <returns></returns>
        public abstract string[] GetWeapons();

        /// <summary>
        /// This abstract method is used to handle firing the specified weapon from the tank playerTank.
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="playerTank"></param>
        /// <param name="currentGame"></param>
        public abstract void ShootWeapon(int weapon, PlayerTank playerTank, Game currentGame);

        /// <summary>
        /// This is a factory method, used to create a new object of a concrete class that inherits from TankType and return it.
        /// </summary>
        /// <param name="tankNumber"></param>
        /// <returns></returns>
        public static TankType GetTank(int tankNumber)
        {
            switch (tankNumber)
            {
                case 1:
                    return new Tank_T1();
                default:
                    return new Tank_T1();
            }
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
                y = (int)(6 - 5 * Math.Cos(radius));
                x = (int)(7 + 5 * Math.Sin(radius));
                DrawLine(graphic, 7, 6, x, y);
                return graphic;
            }

            public override int GetTankHealth()
            {
                tankHealth = 100;
                return tankHealth;
            }

            public override string[] GetWeapons()
            {
                weapons = new string[] { "Standard shell" };
                return weapons;
            }

            public override void ShootWeapon(int weapon, PlayerTank playerTank, Game currentGame)
            {
                float x = playerTank.X() + WIDTH / 2;
                float y = playerTank.Y() + HEIGHT / 2;
                TankController player = playerTank.GetPlayerNumber();
                Shrapnel shrapnel = new Shrapnel(100, 4, 4);
                Bullet bullet = new Bullet(x, y, playerTank.GetPlayerAngle(), playerTank.GetCurrentPower(), 0.01f, shrapnel, player);
                currentGame.AddAttack(bullet);
            }
        }
    }
}
