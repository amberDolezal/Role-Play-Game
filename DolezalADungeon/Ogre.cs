using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DolezalADungeon
{
    public class Ogre : Enemy
    {
        private static int ogreDefense = 45;
        private static double ogreHitPoints = 0.30;
        private static int ogreStrength = 25;
        private static int ogreSpeed = 8;
        private static int ogreIntelligence = 1;
        private static int ogreMagicDefense = 15;
        private static string ogreName = "Orge";
        private static string ogreSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Ogre.png";
        private static string special1 = "No Special";
        private static int ogreSkillPoints = 0;

        public Ogre() : base(special1, special1, ogreSkillPoints, ogreName, ogreSpriteName, ogreHitPoints, ogreSpeed, ogreStrength,
            ogreIntelligence, ogreDefense, ogreMagicDefense)
        {
        }
    }
}