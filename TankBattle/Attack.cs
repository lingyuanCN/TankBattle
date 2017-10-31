using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// This abstract class represents a generic effect created by a PlayerTank's attack. 
    /// Both Shrapnel and Bullet come under this umbrella.
    /// </summary>
    public abstract class Attack
    {
        protected Game game;

        /// <summary>
        /// This method record the current game to the protected field.
        /// </summary>
        /// <param name="game"></param>
        public void RecordCurrentGame(Game game)
        {
            this.game = game;
        }

        public abstract void Process();
        public abstract void Paint(Graphics graphics, Size displaySize);
    }
}
