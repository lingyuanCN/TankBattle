using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    /// <summary>
    /// This is a concrete class that extends the TankController class, 
    /// providing functionality specific to human-controlled TankControllers.
    /// </summary>
    public class Human : TankController
    {
        /// <summary>
        /// This method doesn't do anything
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tank"></param>
        /// <param name="colour"></param>
        public Human(string name, TankType tank, Color colour) : base(name, tank, colour)
        {
            
        }

        /// <summary>
        /// This method doesn't do anything
        /// </summary>
        public override void StartRound()
        {
            
        }

        /// <summary>
        /// This method call EnableHumanControl() on the SkirmishForm passed to this method.
        /// </summary>
        /// <param name="gameplayForm"></param>
        /// <param name="currentGame"></param>
        public override void StartTurn(SkirmishForm gameplayForm, Game currentGame)
        {
            gameplayForm.EnableHumanControl();
        }

        /// <summary>
        /// This method doesn't do anything
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void ReportHit(float x, float y)
        {

        }
    }
}
