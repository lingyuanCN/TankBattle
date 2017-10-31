using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TankBattle
{
    public class Game
    {
        private TankController[] tankControllerArray;
        private Map battlefield;
        private const int MAX_PLAYER_NUM = 8;
        private const int MAX_ROUND_NUM = 100;
        private int roundNum;
        private int playerCount;
        private int currentPlayer;
        private int currentRound;
        private int startingTankController;
        private PlayerTank[] playerTankArray;
        List<Attack> attackList;
        private int windSpeed;
        private static Random randomNumber = new Random();
        private SkirmishForm skirmishForm;

        /// <summary>
        /// Game's constructor, initialize the game parameters
        /// </summary
        /// <param name="numPlayers"></param>
        /// <param name="numRounds"></param>
        public Game(int numPlayers, int numRounds)
        {
            playerCount = numPlayers;
            tankControllerArray = new TankController[numPlayers];//2~8 player
            attackList = new List<Attack>();
            roundNum = numRounds;//1~100 rounds
        }

        /// <summary>
        /// This method returns the total number of players in the game
        /// </summary>
        /// <returns></returns>
        public int PlayerCount()
        {
            return playerCount;
        }

        /// <summary>
        /// This method returns the current round of gameplay
        /// </summary>
        /// <returns></returns>
        public int GetRoundNumber()
        {
            return currentRound;
        }

        /// <summary>
        /// This method returns the total number of rounds the game will last for
        /// </summary>
        /// <returns></returns>
        public int GetMaxRounds()
        {
            return roundNum;
        }

        /// <summary>
        /// This method takes a player number (guaranteed to be between 1 and the number of players) 
        /// and sets the appropriate field in Game's TankController array to player.
        /// </summary>
        /// <param name="playerNum">Number of player, start from 1</param>
        /// <param name="player">instance of TankController</param>
        public void CreatePlayer(int playerNum, TankController player)
        {
            int index = playerNum - 1;
            tankControllerArray[index] = player;
        }

        /// <summary>
        /// This method takes a player number (between 1 and the number of players) 
        /// and returns the appropriate TankController from the TankController array. 
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public TankController GetPlayerNumber(int playerNum)
        {
            int index = playerNum - 1;
            return tankControllerArray[index];
        }

        public PlayerTank GetGameplayTank(int playerNum)
        {
            int index = playerNum - 1;
            return playerTankArray[index];

            //throw new NotImplementedException();
        }

        /// <summary>
        /// This static method takes a player number (between 1 and the number of players) 
        /// and returns an appropriate colour to be used to represent that player.
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public static Color GetColour(int playerNum)
        {
            Color[] colorArray = new Color[MAX_PLAYER_NUM];
            for(int i = 0; i < MAX_PLAYER_NUM; i++)
            {
                colorArray[i] = new Color();
            }
            colorArray[0] = Color.Red;
            colorArray[1] = Color.Green;
            colorArray[2] = Color.Yellow;
            colorArray[3] = Color.LightBlue;
            colorArray[4] = Color.DarkBlue;
            colorArray[5] = Color.RosyBrown;
            colorArray[6] = Color.Salmon;
            colorArray[7] = Color.White;
            return colorArray[playerNum - 1];
        }

        /// <summary>
        /// Given a number of players, this static method returns an array giving the horizontal positions of those players on the map. 
        /// </summary>
        /// <param name="numPlayers"></param>
        /// <returns></returns>
        public static int[] CalculatePlayerPositions(int numPlayers)
        {
            double maxCoord = Map.WIDTH;
            double playerDistance = maxCoord / numPlayers;
            double borderWidth = 0.5 * playerDistance;
            double coordinate = borderWidth;
            int[] positionsArray = new int[numPlayers];
            for(int i = 0; i < numPlayers; i++)
            {
                positionsArray[i] = (int)(coordinate - TankType.WIDTH/2.0);
                coordinate += playerDistance;
            }
            return positionsArray;
        }

        /// <summary>
        /// This method, given an array of at least 1, randomises the other of the numbers in it
        /// </summary>
        /// <param name="array"></param>
        public static void Shuffle(int[] array)
        {
            int[] ar = array;
            ar = ar.OrderBy(x => Guid.NewGuid()).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ar[i];
            }
        }

        /// <summary>
        /// This method begins a new game, which involves doing the following.
        /// </summary>
        public void StartGame()
        {
            currentRound = 1;
            startingTankController = 0;
            CommenceRound();
        }

        /// <summary>
        /// This method begins a new round of gameplay.
        /// </summary>
        public void CommenceRound()
        {
            currentPlayer = startingTankController;
            battlefield = new Map();
            int[] tanksPositionArray = CalculatePlayerPositions(tankControllerArray.Length);
            for (int i = 0; i < tankControllerArray.Length; i++)
            {
                tankControllerArray[i].StartRound();
            }
            Shuffle(tanksPositionArray);
            playerTankArray = new PlayerTank[tankControllerArray.Length];
            for (int j = 0; j < playerTankArray.Length; j++)
            {
                playerTankArray[j] = new PlayerTank(tankControllerArray[j], tanksPositionArray[j], battlefield.TankPlace(tanksPositionArray[j]), this);
            }
            windSpeed = randomNumber.Next(-100, 101);
            skirmishForm = new SkirmishForm(this);
            skirmishForm.Show();
        }

        /// <summary>
        /// This method returns the current Map used by the game.
        /// </summary>
        /// <returns></returns>
        public Map GetArena()
        {
            return battlefield;
        }

        /// <summary>
        /// This method tells all the PlayerTanks to draw themselves. 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="displaySize"></param>
        public void DisplayPlayerTanks(Graphics graphics, Size displaySize)
        {
            for (int i = 0; i < playerTankArray.Length; i++)
            {
                if (playerTankArray[i].Alive())
                {
                    playerTankArray[i].Paint(graphics, displaySize);
                }
            }
        }

        /// <summary>
        /// This method returns the PlayerTank associated with the current player.
        /// </summary>
        /// <returns></returns>
        public PlayerTank CurrentPlayerTank()
        {
            return playerTankArray[currentPlayer];
        }

        /// <summary>
        /// This method adds the given Attack to its list of Attacks.
        /// </summary>
        /// <param name="weaponEffect"></param>
        public void AddAttack(Attack weaponEffect)
        {
            attackList.Add(weaponEffect);
            weaponEffect.RecordCurrentGame(this);
        }

        /// <summary>
        /// This method loops through all Attacks in the array, calling Process() on each.
        /// </summary>
        /// <returns></returns>
        public bool WeaponEffectTick()
        {
            for(int i = 0; i < attackList.Count; i++)
            {
                if (attackList[i] != null)
                {
                    attackList[i].Process();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method loops through all Attacks in the array, calling Paint() on each. 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="displaySize"></param>
        public void DrawWeaponEffects(Graphics graphics, Size displaySize)
        {
            for (int i = 0; i < attackList.Count; i++)
            {
                if (attackList[i] != null)
                {
                    attackList[i].Paint(graphics, displaySize);
                }
            }
        }

        /// <summary>
        /// This method removes the Attack referenced by weaponEffect from the array or list used by Game to store active Attacks.
        /// </summary>
        /// <param name="weaponEffect"></param>
        public void EndEffect(Attack weaponEffect)
        {
            attackList.Remove(weaponEffect);
        }

        /// <summary>
        /// This method returns true if a Bullet at projectileX, projectileY will hit something.
        /// </summary>
        /// <param name="projectileX"></param>
        /// <param name="projectileY"></param>
        /// <returns></returns>
        public bool CheckCollidedTank(float projectileX, float projectileY)
        {
            if (projectileX < 0 || projectileX > Map.WIDTH || projectileY < 0 || projectileY > Map.HEIGHT)
            {
                return false;
            }
            else if (battlefield.TerrainAt((int)projectileX, (int)projectileY))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < playerTankArray.Length; i++)
                {
                    if ((projectileX > playerTankArray[i].X()) && (projectileX < (playerTankArray[i].X() + TankType.WIDTH)) && (projectileY > playerTankArray[i].Y()) && (projectileY < (playerTankArray[i].Y() + TankType.HEIGHT)) && (currentPlayer != i))
                    {
                        if (playerTankArray[i].Alive())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This method inflicts up to explosionDamage damage on any PlayerTanks within 
        /// the circle described by damageX, damageY and radius.
        /// </summary>
        /// <param name="damageX"></param>
        /// <param name="damageY"></param>
        /// <param name="explosionDamage"></param>
        /// <param name="radius"></param>
        public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
        {
            for(int i = 0; i < playerTankArray.Length; i++)
            {
                int x = playerTankArray[i].X() + TankType.WIDTH / 2;
                int y = playerTankArray[i].Y() + TankType.HEIGHT / 2;
                float dist = (float)Math.Sqrt(Math.Pow(x - damageX, 2) + Math.Pow(y - damageY, 2));
                if (playerTankArray[i].Alive())
                {
                    if (dist < (radius / 2))
                    {
                        playerTankArray[i].InflictDamage((int)explosionDamage);
                    }
                    else if (dist > radius / 2 && dist <= radius)
                    {
                        playerTankArray[i].InflictDamage((int)(explosionDamage * (radius - dist) / radius));
                    }
                    else
                    {
                        playerTankArray[i].InflictDamage(0);
                    }
                }
            }
        }

        /// <summary>
        /// This method is called after all Attack animations have finished and moves any terrain 
        /// and/or PlayerTanks that are floating in the air down. 
        /// </summary>
        /// <returns></returns>
        public bool Gravity()
        {
            bool isMoved = false;
            if (battlefield.Gravity()==true)
            {
                isMoved = true;
            }
            for(int i = 0; i < playerTankArray.Length; i++)
            {
                if (playerTankArray[i].Gravity()==true)
                {
                    isMoved = true;
                }
            }
            return isMoved;
        }

        public bool TurnOver()
        {
            int aliveNum = 0;
            for (int i = 0; i < playerTankArray.Length; i++)
            {
                if (playerTankArray[i].Alive())
                {
                    aliveNum++;
                }
            }
            if (aliveNum >= 2)
            {

                for(int i = currentPlayer+1; i <= playerCount; i++)
                {
                    if (i == playerCount)
                    {
                        i = 0;
                    }
                    if (playerTankArray[i].Alive())
                    {
                        currentPlayer = i;
                        windSpeed += randomNumber.Next(-10, 11);
                        if (windSpeed < -100)
                        {
                            windSpeed = -100;
                        }
                        else if(windSpeed > 100)
                        {
                            windSpeed = 100;
                        }
                        break;
                    }
                }
                return true;
            }
            else
            {
                RewardWinner();
                return false;
            }
        }

        /// <summary>
        /// This method finds out which player won the round and rewards that player with a point.
        /// </summary>
        public void RewardWinner()
        {
            for (int i = 0; i < playerTankArray.Length; i++)
            {
                if (playerTankArray[i].Alive())
                {
                    playerTankArray[i].GetPlayerNumber().Winner();
                }
            }
        }

        /// <summary>
        /// This method is called by SkirmishForm after the round is over 
        /// </summary>
        public void NextRound()
        {
            currentRound++;
            if (currentRound <= roundNum)
            {
                startingTankController++;
                if (startingTankController == playerCount)
                {
                    startingTankController = 0;
                }
                CommenceRound();
            }
            else
            {
                Form leaderboard = new Leaderboard(this, tankControllerArray);
                leaderboard.Show();
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// This method returns the current wind speed
        /// </summary>
        /// <returns></returns>
        public int GetWindSpeed()
        {
            return windSpeed;
        }
    }
}
