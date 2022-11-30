using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Dragon : Enemy
    {
        private static int dragonDefense = 45;
        private static double dragonHitPoints = 50;
        private static int dragonStrength = 20;
        private static int dragonSpeed = 4;
        private static int dragonIntelligence = 30;
        private static int dragonMagicDefense = 45;
        private static string dragonName = "Dragon";
        private static string dragonSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Dragon.png";
        private static string specialName = "";
        private string special1 = "Breathe Fire";
        private string special2 = "Swipe Attack";
        private static int dragonSkillPoints = 20;
        private int dragonSpecialChoice = 0;

        public Dragon() : base(specialName, dragonSkillPoints, dragonName, dragonSpriteName, dragonHitPoints, dragonSpeed, dragonStrength,
            dragonIntelligence, dragonDefense, dragonMagicDefense)
        {
        }

        public override int Special(List<Character> heros, int heroIndex)
        {
            Random specialChoice = new Random();
            int attackPoints = 0;

            if(dragonSpecialChoice == 0)
            {
                specialName = special1;
                attackPoints = BreatheFire(heros[heroIndex]);
            }
            else
            {
                specialName = special2;
                foreach(Character hero in heros)
                {
                   attackPoints = SwipeAttack(hero);
                } 
            }
            return attackPoints;    
        }
        //Breathe Fire Special
        public int BreatheFire(Character hero)
        {
            int breathFireReduceHitBy = dragonStrength/3;
            hero.CurrentHitPoints = hero.CurrentHitPoints - breathFireReduceHitBy;
            return breathFireReduceHitBy;
        }

        //Swipe Attack Special 
        public int SwipeAttack(Character hero)
        {
            int SwipeAttackReduceHitBy = dragonStrength / 2;
            hero.CurrentHitPoints = hero.CurrentHitPoints - SwipeAttackReduceHitBy;
            return SwipeAttackReduceHitBy;
        }
    }
}