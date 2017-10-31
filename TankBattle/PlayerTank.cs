using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    /// <summary>
    /// This class represents a tank on the battlefield, 
    /// as distinct from TankType which represents a particular model of tank.
    /// </summary>
    public class PlayerTank
    {
        private Game game;
        private TankController player;
        private int tankX;
        private int tankY;
        private TankType currentTankType;
        private int currentDurability;
        private float angle;
        private int power;
        private int currentWeapon;
        private Bitmap bmp;

        /// <summary>
        /// This constructor stores player, tankX, tankY and game as private fields of PlayerTank.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="tankX"></param>
        /// <param name="tankY"></param>
        /// <param name="game"></param>
        public PlayerTank(TankController player, int tankX, int tankY, Game game)
        {
            this.game = game;
            this.player = player;
            this.tankX = tankX;
            this.tankY = tankY;
            currentTankType = player.GetTank();
            currentDurability = currentTankType.GetTankHealth();
            angle = 0F;
            power = 25;
            currentWeapon = 0;
            bmp = currentTankType.CreateTankBitmap(player.PlayerColour(), angle);
        }

        /// <summary>
        /// This returns the TankController associated with this PlayerTank.
        /// </summary>
        /// <returns></returns>
        public TankController GetPlayerNumber()
        {
            return player;
        }

        /// <summary>
        /// This returns the TankType associated with this PlayerTank.
        /// </summary>
        /// <returns></returns>
        public TankType GetTank()
        {
            return currentTankType;
        }

        /// <summary>
        /// This returns the PlayerTank's current aiming angle.
        /// </summary>
        /// <returns></returns>
        public float GetPlayerAngle()
        {
            return angle;
        }

        /// <summary>
        /// This method sets the PlayerTank's current aiming angle.
        /// </summary>
        /// <param name="angle"></param>
        public void SetAngle(float angle)
        {
            this.angle = angle;
        }

        /// <summary>
        /// This returns the PlayerTank's current turret velocity.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPower()
        {
            return power;
        }

        /// <summary>
        /// This method sets the PlayerTank's current turret velocity.
        /// </summary>
        /// <param name="power"></param>
        public void SetForce(int power)
        {
            this.power = power;
        }

        /// <summary>
        /// This returns the index of the current weapon equipped by the PlayerTank.
        /// </summary>
        /// <returns></returns>
        public int GetPlayerWeapon()
        {
            return currentWeapon;
        }

        /// <summary>
        /// This method sets the PlayerTank's current weapon.
        /// </summary>
        /// <param name="newWeapon"></param>
        public void SelectWeapon(int newWeapon)
        {
            currentWeapon = newWeapon;
        }

        /// <summary>
        /// This method draws the PlayerTank to graphics, scaled to the provided displaySize. 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="displaySize"></param>
        public void Paint(Graphics graphics, Size displaySize)
        {
            int drawX1 = displaySize.Width * tankX / Map.WIDTH;
            int drawY1 = displaySize.Height * tankY / Map.HEIGHT;
            int drawX2 = displaySize.Width * (tankX + TankType.WIDTH) / Map.WIDTH;
            int drawY2 = displaySize.Height * (tankY + TankType.HEIGHT) / Map.HEIGHT;
            graphics.DrawImage(currentTankType.CreateTankBitmap(player.PlayerColour(), angle), new Rectangle(drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1));

            int drawY3 = displaySize.Height * (tankY - TankType.HEIGHT) / Map.HEIGHT;
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.White);

            int pct = currentDurability * 100 / currentTankType.GetTankHealth();
            if (pct < 100)
            {
                graphics.DrawString(pct + "%", font, brush, new Point(drawX1, drawY3));
            }
        }

        /// <summary>
        /// Returns the current horizontal position of the PlayerTank.
        /// </summary>
        /// <returns></returns>
        public int X()
        {
            return tankX;
        }

        /// <summary>
        /// Returns the current vertical position of the PlayerTank.
        /// </summary>
        /// <returns></returns>
        public int Y()
        {
            return tankY;
        }

        /// <summary>
        /// This method call its own GetTank() method, then call ShootWeapon()
        /// </summary>
        public void Attack()
        {
            GetTank().ShootWeapon(currentWeapon, this, game);
        }

        /// <summary>
        /// This inflicts damageAmount damage, reducing this PlayerTank's durability by the given amount.
        /// </summary>
        /// <param name="damageAmount"></param>
        public void InflictDamage(int damageAmount)
        {
            currentDurability -= damageAmount;
        }

        /// <summary>
        /// This method check if the tank is alive
        /// </summary>
        /// <returns></returns>
        public bool Alive()
        {
            if (currentDurability > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method check if the tank is moved.
        /// </summary>
        /// <returns></returns>
        public bool Gravity()
        {
            Map map = game.GetArena();
            if (!Alive())
            {
                return false;
            }
            else
            {
                if (map.TankFits(tankX, tankY + 1))
                {
                    return false;
                }
                else
                {
                    tankY++;
                    currentDurability--;
                }
                if (Y() >= (Map.HEIGHT - TankType.HEIGHT))
                {
                    currentDurability = 0;
                }
            }
            return true;
        }
    }
}
