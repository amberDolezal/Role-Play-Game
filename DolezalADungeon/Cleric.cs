﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Cleric : Hero
    {
        private static int clericDefense = 25;
        private static double clericHitPoints = 15;
        private static int clericStrength = 25;
        private static int clericSpeed = 6;
        private static int clericIntelligence = 25;
        private static int clericMagicDefense = 25;
        private static string clericName = "Cleric";
        private static string clericSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Cleric.png";
        private static string specialName = "Heal";
        private static int clericSkillPoints = 20;

        public Cleric() : base(specialName, specialName, clericSkillPoints, clericName, clericSpriteName, clericHitPoints, clericSpeed, clericStrength,
            clericIntelligence, clericDefense, clericMagicDefense)
        {
        }

        public override void Special(Character hero)
        {
            int healHitPointsBy;
            healHitPointsBy = clericIntelligence / 2;
            hero.CurrentHitPoints = hero.CurrentHitPoints + healHitPointsBy;
        }
    }
}