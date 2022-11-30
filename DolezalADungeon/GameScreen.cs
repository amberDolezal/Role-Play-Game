using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace DolezalADungeon
{
    public partial class GameScreen : Form
    {
        private string queuedAction;

        private Label heroStatsLabel = new Label();
        private Label enemyStatsLabel = new Label();
        private Label gameInfoLabel = new Label();

        public event EventHandler<TurnReadyEventArgs> TurnReady;

        List<PictureBox> heroPBs = new List<PictureBox>();
        List<PictureBox> enemyPBs = new List<PictureBox>();

        private Random characterInt = new Random();

        private GameLogic gameLogic;
        private List<Character> heroList = new List<Character>();
        private List<Character> enemyList = new List<Character>();

        public GameScreen(GameLogic game)
        {
            InitializeComponent();
            this.gameLogic = game;
            heroList = gameLogic.TurnOrderHeros;
            enemyList = gameLogic.TurnOrderEnemies;
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
        public void FillGameInfo()
        {
            gameInfoLabel.Size = gameInfo.Size;
            gameInfoLabel.Location = gameInfo.Location;
            gameInfoLabel.BackColor = Color.PaleTurquoise;
            this.Controls.Add(gameInfoLabel);
        }
        private void PrepBoard()
        {
            heroPBs.Add(hero1);
            FillHeroPictureBox(hero1, 1);
            heroPBs.Add(hero2);
            FillHeroPictureBox(hero2, 2);
            heroPBs.Add(hero3);
            FillHeroPictureBox(hero3, 3);

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
        public void CheckIfPlayerWon()
        {
            if (gameLogic.PlayerHasWon)
            {
                MessageBox.Show("You win this level!");
                Application.Restart();
            }
        }

        public void CheckIfPlayerLost()
        {
            if (gameLogic.PlayerHasLost)
            {
                MessageBox.Show("You lost this level! Try Again.");
                Application.Restart();
            }
        }
        public void CheckIfHeroIsDead(int heroIndex)
        {
            if (gameLogic.TurnOrderHeros[heroIndex].CurrentHitPoints == 0)
            {
                heroPBs[heroIndex].Image = null;
            }  
        }
        public void CheckIfEnemyIsDead(int enemyIndex)
        {
            if (gameLogic.TurnOrderEnemies[enemyIndex].CurrentHitPoints == 0)
            {
                enemyPBs[enemyIndex].Image = null;
            }
        }

        public void OnUpdate_Handler(object sender, UpdateEventArgs e)
        {
            UpdateEnemyStats();
            UpdateHeroStats();
            CheckIfHeroIsDead(gameLogic.PreviousTurnHero);
            CheckIfEnemyIsDead(gameLogic.PreviousTurnEnemy);
            CheckIfHeroIsDead(gameLogic.CurrentTurnHero);
            CheckIfEnemyIsDead(gameLogic.CurrentTurnEnemy);
            CheckIfPlayerLost();
            CheckIfPlayerWon();

            foreach (var enemy in enemyPBs)
            {
                enemy.BackColor = Color.Transparent;
                enemy.Click -= EnemyPBClick_Handler;
            }
            foreach (var hero in heroPBs)
            {
                hero.BackColor = Color.Transparent;
            }
            if (gameLogic.EncounterCount % 2 != 0)
            {
                heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Yellow;
                enemyPBs[gameLogic.CurrentTurnEnemy].BackColor = Color.Green;
                defendBtn.Enabled = true;
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
                gameInfoLabel.Text = "Hero " + (gameLogic.HeroBeingAttacked + 1) + " is being attacked by Enemy " + (gameLogic.CurrentTurnEnemy + 1) + ", press the defend button!";
            }
            else
            {
                heroPBs[gameLogic.CurrentTurnHero].BackColor = Color.Green;
                gameInfoLabel.Text = "Hero " + (e.HeroTurnTag + 1) + " is taking a turn";
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }
            SpecialBtnVisibility(gameLogic.CurrentTurnHero);
        }

        private void SpecialBtnVisibility(int characterIndex)
        {
            if (gameLogic.TurnOrderHeros[characterIndex].GetType() == typeof(Cleric))
            {
                specialBtn.Visible = true;
                specialBtn.Text = gameLogic.TurnOrderHeros[characterIndex].SpecialName1;
            }
            else
            {
                specialBtn.Visible = false;
            }
        }

        public void ActionButtonClick_Handler(object sender, EventArgs e)
        {
            string action = ((Button)sender).Tag.ToString();
            queuedAction = action;
            heroPBs[gameLogic.CurrentTurnHero].BackColor = Color.Green;
            heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Transparent;

            switch (action)
            {
                case "Attack":
                    gameInfoLabel.Text = "Attack has been chosen. Choose your target";
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;

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
        public void DefendButtonClick_Handler(object sender, EventArgs e)
        {
            string action = ((Button)sender).Tag.ToString();
            queuedAction = action;
            attackBtn.Enabled = false;
            defendBtn.Enabled = false;
            specialBtn.Enabled = false;
            gameLogic.PlayerTurnDefend(gameLogic.CurrentTurnEnemy, gameLogic.AttackPoints);
            heroPBs[gameLogic.HeroBeingAttacked].BackColor = Color.Transparent;
            gameLogic.EncounterCount++;
            gameLogic.UpdateGUI();
        }
        public void EnemyPBClick_Handler(object sender, EventArgs e)
        {
            int targetTag = int.Parse(((PictureBox)sender).Tag.ToString());
            TurnReadyEventArgs args = new TurnReadyEventArgs();
            args.Action = queuedAction;
            args.EnemyTag = targetTag;
            OnTurnReady(this, args);
        }
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
    }
}