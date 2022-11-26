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
            defendBtn.Click += ActionButtonClick_Handler;
            specialBtn.Click += ActionButtonClick_Handler;
            attackBtn.Enabled = true;
            defendBtn.Enabled = true;
            specialBtn.Enabled = true;

        }
        public void FillStatsHero()
        {
            heroStatsLabel.Size = heroStats.Size;
            heroStatsLabel.Location = heroStats.Location;
            heroStatsLabel.BackColor = Color.PaleTurquoise;
            string heroStatsTitle = "Hero Statistics\n";
            string hero1Stats = heroPBs[0].Name + " - Hit Points: 0     Skill Points: 0\n";
            string hero2Stats = heroPBs[1].Name + " -   Hit Points: 0     Skill Points: 0\n";
            string hero3Stats = heroPBs[2].Name + " -   Hit Points: 0     Skill Points: 0";
            heroStatsLabel.Text = heroStatsTitle + hero1Stats + hero2Stats + hero3Stats;
            this.Controls.Add(heroStatsLabel);   
        }
        public void FillStatsEnemy()
        {
            enemyStatsLabel.Size = enemyStats.Size;
            enemyStatsLabel.Location = enemyStats.Location;
            enemyStatsLabel.BackColor = Color.PaleTurquoise;
            string enemyStatsTitle = "Enemy Statistics\n";
            string enemy1Stats = enemyPBs[0].Name + " - Hit Points: 0     Skill Points: 0\n";
            string enemy2Stats = "";
            string enemy3Stats = "";

            if(enemyPBs.Count >= 2)
            {
                enemy2Stats = enemyPBs[1].Name + " -   Hit Points: 0     Skill Points: 0\n";
            }
            if(enemyPBs.Count == 3)
            {
                enemy3Stats = enemyPBs[2].Name + " -   Hit Points: 0     Skill Points: 0";
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

        public void OnUpdate_Handler(object sender, UpdateEventArgs e)
        {
            MessageBox.Show("OnUpdate_Handler");
            if (e.HeroTurnTag > 0)
            {
                heroPBs[e.HeroTurnTag - 1].BackColor = Color.Transparent;
            }
            else if (e.HeroTurnTag == 0)
            {
                heroPBs[2].BackColor = Color.Transparent;
            }
            e.HeroTurnTag = gameLogic.CurrentTurn;
            heroPBs[e.HeroTurnTag].BackColor = Color.Green;
            heroPBs[e.HeroTurnTag].Update();
            gameInfoLabel.Text = "Hero "+ (e.HeroTurnTag+1) + " is taking a turn";

            attackBtn.Enabled = true;
            defendBtn.Enabled = true;
            specialBtn.Enabled = true;

            foreach (var enemy in enemyPBs)
            {
                enemy.BackColor = Color.Transparent;
                enemy.Click -= EnemyPBClick_Handler;
            }
        }

        public void ActionButtonClick_Handler(object sender, EventArgs e)
        {
            MessageBox.Show("Action Button Click Handler");
            string action = ((Button)sender).Tag.ToString();
            queuedAction = action;
            switch (action)
            {
                case "Attack":
                    gameInfoLabel.Text = "Attack has been chosen. Choose your target";
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;

                    foreach(var enemy in enemyPBs)
                    {
                        enemy.BackColor = Color.Red;
                        enemy.Click += EnemyPBClick_Handler;
                    }
                    break;
                case "Defend":
                    gameInfoLabel.Text = "Defend has been chosen.";
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;

                    foreach (var enemy in enemyPBs)
                    {
                        enemy.BackColor = Color.Red;
                        enemy.Click += EnemyPBClick_Handler;
                    }
                    break;
                case "Special":
                    gameInfoLabel.Text = "Special Attack has been chosen. Choose your target";
                    attackBtn.Enabled = false;
                    defendBtn.Enabled = false;
                    specialBtn.Enabled = false;

                    foreach (var enemy in enemyPBs)
                    {
                        enemy.BackColor = Color.Red;
                        enemy.Click += EnemyPBClick_Handler;
                    }
                    break;
            }
        }

        public void EnemyPBClick_Handler(object sender, EventArgs e)
        {
            MessageBox.Show("EnemyPBClick Handler");
            int targetTag = int.Parse(((PictureBox)sender).Tag.ToString());
            TurnReadyEventArgs args = new TurnReadyEventArgs();
            args.Action = queuedAction;
            args.EnemyTag = targetTag;
            OnTurnReady(this, args);
        }

        protected virtual void OnTurnReady(object sender, TurnReadyEventArgs e)
        {
            TurnReady?.Invoke(sender, e);
        }
    }
}