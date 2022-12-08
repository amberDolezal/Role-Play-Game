using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Dragon : Enemy
    {
        private static int dragonDefense = 2;
        private static double dragonHitPoints = 50;
        private static int dragonStrength = 20;
        private static int dragonSpeed = 4;
        private static int dragonIntelligence = 30;
        private static int dragonMagicDefense = dragonDefense;
        private static string dragonName = "Dragon";
        private static string dragonSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Dragon.png";
        private static string specialName = "";
        private string special1 = "Breathe Fire";
        private string special2 = "Swipe Attack";
        private static int dragonSkillPoints = 30;
        private static int dragonSpecialChoice = 0;

        public Dragon() : base(specialName, dragonSkillPoints, dragonName, dragonSpriteName, dragonHitPoints, dragonSpeed, dragonStrength,
            dragonIntelligence, dragonDefense, dragonMagicDefense, dragonSpecialChoice)
        {
        }
        //Strong attack 
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (dragonStrength + dragonIntelligence) / 10;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //Strong against both Physical and Magic attacks 
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy = attackPoints - attackPoints / dragonDefense;
            CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
        }
        //Dragon Special attacks
        public override int Special(List<Character> heros, int heroIndex)
        {
            Random specialChoice = new Random();
            SpecialChoice = specialChoice.Next(2);
            int attackPoints = 0;

            if(SpecialChoice == 0 && heros[heroIndex].CurrentHitPoints >= 0)
            {
                SpecialName = special1;
                attackPoints = BreatheFire(heros[heroIndex]);
            }
            else
            {
                SpecialName = special2;
                foreach(Character hero in heros)
                {
                    if(hero.CurrentHitPoints >= 0)
                    {
                        attackPoints = SwipeAttack(heros[heroIndex]);
                    }
                } 
            }
            return attackPoints;    
        }
        //Breathe Fire Special
        public int BreatheFire(Character hero)
        {
            int breathFireReduceHitBy = (dragonStrength + dragonIntelligence) / 4;
            hero.CurrentHitPoints = hero.CurrentHitPoints - breathFireReduceHitBy;
            return breathFireReduceHitBy;
        }

        //Swipe Attack Special 
        public int SwipeAttack(Character hero)
        {
            int SwipeAttackReduceHitBy = (dragonStrength + dragonIntelligence) / 5;
            hero.CurrentHitPoints = hero.CurrentHitPoints - SwipeAttackReduceHitBy;
            return SwipeAttackReduceHitBy;
        }
    }
}