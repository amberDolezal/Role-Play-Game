using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class UpdateEventArgs: EventArgs
    {
        private int heroTurnTag;

        public int HeroTurnTag { get => heroTurnTag; set => heroTurnTag = value; }
    }
}