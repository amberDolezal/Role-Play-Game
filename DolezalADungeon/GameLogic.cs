using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class GameLogic
    {
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

        public event EventHandler<UpdateEventArgs> Update;

        private Random characterInt = new Random();

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
        public void PlayerTurnDefend(int enemyNum, int attackPoints)
        {
            turnOrderHeros[currentTurnHero].Defend(turnOrderEnemies[enemyNum], attackPoints);
        }

        public List<int> EnemyTurn(Character enemy)
        {
            List<int> result = new List<int>();
            int attackPoints = 0;
            int chooseDragonAttack = 0;
            int attackPlayer = characterInt.Next(3);
            while (turnOrderHeros[attackPlayer].CurrentHitPoints <= 0)
            {
                attackPlayer = characterInt.Next(3);
            }
            heroBeingAttacked = attackPlayer;
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
                }
            }
            else
            {
                attackPoints = enemy.Attack(turnOrderHeros[attackPlayer]);
            }
            CheckIfHeroDied(turnOrderHeros[attackPlayer]);
            result.Add(attackPoints);
            result.Add(chooseDragonAttack);
            return result;
        }

        public void GenerateEncounter()
        {
            throw new System.NotImplementedException();
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
        
        public void OnTurnReady_Handler(object sender, TurnReadyEventArgs e)
        {
            List<int> enemyTurnResults = new List<int>();
            if (e.Action.Equals("Attack"))
            {
                turnOrderHeros[currentTurnHero].Attack(turnOrderEnemies[e.EnemyTag]);
                CheckIfEnemyDied(turnOrderEnemies[e.EnemyTag]);
            }
            else if (e.Action.Equals("Special"))
            {
                turnOrderHeros[currentTurnHero].Special(turnOrderHeros, e.HeroTag);
            }
            CheckIfPlayerWon();
            if (encounterCount % 2 != 0 && (playerHasWon == false || playerHasLost))
            {
                enemyTurnResults = EnemyTurn(turnOrderEnemies[currentTurnEnemy]);
                attackPoints = enemyTurnResults[0];
                dragonSpecialAttack = enemyTurnResults[1];
            }
            CheckIfHeroDied(turnOrderHeros[e.HeroTag]);
            CheckIfPlayerLost();
            UpdateTurnNumber();
            UpdateGUI();
        }

        private void UpdateTurnNumber()
        {
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

        public void CheckIfPlayerWon()
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

        public void CheckIfPlayerLost()
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
                PlayerHasLost = true; 
            }
        }

        //Reads Records.txt to get number of games played, number of wins, and the total time played for every game
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

        //Saves the number of games played, number of wins, and total time played to Records.txt
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

        public List<Character> TurnOrderHeros { get => turnOrderHeros; }
        public List<Character> TurnOrderEnemies { get => turnOrderEnemies; }
        public int CurrentTurnHero { get => currentTurnHero; set => currentTurnHero = value; }
        public int HeroBeingAttacked { get => heroBeingAttacked; set => heroBeingAttacked = value; }
        public int EncounterCount { get => encounterCount; set => encounterCount = value; }
        public int AttackPoints { get => attackPoints; set => attackPoints = value; }
        public int CurrentTurnEnemy { get => currentTurnEnemy; set => currentTurnEnemy = value; }
        public bool PlayerHasWon { get => playerHasWon; set => playerHasWon = value; }
        public bool PlayerHasLost { get => playerHasLost; set => playerHasLost = value; }
        public int PreviousTurnEnemy { get => previousTurnEnemy; set => previousTurnEnemy = value; }
        public int PreviousTurnHero { get => previousTurnHero; set => previousTurnHero = value; }
        public bool HeroHasDied { get => heroHasDied; set => heroHasDied = value; }
        public bool EnemyHasDied { get => enemyHasDied; set => enemyHasDied = value; }
        public int NumberOfWins { get => numberOfWins; set => numberOfWins = value; }
        public int NumberOfGames { get => numberOfGames; set => numberOfGames = value; }
        public int DragonSpecialAttack { get => dragonSpecialAttack; set => dragonSpecialAttack = value; }
    }
}