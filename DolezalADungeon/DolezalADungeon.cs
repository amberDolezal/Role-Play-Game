using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class DolezalADungeon
    {
        private GameLogic logic = new GameLogic();
        private GameScreen? screen;

        public void Run()
        {
            ApplicationConfiguration.Initialize();
            screen = new GameScreen(logic);
            logic.Update += screen.OnUpdate_Handler;
            screen.TurnReady += logic.OnTurnReady_Handler;
            logic.UpdateGUI();
            Application.Run(screen); 
        }
    }
}