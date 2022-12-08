using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class GameLogic
    {
        //Initialize variables 
        private int currentTurnHero;
        private int previousTurnHero;
        private int currentTurnEnemy;
        private int previousTurnEnemy;
        private List<Character> turnOrderHeros;
        private List<Character> turnOrderEnemies;
        private int encounterCount;
        private int heroBeingAttacked;
        private int attackPoints;
        private bool playerHasWon = false;
        private bool playerHasLost = false;
        private bool heroHasDied = false;
        private bool enemyHasDied = false;
        private int numberOfWins = 0;
        private int numberOfGames = 0;
        private int dragonSpecialAttack = 0;
        private Random characterInt = new Random();

        public event EventHandler<UpdateEventArgs> Update;

        //GameLogic constructor
        public GameLogic()
        {
            turnOrderHeros = new List<Character>();
            turnOrderEnemies = new List<Character>();
            FillTurnOrderHeros();
            FillTurnOrderEnemies();
            currentTurnHero = 0;
            currentTurnEnemy = 0;
            encounterCount = 0;
            LoadRecords();  
        }

        //Fill turn order heros list with fastest speed first
        private void FillTurnOrderHeros()
        {
            Character hero1 = PickHeroCharacter();
            turnOrderHeros.Add(hero1);

            Character hero2 = PickHeroCharacter();
            if (hero1.Speed >= hero2.Speed)
            {
                turnOrderHeros.Add(hero2);
            }
            else
            {
                turnOrderHeros[0] = hero2;
                turnOrderHeros.Add(hero1);
            }

            Character hero3 = PickHeroCharacter();
            if (hero2.Speed >= hero3.Speed)
            {
                turnOrderHeros.Add(hero3);
            }
            else if (hero1.Speed >= hero3.Speed && hero3.Speed > hero2.Speed)
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
            DetermineHeroHitPoints();
        }
        
        //Determines how many hit points hero has based on hero hit points pool
        private void DetermineHeroHitPoints()
        {
            turnOrderHeros[0].CurrentHitPoints = turnOrderHeros[0].HitPoints * turnOrderHeros[0].HeroHitPointsPool;
            turnOrderHeros[1].CurrentHitPoints = turnOrderHeros[1].HitPoints * turnOrderHeros[1].HeroHitPointsPool;
            turnOrderHeros[2].CurrentHitPoints = turnOrderHeros[2].HitPoints * turnOrderHeros[2].HeroHitPointsPool;
        }

        //Fill in turn order enemies list with fastest speed first
        private void FillTurnOrderEnemies()
        {
            int numberOfEnemies = characterInt.Next(3);

            Character enemy1 = PickEnemyCharacter();
            turnOrderEnemies.Add(enemy1);

            Character enemy2 = PickEnemyCharacter();
            if (numberOfEnemies >= 1)
            {
                if (enemy1.Speed >= enemy2.Speed)
                {
                    turnOrderEnemies.Add(enemy2);
                }
                else
                {
                    turnOrderEnemies[0] = enemy2;
                    turnOrderHeros.Add(enemy1);
                }
            }
            if(numberOfEnemies == 2)
            {
                Character enemy3 = PickEnemyCharacter();
                if (enemy2.Speed >= enemy3.Speed)
                {
                    turnOrderEnemies.Add(enemy3);
                }
                else if (enemy1.Speed >= enemy3.Speed && enemy3.Speed > enemy2.Speed)
                {
                    turnOrderEnemies[0] = enemy1;
                    turnOrderEnemies[1] = enemy3;
                    turnOrderEnemies.Add(enemy2);
                }
                else
                {
                    turnOrderEnemies[0] = enemy3;
                    turnOrderEnemies[1] = enemy1;
                    turnOrderEnemies.Add(enemy2);
                }
            }
        }

        //Randomly pick a hero character
        private Character PickHeroCharacter()
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

        //Randomly pick a enemy character
        private Character PickEnemyCharacter()
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

        public void CheckIfHeroDied(Character hero)
        {
            if(hero.CurrentHitPoints <= 0)
            {
                hero.CurrentHitPoints = 0;
            }
        }
        public void CheckIfEnemyDied(Character enemy)
        {
            if (enemy.CurrentHitPoints <= 0)
            {
                enemy.CurrentHitPoints = 0;
            }
        }

        public void PlayerTurnDefend(int heroNum, int enemyNum, int attackPoints)
        {
            turnOrderHeros[heroNum].Defend(turnOrderEnemies[enemyNum], attackPoints);
        }

        //Choose the how the enemy will attack depending on the type of character
        private List<int> EnemyTurnAttack(Character enemy)
        {
            List<int> result = new List<int>();
            int attackPoints = 0;
            int chooseDragonAttack = 0;
            int attackPlayer = characterInt.Next(3);

            //Choose a character that isn't dead to attack 
            while (turnOrderHeros[attackPlayer].CurrentHitPoints <= 0)
            {
                attackPlayer = characterInt.Next(3);
            }
            heroBeingAttacked = attackPlayer;

            //If the enemy is a dragon choose which type of attack it should perform, regular or special
            if(enemy.GetType() == typeof(Dragon))
            {
                chooseDragonAttack = characterInt.Next(2);
                if (chooseDragonAttack == 0)
                {
                    attackPoints = enemy.Attack(turnOrderHeros[attackPlayer]);
                }
                else if (chooseDragonAttack == 1)
                {
                    attackPoints = enemy.Special(turnOrderHeros, attackPlayer);
                    dragonSpecialAttack = enemy.SpecialChoice;
                }
            }
            //If it is not a dragon perform the characters normal attack 
            else
            {
                attackPoints = enemy.Attack(turnOrderHeros[attackPlayer]);
            }
            CheckIfHeroDied(turnOrderHeros[attackPlayer]);
            result.Add(attackPoints);
            result.Add(dragonSpecialAttack);
            return result;
        }
        //Enemy will randomly defend attacks performed by heros 
        private void EnemyTurnDefend(Character hero, Character enemy, int attackPoints)
        {
            int willEnemyDefend = characterInt.Next(2);

            if(willEnemyDefend == 0 && enemy.CurrentHitPoints > 0)
            {
                enemy.Defend(hero, attackPoints);      
            }
        }

        //Updates which turn it is for the player and enemy, saves the previous turn too
        private void UpdateTurnNumber()
        {
            CheckIfEnemyDied(turnOrderEnemies[currentTurnEnemy]);
            CheckIfHeroDied(turnOrderHeros[currentTurnHero]);
            previousTurnHero = currentTurnHero;
            if (currentTurnHero < 2)
            {
                currentTurnHero++;
            }
            else
            {
                currentTurnHero = 0;
            }
            KeepUpdatingHeroTurn();

            previousTurnEnemy = currentTurnEnemy;
            if (currentTurnEnemy < TurnOrderEnemies.Count - 1)
            {
                currentTurnEnemy++;
            }
            else
            {
                currentTurnEnemy = 0;
            }
            KeepUpdatingEnemyTurn();
        }

        //Keeps updating the enemy's turn if the current enemy turn is dead
        private void KeepUpdatingEnemyTurn()
        {
            CheckIfPlayerWon();
            if (playerHasWon == false)
            {
                while (turnOrderEnemies[currentTurnEnemy].CurrentHitPoints <= 0)
                {
                    if (currentTurnEnemy < TurnOrderEnemies.Count - 1)
                    {
                        currentTurnEnemy++;
                    }
                    else
                    {
                        currentTurnEnemy = 0;
                    }
                }
            }
        }

        //Keeps updating the hero's turn if the current hero turn is dead
        private void KeepUpdatingHeroTurn()
        {
            CheckIfPlayerLost();
            if (playerHasLost == false)
            {
                while (turnOrderHeros[currentTurnHero].CurrentHitPoints <= 0)
                {
                    if (currentTurnHero < 2)
                    {
                        currentTurnHero++;
                    }
                    else
                    {
                        currentTurnHero = 0;
                    }
                }
            }
        }
        
        //Checks to see if all the enemies are dead
        private void CheckIfPlayerWon()
        {
            int countOfDeadEnimes = 0;
            foreach (var enemy in turnOrderEnemies)
            {
                if (turnOrderEnemies[turnOrderEnemies.IndexOf(enemy)].CurrentHitPoints <= 0)
                {
                    countOfDeadEnimes++;
                }
            }
            if (TurnOrderEnemies.Count == countOfDeadEnimes)
            {
                playerHasWon = true;
            }
        }

        //Checks to see if all the heros are dead
        private void CheckIfPlayerLost()
        {
            int countOfDeadHeros = 0;
            foreach (var hero in turnOrderHeros)
            {
                if (turnOrderHeros[turnOrderHeros.IndexOf(hero)].CurrentHitPoints <= 0)
                {
                    countOfDeadHeros++;
                }
            }
            if (turnOrderHeros.Count == countOfDeadHeros)
            {
                playerHasLost = true; 
            }
        }

        //Reads Records.txt to get number of games played, number of wins for every game
        private void LoadRecords()
        {
            try
            {
                StreamReader reader = new StreamReader("Records.txt");
                if (!reader.EndOfStream)
                {
                    numberOfGames = int.Parse(reader.ReadLine());
                }
                if (!reader.EndOfStream)
                {
                    numberOfWins = int.Parse(reader.ReadLine());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Saves the number of games played, number of wins to Records.txt
        public void WriteRecords()
        {
            try
            {
                StreamWriter writer = new StreamWriter("Records.txt");
                writer.WriteLine(numberOfGames.ToString());
                writer.WriteLine(numberOfWins.ToString());
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateGUI()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            args.HeroTurnTag = currentTurnHero;
            OnUpdate(this, args);
        }
        protected virtual void OnUpdate(object sender, UpdateEventArgs e)
        {
            Update?.Invoke(sender, e);
        }

        //Executes on every turn
        public void OnTurnReady_Handler(object sender, TurnReadyEventArgs e)
        {
            CheckIfPlayerWon();
            CheckIfPlayerLost();
            List<int> enemyTurnResults = new List<int>();

            //Hero will either perform attack or special based on the button pressed
            if (e.Action.Equals("Attack"))
            {
                attackPoints = turnOrderHeros[currentTurnHero].Attack(turnOrderEnemies[e.EnemyTag]);
                CheckIfEnemyDied(turnOrderEnemies[e.EnemyTag]);
            }
            else if (e.Action.Equals("Special"))
            {
                turnOrderHeros[currentTurnHero].Special(turnOrderHeros, e.HeroTag);
            }
            EnemyTurnDefend(turnOrderHeros[currentTurnEnemy], turnOrderEnemies[e.EnemyTag], attackPoints);
            CheckIfPlayerWon();

            //If it is the enemies turn and the player hasn't won or lost yet, enemy will attack
            if (encounterCount % 2 != 0 && (playerHasWon == false || playerHasLost))
            {
                enemyTurnResults = EnemyTurnAttack(turnOrderEnemies[currentTurnEnemy]);
                attackPoints = enemyTurnResults[0];
                dragonSpecialAttack = enemyTurnResults[1];
            }
            CheckIfHeroDied(turnOrderHeros[e.HeroTag]);
            CheckIfPlayerLost();
            UpdateTurnNumber();
            UpdateGUI();
        }

        public List<Character> TurnOrderHeros { get => turnOrderHeros; }
        public List<Character> TurnOrderEnemies { get => turnOrderEnemies; }
        public int CurrentTurnHero { get => currentTurnHero; set => currentTurnHero = value; }
        public int HeroBeingAttacked { get => heroBeingAttacked; }
        public int EncounterCount { get => encounterCount; set => encounterCount = value; }
        public int AttackPoints { get => attackPoints; }
        public int CurrentTurnEnemy { get => currentTurnEnemy; }
        public bool PlayerHasWon { get => playerHasWon; }
        public bool PlayerHasLost { get => playerHasLost; }
        public int PreviousTurnEnemy { get => previousTurnEnemy; }
        public int PreviousTurnHero { get => previousTurnHero; }
        public bool HeroHasDied { get => heroHasDied; }
        public bool EnemyHasDied { get => enemyHasDied; }
        public int NumberOfWins { get => numberOfWins; set => numberOfWins = value; }
        public int NumberOfGames { get => numberOfGames; set => numberOfGames = value; }
        public int DragonSpecialAttack { get => dragonSpecialAttack; set => dragonSpecialAttack = value; }
    }
}