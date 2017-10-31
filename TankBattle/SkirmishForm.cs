using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankBattle
{
    /// <summary>
    /// This form is where most of the actual gameplay happens. 
    /// </summary>
    public partial class SkirmishForm : Form
    {
        private Color landscapeColour;
        private Random rng = new Random();
        private Image backgroundImage = null;
        private int levelWidth = 160;
        private int levelHeight = 120;
        private Game currentGame;
        private static Random randomNumber = new Random();

        private BufferedGraphics backgroundGraphics;
        private BufferedGraphics gameplayGraphics;

        /// <summary>
        /// The constructor for SkirmishForm
        /// </summary>
        /// <param name="game"></param>
        public SkirmishForm(Game game)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            currentGame = game;
            string[] imageFilenames = {
                "Images\\background1.jpg",
                "Images\\background2.jpg",
                "Images\\background3.jpg",
                "Images\\background4.jpg"
            };
            Color[] landscapeColours = {
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 73, 58, 47),
                Color.FromArgb(255, 148, 116, 93),
                Color.FromArgb(255, 133, 119, 109)
            };
            int index = randomNumber.Next(0, imageFilenames.Length);
            backgroundImage = Image.FromFile(imageFilenames[index]);
            landscapeColour = landscapeColours[index];

            InitializeComponent();

            backgroundGraphics = InitialiseBuffer();
            gameplayGraphics = InitialiseBuffer();
            DrawBackground();
            DrawGameplay();
            NewTurn();
        }

        // From https://stackoverflow.com/questions/13999781/tearing-in-my-animation-on-winforms-c-sharp
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// This method is used to enable the control panel 
        /// so the (human) controller can control their tank.
        /// </summary>
        public void EnableHumanControl()
        {
            controlPanel.Enabled = true;
        }

        /// <summary>
        /// This method alters the value of the UpDownNumeric used 
        /// to control the angle, setting it to the provided value.
        /// </summary>
        /// <param name="angle"></param>
        public void SetAngle(float angle)
        {
            numericUpDown_Power.Value = (decimal)angle;
            currentGame.CurrentPlayerTank().SetAngle(angle);
        }

        /// <summary>
        /// This method alters the value of the TrackBar used 
        /// to control the power level, setting it to the provided value.
        /// </summary>
        /// <param name="power"></param>
        public void SetForce(int power)
        {
            trackBar_power.Value = power;
            currentGame.CurrentPlayerTank().SetForce(power);
        }

        /// <summary>
        /// This method changes the selected item in the ComboBox, 
        /// setting it to the provided value.
        /// </summary>
        /// <param name="weapon"></param>
        public void SelectWeapon(int weapon)
        {
            int index = currentGame.CurrentPlayerTank().GetPlayerWeapon();
            comboBox1.Text = currentGame.CurrentPlayerTank().GetTank().GetWeapons()[index];
        }

        /// <summary>
        /// This method fired the weapon
        /// </summary>
        public void Attack()
        {
            currentGame.CurrentPlayerTank().Attack();
            controlPanel.Enabled = false;
            timer1.Enabled = true;
        }


        private void DrawBackground()
        {
            Graphics graphics = backgroundGraphics.Graphics;
            Image background = backgroundImage;
            graphics.DrawImage(backgroundImage, new Rectangle(0, 0, displayPanel.Width, displayPanel.Height));

            Map battlefield = currentGame.GetArena();
            Brush brush = new SolidBrush(landscapeColour);

            for (int y = 0; y < Map.HEIGHT; y++)
            {
                for (int x = 0; x < Map.WIDTH; x++)
                {
                    if (battlefield.TerrainAt(x, y))
                    {
                        int drawX1 = displayPanel.Width * x / levelWidth;
                        int drawY1 = displayPanel.Height * y / levelHeight;
                        int drawX2 = displayPanel.Width * (x + 1) / levelWidth;
                        int drawY2 = displayPanel.Height * (y + 1) / levelHeight;
                        graphics.FillRectangle(brush, drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1);
                    }
                }
            }
        }

        public BufferedGraphics InitialiseBuffer()
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            Graphics graphics = displayPanel.CreateGraphics();
            Rectangle dimensions = new Rectangle(0, 0, displayPanel.Width, displayPanel.Height);
            BufferedGraphics bufferedGraphics = context.Allocate(graphics, dimensions);
            return bufferedGraphics;
        }

        private void displayPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = displayPanel.CreateGraphics();
            gameplayGraphics.Render(graphics);
        }

        /// <summary>
        /// This newly-created method is used to draw the gameplay elements of the screen
        /// </summary>
        private void DrawGameplay()
        {
            backgroundGraphics.Render(gameplayGraphics.Graphics);
            currentGame.DisplayPlayerTanks(gameplayGraphics.Graphics, displayPanel.Size);
            currentGame.DrawWeaponEffects(gameplayGraphics.Graphics, displayPanel.Size);
        }

        /// <summary>
        /// This newly-created method is used to update form elements to reflect who the current player is
        /// </summary>
        private void NewTurn()
        {
            PlayerTank currentPlayerTank =currentGame.CurrentPlayerTank();
            TankController currentTankController= currentPlayerTank.GetPlayerNumber();
            Text = "Tank Battle - Round "+currentGame.GetRoundNumber()+" of "+currentGame.GetMaxRounds();
            controlPanel.BackColor = currentTankController.PlayerColour();
            lb_player.Text = currentTankController.Identifier();
            SetAngle(currentPlayerTank.GetPlayerAngle());
            SetForce(currentPlayerTank.GetCurrentPower());

            if (currentGame.GetWindSpeed() > 0)
            {
                lb_windSpeed.Text = currentGame.GetWindSpeed()+" E";
            }
            else if (currentGame.GetWindSpeed() < 0)
            {
                lb_windSpeed.Text = -1 * currentGame.GetWindSpeed() + " W";
            }
            else
            {
                lb_windSpeed.Text = "0";
            }

            comboBox1.Items.Clear();
            TankType tank = currentPlayerTank.GetTank();
            string[] weapons =tank.GetWeapons();
            for(int i = 0; i < weapons.Length; i++)
            {
                comboBox1.Items.Add(weapons[i]);
            }
            SelectWeapon(currentPlayerTank.GetPlayerWeapon());
            currentTankController.StartTurn(this, currentGame);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlPanel.Enabled = false;
            Attack();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectWeapon(comboBox1.SelectedIndex);
        }

        private void numericUpDown_Power_ValueChanged(object sender, EventArgs e)
        {
            SetAngle((float)numericUpDown_Power.Value);
            DrawGameplay();
            displayPanel.Invalidate();
        }

        private void trackBar_power_ValueChanged(object sender, EventArgs e)
        {
            SetForce(trackBar_power.Value);
            lb_power.Text = trackBar_power.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isEffected = currentGame.WeaponEffectTick();
            if (!isEffected)
            {
                bool moved = currentGame.Gravity();
                DrawBackground();
                DrawGameplay();
                displayPanel.Invalidate();
                if (moved)
                {
                    return;
                }
                else
                {
                    timer1.Stop();
                    bool isOver = currentGame.TurnOver();
                    if (isOver)
                    {
                        NewTurn();
                    }
                    else
                    {
                        Dispose();
                        currentGame.NextRound();
                        return;
                    }

                }
            }
            else
            {
                DrawGameplay();
                displayPanel.Invalidate();
                return;
            }
        }
    }
}
