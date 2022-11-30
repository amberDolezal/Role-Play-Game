﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Hero : Character
    {
        private string specialName1;
        private string specialName2;
        private int skillPoints;
        private string name;
        private string spriteName;
        private double hitPoints;
        private int speed;
        private int strength;
        private int intelligence;
        private int defense;
        private int magicDefense;

        public Hero(string specialName1, string specialName2, int skillPoints, string name, string spriteName, double hitPoints, int speed, int strength,
            int intelligence, int defense, int magicDefense) : base(name, spriteName, hitPoints, speed, strength, intelligence, defense, magicDefense, skillPoints, specialName1, specialName2)
        {
            this.specialName1 = specialName1;
            this.specialName2 = specialName2;
            this.skillPoints = skillPoints;
            this.name = name;
            this.spriteName = spriteName;
            this.hitPoints = hitPoints;
            this.speed = speed;
            this.strength = strength;
            this.intelligence = intelligence;
            this.defense = defense;
            this.magicDefense = magicDefense;
        }

    }
}