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
    public partial class SetupPlayer : Form
    {
        private Game game;
        private int playerNumber;
        private int roundNumber;
        private int currentPlayerNumber = 0;
        public SetupPlayer(Game game,int playerNumber, int roundNumber)
        {
            this.game = game;
            this.playerNumber = playerNumber;
            this.roundNumber = roundNumber;
            InitializeComponent();
        }

        private void btn_setupPlayer_Click(object sender, EventArgs e)
        {
            currentPlayerNumber++;
            if (currentPlayerNumber <= playerNumber)
            {
                label1.Text = "Player #" + (currentPlayerNumber+1) + "'s Name: ";
            }
            string playerName = textBox1.Text;
            TankController player;
            if (radioButton1.Checked)
            {
                player = new Human(playerName, TankType.GetTank(currentPlayerNumber), Game.GetColour(currentPlayerNumber));
                game.CreatePlayer(currentPlayerNumber, player);
            }
            else if (radioButton2.Checked)
            {
                player = new AIPlayer(playerName, TankType.GetTank(currentPlayerNumber), Game.GetColour(currentPlayerNumber));
                game.CreatePlayer(currentPlayerNumber, player);
            }
            textBox1.Text = "Player "+(currentPlayerNumber+1);
            if (currentPlayerNumber == playerNumber - 1)
            {
                btn_setupPlayer.Text = "Start Game";
            }
            else if (currentPlayerNumber == playerNumber)
            {
                game.StartGame();
                this.Close();
            }
        }
    }
}
