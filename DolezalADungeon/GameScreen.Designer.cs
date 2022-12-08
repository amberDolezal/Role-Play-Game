namespace DolezalADungeon
{
    partial class GameScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.hero1 = new System.Windows.Forms.PictureBox();
            this.gameScene = new System.Windows.Forms.Panel();
            this.enemy3 = new System.Windows.Forms.PictureBox();
            this.enemy2 = new System.Windows.Forms.PictureBox();
            this.enemy1 = new System.Windows.Forms.PictureBox();
            this.hero3 = new System.Windows.Forms.PictureBox();
            this.hero2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wins0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.games0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdByAmberDolezalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.attackBtn = new System.Windows.Forms.Button();
            this.defendBtn = new System.Windows.Forms.Button();
            this.heroStats = new System.Windows.Forms.Panel();
            this.enemyStats = new System.Windows.Forms.Panel();
            this.gameInfo = new System.Windows.Forms.Panel();
            this.specialBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).BeginInit();
            this.gameScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hero1
            // 
            this.hero1.BackColor = System.Drawing.Color.Transparent;
            this.hero1.Location = new System.Drawing.Point(720, 259);
            this.hero1.Name = "hero1";
            this.hero1.Size = new System.Drawing.Size(123, 126);
            this.hero1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hero1.TabIndex = 1;
            this.hero1.TabStop = false;
            this.hero1.Tag = "0";
            // 
            // gameScene
            // 
            this.gameScene.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gameScene.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gameScene.BackgroundImage")));
            this.gameScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameScene.Controls.Add(this.enemy3);
            this.gameScene.Controls.Add(this.enemy2);
            this.gameScene.Controls.Add(this.enemy1);
            this.gameScene.Controls.Add(this.hero3);
            this.gameScene.Controls.Add(this.hero2);
            this.gameScene.Controls.Add(this.hero1);
            this.gameScene.Location = new System.Drawing.Point(-6, 282);
            this.gameScene.Name = "gameScene";
            this.gameScene.Size = new System.Drawing.Size(2447, 608);
            this.gameScene.TabIndex = 2;
            // 
            // enemy3
            // 
            this.enemy3.BackColor = System.Drawing.Color.Transparent;
            this.enemy3.Location = new System.Drawing.Point(1973, 335);
            this.enemy3.Name = "enemy3";
            this.enemy3.Size = new System.Drawing.Size(132, 158);
            this.enemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy3.TabIndex = 6;
            this.enemy3.TabStop = false;
            this.enemy3.Tag = "2";
            // 
            // enemy2
            // 
            this.enemy2.BackColor = System.Drawing.Color.Transparent;
            this.enemy2.Location = new System.Drawing.Point(1745, 285);
            this.enemy2.Name = "enemy2";
            this.enemy2.Size = new System.Drawing.Size(152, 153);
            this.enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy2.TabIndex = 5;
            this.enemy2.TabStop = false;
            this.enemy2.Tag = "1";
            // 
            // enemy1
            // 
            this.enemy1.BackColor = System.Drawing.Color.Transparent;
            this.enemy1.Location = new System.Drawing.Point(1561, 260);
            this.enemy1.Name = "enemy1";
            this.enemy1.Size = new System.Drawing.Size(127, 125);
            this.enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy1.TabIndex = 4;
            this.enemy1.TabStop = false;
            this.enemy1.Tag = "0";
            // 
            // hero3
            // 
            this.hero3.BackColor = System.Drawing.Color.Transparent;
            this.hero3.Location = new System.Drawing.Point(425, 360);
            this.hero3.Name = "hero3";
            this.hero3.Size = new System.Drawing.Size(112, 115);
            this.hero3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hero3.TabIndex = 3;
            this.hero3.TabStop = false;
            this.hero3.Tag = "2";
            // 
            // hero2
            // 
            this.hero2.BackColor = System.Drawing.Color.Transparent;
            this.hero2.Location = new System.Drawing.Point(574, 312);
            this.hero2.Name = "hero2";
            this.hero2.Size = new System.Drawing.Size(112, 115);
            this.hero2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hero2.TabIndex = 2;
            this.hero2.TabStop = false;
            this.hero2.Tag = "1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2441, 42);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.instructionsToolStripMenuItem,
            this.gameStatisticsToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(96, 38);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.instructionsToolStripMenuItem.Text = "Exit";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // gameStatisticsToolStripMenuItem
            // 
            this.gameStatisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wins0ToolStripMenuItem,
            this.games0ToolStripMenuItem});
            this.gameStatisticsToolStripMenuItem.Name = "gameStatisticsToolStripMenuItem";
            this.gameStatisticsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.gameStatisticsToolStripMenuItem.Text = "Game Statistics";
            // 
            // wins0ToolStripMenuItem
            // 
            this.wins0ToolStripMenuItem.Name = "wins0ToolStripMenuItem";
            this.wins0ToolStripMenuItem.Size = new System.Drawing.Size(244, 44);
            this.wins0ToolStripMenuItem.Text = "Wins: 0";
            // 
            // games0ToolStripMenuItem
            // 
            this.games0ToolStripMenuItem.Name = "games0ToolStripMenuItem";
            this.games0ToolStripMenuItem.Size = new System.Drawing.Size(244, 44);
            this.games0ToolStripMenuItem.Text = "Games: 0";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(84, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem1
            // 
            this.instructionsToolStripMenuItem1.Name = "instructionsToolStripMenuItem1";
            this.instructionsToolStripMenuItem1.Size = new System.Drawing.Size(359, 44);
            this.instructionsToolStripMenuItem1.Text = "Instructions";
            this.instructionsToolStripMenuItem1.Click += new System.EventHandler(this.instructionsToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createdByAmberDolezalToolStripMenuItem,
            this.toolStripMenuItem2});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // createdByAmberDolezalToolStripMenuItem
            // 
            this.createdByAmberDolezalToolStripMenuItem.Name = "createdByAmberDolezalToolStripMenuItem";
            this.createdByAmberDolezalToolStripMenuItem.Size = new System.Drawing.Size(432, 44);
            this.createdByAmberDolezalToolStripMenuItem.Text = "Created By: Amber Dolezal";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(432, 44);
            this.toolStripMenuItem2.Text = "Date: 11/14/2022";
            // 
            // attackBtn
            // 
            this.attackBtn.BackColor = System.Drawing.Color.LightCoral;
            this.attackBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackBtn.Location = new System.Drawing.Point(65, 911);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(466, 54);
            this.attackBtn.TabIndex = 4;
            this.attackBtn.Tag = "Attack";
            this.attackBtn.Text = "Attack";
            this.attackBtn.UseVisualStyleBackColor = false;
            // 
            // defendBtn
            // 
            this.defendBtn.BackColor = System.Drawing.Color.LightGreen;
            this.defendBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.defendBtn.Location = new System.Drawing.Point(65, 974);
            this.defendBtn.Name = "defendBtn";
            this.defendBtn.Size = new System.Drawing.Size(466, 54);
            this.defendBtn.TabIndex = 5;
            this.defendBtn.Tag = "Defend";
            this.defendBtn.Text = "Defend";
            this.defendBtn.UseVisualStyleBackColor = false;
            // 
            // heroStats
            // 
            this.heroStats.BackColor = System.Drawing.Color.PaleTurquoise;
            this.heroStats.Location = new System.Drawing.Point(25, 72);
            this.heroStats.Name = "heroStats";
            this.heroStats.Size = new System.Drawing.Size(624, 169);
            this.heroStats.TabIndex = 6;
            // 
            // enemyStats
            // 
            this.enemyStats.BackColor = System.Drawing.Color.PaleTurquoise;
            this.enemyStats.Location = new System.Drawing.Point(1739, 72);
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.Size = new System.Drawing.Size(624, 169);
            this.enemyStats.TabIndex = 7;
            // 
            // gameInfo
            // 
            this.gameInfo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gameInfo.Location = new System.Drawing.Point(1739, 911);
            this.gameInfo.Name = "gameInfo";
            this.gameInfo.Size = new System.Drawing.Size(624, 169);
            this.gameInfo.TabIndex = 8;
            // 
            // specialBtn
            // 
            this.specialBtn.BackColor = System.Drawing.Color.MediumPurple;
            this.specialBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.specialBtn.Location = new System.Drawing.Point(65, 1047);
            this.specialBtn.Name = "specialBtn";
            this.specialBtn.Size = new System.Drawing.Size(466, 54);
            this.specialBtn.TabIndex = 9;
            this.specialBtn.Tag = "Special";
            this.specialBtn.Text = "Special";
            this.specialBtn.UseVisualStyleBackColor = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(2441, 1113);
            this.Controls.Add(this.specialBtn);
            this.Controls.Add(this.gameInfo);
            this.Controls.Add(this.enemyStats);
            this.Controls.Add(this.heroStats);
            this.Controls.Add(this.defendBtn);
            this.Controls.Add(this.attackBtn);
            this.Controls.Add(this.gameScene);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameScreen";
            this.Text = "Final Fantasy Grassland";
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).EndInit();
            this.gameScene.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox hero1;
        private Panel gameScene;
        private PictureBox hero2;
        private PictureBox hero3;
        private PictureBox enemy1;
        private PictureBox enemy2;
        private PictureBox enemy3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem;
        private ToolStripMenuItem gameStatisticsToolStripMenuItem;
        private ToolStripMenuItem wins0ToolStripMenuItem;
        private ToolStripMenuItem games0ToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem createdByAmberDolezalToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private Button attackBtn;
        private Button defendBtn;
        private Panel heroStats;
        private Panel enemyStats;
        private Panel gameInfo;
        private Button specialBtn;
    }
}