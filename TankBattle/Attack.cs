using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public abstract class Attack
    {
        public void RecordCurrentGame(Game game)
        {
            throw new NotImplementedException();
        }

        public abstract void Process();
        public abstract void Paint(Graphics graphics, Size displaySize);
    }
}
