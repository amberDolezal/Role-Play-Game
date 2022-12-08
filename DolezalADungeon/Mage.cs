using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Mage : Hero
    {
        private static int mageDefense = 2;
        private static double mageHitPoints = 0.20;
        private static int mageStrength = 8;
        private static int mageSpeed = 8;
        private static int mageIntelligence = 30;
        private static int mageMagicDefense = 1;
        private static string mageName = "Mage";
        private static string mageSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Mage.png";
        private static string specialName = "";
        private static int mageSkillPoints = 15;
        private static int mageSpecialChoice = 0;

        public Mage() : base(specialName, mageSkillPoints, mageName, mageSpriteName, mageHitPoints, mageSpeed, mageStrength,
            mageIntelligence, mageDefense, mageMagicDefense, mageSpecialChoice)
        {
        }
        //Magic attack 
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (mageStrength + mageIntelligence) / 3;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //Low physical defense, High magic defense 
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy;

            if (attacker.SpecialName.Equals("Breathe Fire"))
            {
                reduceAttackPointsBy = attackPoints - attackPoints / mageDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }
            else
            {
                reduceAttackPointsBy = attackPoints - mageMagicDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }

        }
    }
}