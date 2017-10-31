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
    public partial class Leaderboard : Form
    {
        public Leaderboard(Game game, TankController[] tankControllerArray)
        {
            InitializeComponent();
            string[] name = new string[tankControllerArray.Length];
            int[] winRounds = new int[tankControllerArray.Length];
            for (int i=0;i<tankControllerArray.Length;i++)
            {
                name[i] = tankControllerArray[i].Identifier();
                winRounds[i] = tankControllerArray[i].GetVictories();
                listBox1.Items.Add(name[i] + " (" + winRounds[i] + " wins)");
            }
            int maxRound = 0;
            for(int i = 0; i < tankControllerArray.Length; i++)
            {
                if (winRounds[i] >= maxRound)
                {
                    maxRound = winRounds[i];
                    lb_winner.Text = name[i]+"won !";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
