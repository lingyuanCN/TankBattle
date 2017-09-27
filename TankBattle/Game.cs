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
        private int currentRound;
        private int startingTankController;
        public Game(int numPlayers, int numRounds)
        {
            playerCount = numPlayers;
            tankControllerArray = new TankController[numPlayers];//2~8 player
            List<Attack> attackList;
            roundNum = numRounds;//1~100 rounds

            //throw new NotImplementedException();
        }

        public int PlayerCount()
        {
            return playerCount;

            //throw new NotImplementedException();
        }

        public int GetRoundNumber()
        {
            throw new NotImplementedException();
        }

        public int GetMaxRounds()
        {
            return roundNum;

            //throw new NotImplementedException();
        }

        public void CreatePlayer(int playerNum, TankController player)
        {
            int index = playerNum - 1;
            tankControllerArray[index] = player;

            //throw new NotImplementedException();
        }

        public TankController GetPlayerNumber(int playerNum)
        {
            int index = playerNum - 1;
            return tankControllerArray[index];

            //throw new NotImplementedException();
        }

        public PlayerTank GetGameplayTank(int playerNum)
        {
            throw new NotImplementedException();
        }

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

            //throw new NotImplementedException();
        }

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

            //throw new NotImplementedException();
        }

        public static void Shuffle(int[] array)
        {
            int[] ar = array;
            ar = ar.OrderBy(x => Guid.NewGuid()).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ar[i];
            }

            //throw new NotImplementedException();
        }

        public void StartGame()
        {
            currentRound = 1;
            startingTankController = 0;
            CommenceRound();

            //throw new NotImplementedException();
        }

        public void CommenceRound()
        {
            //tankControllerArray[startingTankController]
            battlefield = new Map();
            int[] positionArray = CalculatePlayerPositions(playerCount);
            Shuffle(positionArray);
            for(int i = 0; i < tankControllerArray.Length; i++)
            {
                tankControllerArray[i].StartRound();
            }
            throw new NotImplementedException();
        }

        public Map GetArena()
        {
            return battlefield;
            throw new NotImplementedException();
        }

        public void DisplayPlayerTanks(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public PlayerTank CurrentPlayerTank()
        {
            throw new NotImplementedException();
        }

        public void AddAttack(Attack weaponEffect)
        {
            throw new NotImplementedException();
        }

        public bool WeaponEffectTick()
        {
            throw new NotImplementedException();
        }

        public void DrawWeaponEffects(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public void EndEffect(Attack weaponEffect)
        {
            throw new NotImplementedException();
        }

        public bool CheckCollidedTank(float projectileX, float projectileY)
        {
            throw new NotImplementedException();
        }

        public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
        {
            throw new NotImplementedException();
        }

        public bool Gravity()
        {
            throw new NotImplementedException();
        }

        public bool TurnOver()
        {
            throw new NotImplementedException();
        }

        public void RewardWinner()
        {
            throw new NotImplementedException();
        }

        public void NextRound()
        {
            throw new NotImplementedException();
        }
        
        public int GetWindSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
