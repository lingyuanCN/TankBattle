using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class AIPlayer : TankController
    {
        private static Random randomNumber = new Random();

        public AIPlayer(string name, TankType tank, Color colour) : base(name, tank, colour)
        {
            //throw new NotImplementedException();
        }

        public override void StartRound()
        {
            //throw new NotImplementedException();
        }

        public override void StartTurn(SkirmishForm gameplayForm, Game currentGame)
        {
            int windforce = currentGame.GetWindSpeed();
            int[] position = Game.CalculatePlayerPositions(currentGame.PlayerCount());
            int distance = position[1] - position[0];
            int angle = randomNumber.Next(45);
            int force = randomNumber.Next(5, 101);
            gameplayForm.SetAngle(angle);
            gameplayForm.SetForce(force);
            gameplayForm.Attack();
            //throw new NotImplementedException();
        }

        public override void ReportHit(float x, float y)
        {
            //throw new NotImplementedException();
        }
    }
}
