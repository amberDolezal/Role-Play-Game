using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Mage : Hero
    {
        private static int mageDefense = 45;
        private static double mageHitPoints = 10;
        private static int mageStrength = 8;
        private static int mageSpeed = 8;
        private static int mageIntelligence = 30;
        private static int mageMagicDefense = 15;
        private static string mageName = "Mage";
        private static string mageSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Mage.png";
        private static string specialName = "No Special";
        private static int mageSkillPoints = 0;

        public Mage() : base(specialName, specialName, mageSkillPoints, mageName, mageSpriteName, mageHitPoints, mageSpeed, mageStrength,
            mageIntelligence, mageDefense, mageMagicDefense)
        {
        }
    }
}