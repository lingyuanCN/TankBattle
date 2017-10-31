using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    /// <summary>
    /// This abstract class represents either a computer or human player. A player has an associated name, TankType and colour, and also keeps track of the number of rounds won by that player. The AIPlayer and Human inherit from TankController.
    /// </summary>
    abstract public class TankController
    {
        private string name;
        private TankType tank;
        private Color colour;
        private int winRounds;

        /// <summary>
        /// This constructor passes in this TankController's name, TankType and colour.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tank"></param>
        /// <param name="colour"></param>
        public TankController(string name, TankType tank, Color colour)
        {
            this.name = name;
            this.tank = tank;
            this.colour = colour;
        }

        /// <summary>
        /// This method returns the TankType associated with this TankController.
        /// </summary>
        /// <returns></returns>
        public TankType GetTank()
        {
            return tank;
        }

        /// <summary>
        /// This method returns this TankController's name.
        /// </summary>
        /// <returns></returns>
        public string Identifier()
        {
            return name;
        }

        /// <summary>
        /// This method returns the colour associated with this TankController.
        /// </summary>
        /// <returns></returns>
        public Color PlayerColour()
        {
            return colour;
        }

        /// <summary>
        /// This method increments the number of rounds won by this player by 1.
        /// </summary>
        public void Winner()
        {
            winRounds++;
        }

        /// <summary>
        /// This method returns the number of rounds that have been won by this player.
        /// </summary>
        /// <returns></returns>
        public int GetVictories()
        {
            return winRounds;
        }

        public abstract void StartRound();

        public abstract void StartTurn(SkirmishForm gameplayForm, Game currentGame);

        public abstract void ReportHit(float x, float y);
    }
}
