using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class GameLogic
    {
        private int currentTurn;
        private List<Character> turnOrderHeros;
        private List<Character> turnOrderEnemies;
        private int encounterCount;

        public event EventHandler<UpdateEventArgs> Update;

        private Random characterInt = new Random();

        public GameLogic()
        {
            turnOrderHeros = new List<Character>();
            turnOrderEnemies = new List<Character>();
            FillTurnOrderHeros();
            FillTurnOrderEnemies();
            currentTurn = 0;
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void FillTurnOrderHeros()
        {
            Character hero1 = PickHeroCharacter();
            turnOrderHeros.Add(hero1);

            Character hero2 = PickHeroCharacter();
            if(hero1.Speed >= hero2.Speed)
            {
                turnOrderHeros.Add(hero2);
            }
            else
            {
                turnOrderHeros[0] = hero2;
                turnOrderHeros.Add(hero1);
            }
            
            Character hero3 = PickHeroCharacter();
            if(hero2.Speed >= hero3.Speed)
            {
                turnOrderHeros.Add(hero3);
            }
            else if(hero1.Speed >= hero3.Speed && hero3.Speed > hero2.Speed)
            {
                turnOrderHeros[0] = hero1;
                turnOrderHeros[1] = hero3;
                turnOrderHeros.Add(hero2);
            }
            else 
            {
                turnOrderHeros[0] = hero3;
                turnOrderHeros[1] = hero1;
                turnOrderHeros.Add(hero2);
            }
        }

        public void FillTurnOrderEnemies()
        {
            int character = characterInt.Next(3);

            Character enemy1 = PickEnemyCharacter();
            turnOrderEnemies.Add(enemy1);

            if (character == 1)
            {
                Character enemy2 = PickEnemyCharacter();
                turnOrderEnemies.Add(enemy2);
            }
            else if (character == 2)
            {
                Character enemy3 = PickEnemyCharacter();
                turnOrderEnemies.Add(enemy3);   
            }
        }
        public Character PickHeroCharacter()
        {
            int character = characterInt.Next(3);
            Character hero;

            if (character == 0)
            {
                hero = new Fighter();
            }
            else if (character == 1)
            {
                hero = new Mage();
            }
            else
            {
                hero = new Cleric();
            }
            return hero;
        }
        public Character PickEnemyCharacter()
        {
            int character = characterInt.Next(3);
            Character enemy;

            if (character == 0)
            {
                enemy = new Bandit();
            }
            else if (character == 1)
            {
                enemy = new Dragon();
            }
            else
            {
                enemy = new Ogre();
            }
            return enemy;
        }

        public void TakeTurn()
        {
            throw new System.NotImplementedException();
        }

        public void PlayerTurn()
        {
            MessageBox.Show("Player can defend");
        }

        public void EnemyTurn()
        {
            MessageBox.Show("Enemy will attack");
        }

        public void GenerateEncounter()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateGUI()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            args.HeroTurnTag = currentTurn;
            OnUpdate(this, args);
        }
        protected virtual void OnUpdate(object sender, UpdateEventArgs e)
        {
            Update?.Invoke(sender, e);
        }
        
        public void OnTurnReady_Handler(object sender, TurnReadyEventArgs e)
        {
            MessageBox.Show("On Turn Ready Handler");
            if (e.Action.Equals("Attack"))
            {
                turnOrderHeros[currentTurn].Attack(TurnOrderEnemies[e.EnemyTag]);
            }
            else if (e.Action.Equals("Defend"))
            {
                MessageBox.Show("Defend");
            }
            else
            {
                MessageBox.Show("Special");
            }

            EnemyTurn();
            PlayerTurn();

            if(currentTurn < 2)
            {
                currentTurn++;
            }
            else
            {
                currentTurn = 0;
            }

            UpdateGUI();
        }

        public List<Character> TurnOrderHeros { get => turnOrderHeros; }
        public List<Character> TurnOrderEnemies { get => turnOrderEnemies; }
        public int CurrentTurn { get => currentTurn; set => currentTurn = value; }
    }
}