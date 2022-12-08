using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DolezalADungeon
{
    public class Ogre : Enemy
    {
        private static int ogreDefense = 2;
        private static double ogreHitPoints = 30;
        private static int ogreStrength = 25;
        private static int ogreSpeed = 8;
        private static int ogreIntelligence = 1;
        private static int ogreMagicDefense = 1;
        private static string ogreName = "Orge";
        private static string ogreSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Ogre.png";
        private static string specialName = "";
        private static int ogreSkillPoints = 4;
        private static int ogreSpecialChoice = 0;

        public Ogre() : base(specialName, ogreSkillPoints, ogreName, ogreSpriteName, ogreHitPoints, ogreSpeed, ogreStrength,
            ogreIntelligence, ogreDefense, ogreMagicDefense, ogreSpecialChoice)
        {
        }
        //Physical attack
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (ogreStrength + ogreIntelligence) / 3;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //High defense against physical attacks, weak against magic
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy;

            if (attacker.Name.Equals("Mage"))
            {
                reduceAttackPointsBy = attackPoints - ogreMagicDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }
            else
            {
                reduceAttackPointsBy = attackPoints - attackPoints / ogreDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }
        }
    }
}