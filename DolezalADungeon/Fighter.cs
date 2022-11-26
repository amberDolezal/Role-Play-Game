using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Fighter : Hero
    {
        private static int fighterDefense = 45;
        private static double fighterHitPoints = 0.10;
        private static int fighterStrength = 20;
        private static int fighterSpeed = 10;
        private static int fighterIntelligence = 1;
        private static int fighterMagicDefense = 15;
        private static string fighterName = "Fighter";
        private static string fighterSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Fighter.png";
        private static string special = "No Special";
        private static int fighterSkillPoints = 0;

        public Fighter() : base(special, fighterSkillPoints, fighterName, fighterSpriteName, fighterHitPoints, fighterSpeed, fighterStrength,
            fighterIntelligence, fighterDefense, fighterMagicDefense)
        {
        }
    }
}