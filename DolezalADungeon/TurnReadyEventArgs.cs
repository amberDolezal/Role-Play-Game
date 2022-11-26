using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class TurnReadyEventArgs: EventArgs
    {
        private string action;
        private int enemyTag;

        public string Action { get => action; set => action = value; }
        public int EnemyTag { get => enemyTag; set => enemyTag = value; }
    }
}