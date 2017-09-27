using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class Map
    {
        public const int WIDTH = 160;
        public const int HEIGHT = 120;
        private bool[,] battlefield;
        private static Random randomNumber = new Random();

        public Map()
        {
            battlefield = new bool[WIDTH, HEIGHT];
            int height = randomNumber.Next(HEIGHT/4, 3*HEIGHT/4);
            for (int i = 0; i < 160; i++)
            {
                int temp = height + randomNumber.Next(-1, 2);
                while (temp < 0 || temp > HEIGHT-TankType.HEIGHT)
                {
                    temp = height + randomNumber.Next(-1, 2);
                }
                height = temp;
                for (int j = 0; j < HEIGHT; j++)
                {
                    if (j < HEIGHT - height)
                    {
                        battlefield[i, j] = false;
                    }
                    else
                    {
                        battlefield[i, j] = true;
                    }
                }
            }

            //throw new NotImplementedException();
        }

        public bool TerrainAt(int x, int y)
        {
            return battlefield[x, y];
            throw new NotImplementedException();
        }

        public bool TankFits(int x, int y)
        {
            for(int i=0; i < TankType.WIDTH; i++)
            {
                for(int j = 0; j < TankType.HEIGHT; j++)
                {
                    if (battlefield[x + i, y + j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;

            throw new NotImplementedException();
        }

        public int TankPlace(int x)
        {
            int y;
            for(y = 0; y < HEIGHT; y++)
            {
                if (TankFits(x, y))
                {
                    return y - 1;
                }
            }
            return y - 1;

            //throw new NotImplementedException();
        }

        public void DestroyGround(float destroyX, float destroyY, float radius)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                for(int x = 0; x < WIDTH; x++)
                {
                    if (((x - destroyX) * (x - destroyX) + (y - destroyY) * (y - destroyY)) <= (radius * radius))
                    {
                        battlefield[x, y] = false;
                    }
                }
            }

            //throw new NotImplementedException();
        }

        public bool Gravity()
        {
            bool isChanged = false;
            for(int x = 0; x < WIDTH; x++)
            {
                for (int y = HEIGHT - 1; y > 0; y--)
                {
                    if (battlefield[x, y] == false && battlefield[x, y - 1] == true)
                    {
                        battlefield[x, y - 1] = false;
                        battlefield[x, y] = true;
                        isChanged = true;
                    }
                }
            }
            return isChanged;

            //throw new NotImplementedException();
        }
    }
}
