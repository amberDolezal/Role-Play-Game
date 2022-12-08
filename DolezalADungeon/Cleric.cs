using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Cleric : Hero
    {
        private static int clericDefense = 2;
        private static double clericHitPoints = 0.30;
        private static int clericStrength = 25;
        private static int clericSpeed = 6;
        private static int clericIntelligence = 25;
        private static int clericMagicDefense = clericDefense;
        private static string clericName = "Cleric";
        private static string clericSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Cleric.png";
        private static string specialName = "Heal";
        private static int clericSkillPoints = 20;
        private static int clericSpecialChoice = 0;

        public Cleric() : base(specialName, clericSkillPoints, clericName, clericSpriteName, clericHitPoints, clericSpeed, clericStrength,
            clericIntelligence, clericDefense, clericMagicDefense, clericSpecialChoice)
        {

        }
        //Low attack 
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (clericStrength+clericIntelligence)/10;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //Medium defense against both physical and magical 
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy = attackPoints - attackPoints/clericDefense;
            CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
        }
        //Heal selected hero
        public override int Special(List<Character> heros, int heroIndex)
        {
            int healHitPointsBy;
            SpecialName = specialName;
            healHitPointsBy = clericIntelligence / 2;
            if(heros[heroIndex].CurrentHitPoints + healHitPointsBy <= heros[heroIndex].HitPoints)
            {
                heros[heroIndex].CurrentHitPoints = heros[heroIndex].CurrentHitPoints + healHitPointsBy;
            }
            else
            {
                heros[heroIndex].CurrentHitPoints = heros[heroIndex].HitPoints * HeroHitPointsPool;  
            }
            return 0;
        }
    }
}