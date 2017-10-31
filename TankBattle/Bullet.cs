using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// The Bullet class is a type of Attack that represents the a projectile 
    /// or shell launched by a PlayerTank. A Bullet is launched at a certain angle 
    /// and velocity and is affected by gravity and wind.
    /// </summary>
    public class Bullet : Attack
    {
        private float x;
        private float y;
        private float gravity;
        private Shrapnel explosion;
        private TankController player;
        private float x_velocity;
        private float y_velocity;

        /// <summary>
        /// This method constructs a new Bullet.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="angle"></param>
        /// <param name="power"></param>
        /// <param name="gravity"></param>
        /// <param name="explosion"></param>
        /// <param name="player"></param>
        public Bullet(float x, float y, float angle, float power, float gravity, Shrapnel explosion, TankController player)
        {
            this.x = x;
            this.y = y;
            this.gravity = gravity;
            this.explosion = explosion;
            this.player = player;
            float angleRadians = (90 - angle) * (float)Math.PI / 180;
            float magnitude = power / 50;
            x_velocity = (float)Math.Cos(angleRadians) * magnitude;
            y_velocity = (float)Math.Sin(angleRadians) * -magnitude;
        }

        /// <summary>
        /// This method moves the given projectile 
        /// according to its angle, power, gravity and the wind.
        /// </summary>
        public override void Process()
        {
            for(int i = 0; i < 10; i++)
            {
                x += x_velocity;
                y += y_velocity;
                x += game.GetWindSpeed() / 1000.0f;
                if (x < 0 || x > Map.WIDTH || y > Map.HEIGHT)
                {
                    game.EndEffect(this);
                }
                else if (game.CheckCollidedTank(x, y))
                {
                    player.ReportHit(x, y);
                    explosion.Explode(x, y);
                    game.AddAttack(explosion);
                    game.EndEffect(this);
                    return;
                }
                y_velocity += gravity;
            }
        }

        /// <summary>
        /// This method draws the Bullet as a small white circle.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="size"></param>
        public override void Paint(Graphics graphics, Size size)
        {
            float x = (float)this.x * size.Width / Map.WIDTH;
            float y = (float)this.y * size.Height / Map.HEIGHT;
            float s = size.Width / Map.WIDTH;

            RectangleF r = new RectangleF(x - s / 2.0f, y - s / 2.0f, s, s);
            Brush b = new SolidBrush(Color.WhiteSmoke);

            graphics.FillEllipse(b, r);
        }
    }
}
