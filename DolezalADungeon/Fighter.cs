using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Fighter : Hero
    {
        private static int fighterDefense = 2;
        private static double fighterHitPoints = 0.10;
        private static int fighterStrength = 20;
        private static int fighterSpeed = 10;
        private static int fighterIntelligence = 5;
        private static int fighterMagicDefense = 1;
        private static string fighterName = "Fighter";
        private static string fighterSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Fighter.png";
        private static string specialName = "";
        private static int fighterSkillPoints = 2;
        private static int fighterSpecialChoice = 0;

        public Fighter() : base(specialName, fighterSkillPoints, fighterName, fighterSpriteName, fighterHitPoints, fighterSpeed, fighterStrength,
            fighterIntelligence, fighterDefense, fighterMagicDefense, fighterSpecialChoice)
        {
        }
        //Physical attack 
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (fighterStrength + fighterIntelligence) / 3;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //Weak to magic defense, High physical defense
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy;

            if (attacker.SpecialName.Equals("Breathe Fire"))
            {
                reduceAttackPointsBy = attackPoints - fighterMagicDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }
            else
            {
                reduceAttackPointsBy = attackPoints - attackPoints / fighterDefense;
                CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
            }

        }
    }
}