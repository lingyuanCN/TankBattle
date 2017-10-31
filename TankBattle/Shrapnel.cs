using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    /// <summary>
    /// The Shrapnel class is a type of Attack that represents the payload attached to a Bullet. 
    /// An Shrapnel will inflict damage on tanks and destroy terrain within a radius.
    /// </summary>
    public class Shrapnel : Attack
    {
        private int explosionDamage;
        private int explosionRadius;
        private int earthDestructionRadius;
        private float x;
        private float y;
        private float lifetime;

        /// <summary>
        /// The Shrapnel takes the explosion damage, explosion radius 
        /// and earth destruction radius values it is passed and stores them as private fields.
        /// </summary>
        /// <param name="explosionDamage"></param>
        /// <param name="explosionRadius"></param>
        /// <param name="earthDestructionRadius"></param>
        public Shrapnel(int explosionDamage, int explosionRadius, int earthDestructionRadius)
        {
            this.explosionDamage = explosionDamage;
            this.explosionRadius = explosionRadius;
            this.earthDestructionRadius = earthDestructionRadius;
        }

        /// <summary>
        /// This method detonates the Shrapnel at the specified location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Explode(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.lifetime = 1.0f;
        }

        public override void Process()
        {
            lifetime -= 0.05f;
            if (lifetime <= 0)
            {
                game.InflictDamage(x, y, explosionDamage, explosionRadius);
                game.GetArena().DestroyGround(x, y, earthDestructionRadius);
                game.EndEffect(this);
            }
        }

        public override void Paint(Graphics graphics, Size displaySize)
        {
            float x = (float)this.x * displaySize.Width / Map.WIDTH;
            float y = (float)this.y * displaySize.Height / Map.HEIGHT;
            float radius = displaySize.Width * (float)((1.0 - lifetime) * explosionRadius * 3.0 / 2.0) / Map.WIDTH;

            int alpha = 0, red = 0, green = 0, blue = 0;

            if (lifetime < 1.0 / 3.0)
            {
                red = 255;
                //alpha = (int)(lifetime * 3.0 * 255);
            }
            else if (lifetime < 2.0 / 3.0)
            {
                red = 255;
                alpha = 255;
                green = (int)((lifetime * 3.0 - 1.0) * 255);
            }
            else
            {
                red = 255;
                alpha = 255;
                green = 255;
                blue = (int)((lifetime * 3.0 - 2.0) * 255);
            }

            RectangleF rect = new RectangleF(x - radius, y - radius, radius * 2, radius * 2);
            Brush b = new SolidBrush(Color.FromArgb(alpha, red, green, blue));

            graphics.FillEllipse(b, rect);
        }
    }
}
