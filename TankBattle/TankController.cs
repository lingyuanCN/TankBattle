using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    abstract public class TankController
    {
        private string name;
        private TankType tank;
        private Color colour;
        private int winRounds;
        public TankController(string name, TankType tank, Color colour)
        {
            this.name = name;
            this.tank = tank;
            this.colour = colour;

            //throw new NotImplementedException();
        }
        public TankType GetTank()
        {
            return tank;

            //throw new NotImplementedException();
        }
        public string Identifier()
        {
            return name;

            //throw new NotImplementedException();
        }
        public Color PlayerColour()
        {
            return colour;

            //throw new NotImplementedException();
        }
        public void Winner()
        {
            winRounds++;

            //throw new NotImplementedException();
        }
        public int GetVictories()
        {
            return winRounds;

            //throw new NotImplementedException();
        }

        public abstract void StartRound();

        public abstract void StartTurn(SkirmishForm gameplayForm, Game currentGame);

        public abstract void ReportHit(float x, float y);
    }
}
