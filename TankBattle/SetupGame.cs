using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankBattle
{
    public partial class SetupGame : Form
    {
        public SetupGame()
        {
            InitializeComponent();
        }

        private void btn_setupGame_Click(object sender, EventArgs e)
        {
            int playerNumber = (int)playerNum.Value;
            int roundNumber = (int)roundNum.Value;
            Game game = new Game(playerNumber, roundNumber);
            Form setupPlayer = new SetupPlayer(game, playerNumber, roundNumber);
            setupPlayer.Show();

            //game.StartGame();
        }
    }
}
