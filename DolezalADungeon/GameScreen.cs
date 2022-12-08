using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace DolezalADungeon
{
    public partial class GameScreen : Form
    {
        //Initialize variables 
        private string queuedAction;
        private GameLogic gameLogic;
        private Random characterInt = new Random();
        private Label heroStatsLabel = new Label();
        private Label enemyStatsLabel = new Label();
        private Label gameInfoLabel = new Label();

        private List<PictureBox> heroPBs = new List<PictureBox>();
        private List<PictureBox> enemyPBs = new List<PictureBox>();
        private List<Character> heroList = new List<Character>();
        private List<Character> enemyList = new List<Character>();

        public event EventHandler<TurnReadyEventArgs> TurnReady;

        //GameScreen constructor, with GameLogic as an input
        public GameScreen(GameLogic game)
        {
            InitializeComponent();
            this.gameLogic = game;
            heroList = gameLogic.TurnOrderHeros;
            enemyList = gameLogic.TurnOrderEnemies;
            gameLogic.NumberOfGames++;
            UpdateWinsLabel(gameLogic.NumberOfWins);
            UpdateGamesLabel(gameLogic.NumberOfGames);
            PrepBoard();
            FillStatsHero();
            heroStats.SendToBack();
            FillStatsEnemy();
            enemyStats.SendToBack();
            FillGameInfo();
            gameInfo.SendToBack();
            attackBtn.Click += ActionButtonClick_Handler;
            defendBtn.Click += DefendButtonClick_Handler;
            specialBtn.Click += ActionButtonClick_Handler;
            attackBtn.Enabled = false;
            defendBtn.Enabled = false;
            specialBtn.Enabled = false;

        }

        //Initializes and fills the hero status label with initial hit points and skill points
        public void FillStatsHero()
        {
            heroStatsLabel.Size = heroStats.Size;
            heroStatsLabel.Location = heroStats.Location;
            heroStatsLabel.BackColor = Color.PaleTurquoise;
            string heroStatsTitle = "Hero Statistics\n";
            string hero1Stats = heroPBs[0].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[0].HitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[0].SkillPoints + "\n";
            string hero2Stats = heroPBs[1].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[1].HitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[1].SkillPoints + "\n";
            string hero3Stats = heroPBs[2].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[2].HitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[2].SkillPoints + "\n";
            heroStatsLabel.Text = heroStatsTitle + hero1Stats + hero2Stats + hero3Stats;
            this.Controls.Add(heroStatsLabel);   
        }

        //Initializes and fills the enemy status label with initial hit points and skill points
        public void FillStatsEnemy()
        {
            enemyStatsLabel.Size = enemyStats.Size;
            enemyStatsLabel.Location = enemyStats.Location;
            enemyStatsLabel.BackColor = Color.PaleTurquoise;
            string enemyStatsTitle = "Enemy Statistics\n";
            string enemy1Stats = enemyPBs[0].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[0].HitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[0].SkillPoints + "\n";
            string enemy2Stats = "";
            string enemy3Stats = "";

            if(enemyPBs.Count >= 2)
            {
                enemy2Stats = enemyPBs[1].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[1].HitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[1].SkillPoints + "\n";
            }
            if(enemyPBs.Count == 3)
            {
                enemy3Stats = enemyPBs[2].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[2].HitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[2].SkillPoints + "\n";
            }            
            enemyStatsLabel.Text = enemyStatsTitle + enemy1Stats + enemy2Stats + enemy3Stats;
            this.Controls.Add(enemyStatsLabel);
        }

        //Initializes game info label 
        public void FillGameInfo()
        {
            gameInfoLabel.Size = gameInfo.Size;
            gameInfoLabel.Location = gameInfo.Location;
            gameInfoLabel.BackColor = Color.PaleTurquoise;
            this.Controls.Add(gameInfoLabel);
        }
        
        //Fills all the picture boxes according to the amount of heros and enemies
        private void PrepBoard()
        {
            //Fill hero 3 picture boxes and add them to heroPB list
            heroPBs.Add(hero1);
            FillHeroPictureBox(hero1, 1);
            heroPBs.Add(hero2);
            FillHeroPictureBox(hero2, 2);
            heroPBs.Add(hero3);
            FillHeroPictureBox(hero3, 3);

            //Fill enemy picture boxes based on a predetermined amount and add them to the enemyPB list
            enemyPBs.Add(enemy1);
            FillEnemyPictureBox(enemy1, 1);

            if(enemyList.Count >= 2)
            {
                enemyPBs.Add(enemy2);
                FillEnemyPictureBox(enemy2, 2);
            }
            if(enemyList.Count == 3)
            {
                enemyPBs.Add(enemy3);
                FillEnemyPictureBox(enemy3, 3);
            }
        }

        //Fills hero picture boxes with the correct sprite image based on the GameLogic hero list
        public void FillHeroPictureBox(PictureBox heroPB, int heroNum)
        {
            if(heroNum == 1)
            {
                Bitmap hero1Image = new Bitmap(heroList[0].SpriteName);
                heroPB.Image = hero1Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = heroList[0].Name;
            }
            else if(heroNum == 2)
            {
                Bitmap hero2Image = new Bitmap(heroList[1].SpriteName);
                heroPB.Image = hero2Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = heroList[1].Name;
            }
            else if(heroNum == 3)
            {
                Bitmap hero3Image = new Bitmap(heroList[2].SpriteName);
                heroPB.Image = hero3Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = heroList[2].Name;
            }
        }

        //Fills enemy picture boxes with the correct sprite image based on the GameLogic enemy list
        public void FillEnemyPictureBox(PictureBox heroPB, int enemyNum)
        {
            if (enemyNum == 1)
            {
                Bitmap enemy1Image = new Bitmap(enemyList[0].SpriteName);
                heroPB.Image = enemy1Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = enemyList[0].Name;
            }
            else if (enemyNum == 2)
            {
                Bitmap enemy2Image = new Bitmap(enemyList[1].SpriteName);
                heroPB.Image = enemy2Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = enemyList[1].Name;
            }
            else if(enemyNum == 3)
            {
                Bitmap enemy3Image = new Bitmap(enemyList[2].SpriteName);
                heroPB.Image = enemy3Image;
                heroPB.SizeMode = PictureBoxSizeMode.StretchImage;
                heroPB.Name = enemyList[2].Name;
            }
        }

        //Updates the hero stats label with the current hit points
        public void UpdateHeroStats()
        {
            string heroStatsTitle = "Hero Statistics\n";
            string hero1Stats = heroPBs[0].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[0].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[0].SkillPoints + "\n";
            string hero2Stats = "";
            string hero3Stats = "";

            if (heroPBs.Count >= 2)
            {
                hero2Stats = heroPBs[1].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[1].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[1].SkillPoints + "\n";
            }
            if (heroPBs.Count == 3)
            {
                hero3Stats = heroPBs[2].Name + " - Hit Points: " + gameLogic.TurnOrderHeros[2].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderHeros[2].SkillPoints + "\n";
            }
            heroStatsLabel.Text = heroStatsTitle + hero1Stats + hero2Stats + hero3Stats;
        }

        //Updates the enemy stats label with the current hit points
        public void UpdateEnemyStats()
        {
            string enemyStatsTitle = "Enemy Statistics\n";
            string enemy1Stats = enemyPBs[0].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[0].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[0].SkillPoints + "\n";
            string enemy2Stats = "";
            string enemy3Stats = "";

            if (enemyPBs.Count >= 2)
            {
                enemy2Stats = enemyPBs[1].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[1].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[1].SkillPoints + "\n";
            }
            if (enemyPBs.Count == 3)
            {
                enemy3Stats = enemyPBs[2].Name + " - Hit Points: " + gameLogic.TurnOrderEnemies[2].CurrentHitPoints + "     Skill Points: " + gameLogic.TurnOrderEnemies[2].SkillPoints + "\n";
            }
            enemyStatsLabel.Text = enemyStatsTitle + enemy1Stats + enemy2Stats + enemy3Stats;
        }

        //If player wins updates records, and restarts application
        public void CheckIfPlayerWon()
        {
            if (gameLogic.PlayerHasWon)
            {
                MessageBox.Show("You win this level!");
                gameLogic.NumberOfWins++;
                gameLogic.WriteRecords();
                Application.Restart();
            }
        }

        //If play loses updates records, and restarts application
        public void CheckIfPlayerLost()
        {
            if (gameLogic.PlayerHasLost)
            {
                MessageBox.Show("You lost this level! Try Again.");
                gameLogic.WriteRecords();
                Application.Restart();
            }
        }

        //Gets rid of sprite image in hero PB if the hero is dead
        public void CheckIfHeroIsDead(List<Character> heros)
        {
            foreach(var hero in heros)
            {
                if (hero.CurrentHitPoints <= 0)
                {
                    heroPBs[heros.IndexOf(hero)].Image = null;
                }
            }
        }

        //Gets rid of the sprite image in enemy PB if the enemy is dead
        public void CheckIfEnemyIsDead(List<Character> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.CurrentHitPoints <= 0)
                {
                    enemyPBs[enemies.IndexOf(enemy)].Image = null;
                }
            }
        }

        //Only shows the special button if the hero that is taking the turn is a Cleric
        private void SpecialBtnVisibility(int characterIndex)
        {
            if (gameLogic.TurnOrderHeros[characterIndex].GetType() == typeof(Cleric))
            {
                specialBtn.Visible = true;
                specialBtn.Text = gameLogic.TurnOrderHeros[characterIndex].SpecialName;
            }
            else
            {
                specialBtn.Visible = false;
            }
        }

        //Executes on every turn hero and enemy
        public void OnUpdate_Handler(object sender, UpdateEventArgs e)
        {
            //Check the status of the game before doing any moves 
            UpdateEnemyStats();
            UpdateHeroStats();
            CheckIfHeroIsDead(gameLogic.TurnOrderHeros);
            CheckIfEnemyIsDead(gameLogic.TurnOrderEnemies);
            CheckIfPlayerLost();
            CheckIfPlayerWon();

            //Change the back color for all the picture boxes back to transparent 
            foreach (var enemy in enemyPBs)
            {
                enemy.BackColor = Color.Transparent;
                enemy.Click -= EnemyPBClick_Handler;
            }
            foreach (var hero in heroPBs)
            {
                hero.BackColor = Color.Transparent;
            }

            //If it is the enemy's turn, allow player to be able to defend 
            if (gameLogic.EncounterCount % 2 != 0)
            {
                EnemyTurn();
            }
            //Players turn to attack 
            else
            {
                heroPBs[gameLogic.CurrentTurnHero].BackColor = Color.Green;
                gameInfoLabel.Text = "Hero " + (e.HeroTurnTag + 1) + " is taking a turn";
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }
            SpecialBtnVisibility(gameLogic.CurrentTurnHero);
        }

        //Change backcolor of hero being attacked to the correct color
        private void EnemyTurn()
        {
            //if the hero being attacked is still alive 
            if (gameLogic.TurnOrderHeros[gameLogic.HeroBeingAttacked].CurrentHitPoints > 0)
            {
                //if the dragon is doing its swipe attack 
                if (gameLogic.DragonSpecialAttack == 1)
                {
                    foreach (var hero in heroPBs)
                    {
                        if (heroPBs[heroPBs.IndexOf(hero)].Image != null)
                        {
                            heroPBs[heroPBs.IndexOf(hero)].BackColor = Color.Yellow;
                        }
                    }
                    gameInfoLabel.Text = "All the Heros are being attacked by Enemy " + (gameLogic.CurrentTurnEnemy + 1) + ", press the defend button! \n\nOr attack with Hero " + (gameLogic.CurrentTurnHero + 1) + ".";
                }
                //If any other attack is being performed
                else
                {
                    heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Yellow;
                    gameInfoLabel.Text = "Hero " + (gameLogic.HeroBeingAttacked + 1) + " is being attacked by Enemy " + (gameLogic.CurrentTurnEnemy + 1) + ", press the defend button! \n\nOr attack with Hero " + (gameLogic.CurrentTurnHero + 1) + ".";
                }
                enemyPBs[gameLogic.CurrentTurnEnemy].BackColor = Color.Green;
                defendBtn.Enabled = true;
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }
            //If the hero being attacked is dead
            else
            {
                heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Red;
                enemyPBs[gameLogic.CurrentTurnEnemy].BackColor = Color.Green;
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
                gameInfoLabel.Text = "Hero was killed by " + (gameLogic.HeroBeingAttacked + 1) + " Enemy " + (gameLogic.CurrentTurnEnemy + 1);
            }
        }

        //Updates wins in menu strip
        private void UpdateWinsLabel(int numberOfWins)
        {
            wins0ToolStripMenuItem.Text = $"Wins: {numberOfWins}";
        }

        //Updates number of games in menu strip
        private void UpdateGamesLabel(int numberOfGames)
        {
            games0ToolStripMenuItem.Text = $"Games: {numberOfGames}";
        }

        //Executes when the attack or special button is clicked
        public void ActionButtonClick_Handler(object sender, EventArgs e)
        {
            //save action button selected reset hero PB back color
            string action = ((Button)sender).Tag.ToString();
            queuedAction = action;
            heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Transparent;
            heroPBs[gameLogic.CurrentTurnHero].BackColor = Color.Green;

            switch (action)
            {
                case "Attack":
                    gameInfoLabel.Text = "Attack has been chosen. Choose your target";
                    //Change the all the alive enimes back color to red and enable the click handler for each enemy 
                    foreach (var enemy in enemyPBs)
                    {
                        if (gameLogic.TurnOrderEnemies[enemyPBs.IndexOf(enemy)].CurrentHitPoints != 0)
                        {
                            enemy.BackColor = Color.Red;
                            enemy.Click += EnemyPBClick_Handler;
                        }  
                    }
                    gameLogic.EncounterCount++;
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;
                    break;
                case "Special":
                    if (gameLogic.TurnOrderHeros[gameLogic.CurrentTurnHero].GetType() == typeof(Cleric))
                    {
                        gameInfoLabel.Text = "Heal has been chosen. Choose your hero target";
                        //Change all the alive heros back color to green and enable the click handler for each hero 
                        foreach (var hero in heroPBs)
                        {
                            if (gameLogic.TurnOrderHeros[heroPBs.IndexOf(hero)].CurrentHitPoints != 0)
                            {
                                hero.BackColor = Color.Green;
                                hero.Click += HeroPBClick_Handler;
                            } 
                        }
                    }
                    else
                    {
                        specialBtn.Text = "Special";
                        gameInfoLabel.Text = "Special Attack has been chosen. Choose your enemy target";
                        //Changel all the alive enemies back color to red and enable the click handler for each enemy
                        foreach (var enemy in enemyPBs)
                        {
                            if (gameLogic.TurnOrderEnemies[enemyPBs.IndexOf(enemy)].CurrentHitPoints <= 0)
                            {
                                enemy.BackColor = Color.Red;
                                enemy.Click += EnemyPBClick_Handler;
                            }
                        }
                    }
                    gameLogic.EncounterCount++;
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;
                    break;
            }
        }

        //Executes when the defend button is clicked 
        public void DefendButtonClick_Handler(object sender, EventArgs e)
        {
            string action = ((Button)sender).Tag.ToString();
            queuedAction = action;
            attackBtn.Enabled = false;
            defendBtn.Enabled = false;
            specialBtn.Enabled = false;
            //If the dragon is using the swipe attack, all heros that are alive can defend 
            if(gameLogic.DragonSpecialAttack == 1)
            {
                foreach(var hero in heroPBs)
                {
                    gameLogic.PlayerTurnDefend(heroPBs.IndexOf(hero), gameLogic.CurrentTurnEnemy, gameLogic.AttackPoints);
                    heroPBs[heroPBs.IndexOf(hero)].BackColor = Color.Transparent;
                }
            }
            //If it is any other attack, only the hero being attacked can defend
            else
            {
                gameLogic.PlayerTurnDefend(gameLogic.HeroBeingAttacked, gameLogic.CurrentTurnEnemy, gameLogic.AttackPoints);
                heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Transparent;
            }
            gameLogic.CheckIfHeroDied(gameLogic.TurnOrderHeros[gameLogic.HeroBeingAttacked]);
            gameLogic.EncounterCount++;
            gameLogic.DragonSpecialAttack = 0; //reset dragon attack variable
            gameLogic.UpdateGUI();
        }

        //Executes when an enemy has been clicked
        public void EnemyPBClick_Handler(object sender, EventArgs e)
        {
            int targetTag = int.Parse(((PictureBox)sender).Tag.ToString());
            TurnReadyEventArgs args = new TurnReadyEventArgs();
            args.Action = queuedAction;
            args.EnemyTag = targetTag;
            OnTurnReady(this, args);
        }

        //Executes when a hero has been clicked
        public void HeroPBClick_Handler(object sender, EventArgs e)
        {
            int targetTag = int.Parse(((PictureBox)sender).Tag.ToString());
            TurnReadyEventArgs args = new TurnReadyEventArgs();
            args.Action = queuedAction;
            args.HeroTag = targetTag;
            OnTurnReady(this, args);
        }

        protected virtual void OnTurnReady(object sender, TurnReadyEventArgs e)
        {
            TurnReady?.Invoke(sender, e);
        }
        
        //Menu strip clicks for restart and exit
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instructionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\t  Final Fantasy Grassland \n\nThis game will begin with it being your turn to attack. " +
                "The enemy will automatically choose to defend or attack and then you will. This will continue until " +
                "you kill all the enimes or they kill all your heros. There will be an attack, defend, and " +
                "for certian heros a special button. The players hit points and skill points will be displayed at the top. \n\n\t\t    Good Luck!");
        }
    }
}