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
        private static string special1 = "Breathe Fire";
        private static string special2 = "Swipe Attack";
        private static int dragonSkillPoints = 20;

        public Dragon() : base(special1, special2, dragonSkillPoints, dragonName, dragonSpriteName, dragonHitPoints, dragonSpeed, dragonStrength,
            dragonIntelligence, dragonDefense, dragonMagicDefense)
        {
        }

        public int BreatheFire()
        {
            int reduceHitPointsBy;
            reduceHitPointsBy = dragonStrength/3;
            return reduceHitPointsBy;
        }

        public int SwipeAttack()
        {
            int reduceHitPointsBy;
            reduceHitPointsBy=dragonStrength/3;
            return reduceHitPointsBy;
        }
    }
}