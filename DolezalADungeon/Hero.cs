using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Hero : Character
    {
        private string specialName;
        private int skillPoints;
        private string name;
        private string spriteName;
        private double hitPoints;
        private int speed;
        private int strength;
        private int intelligence;
        private int defense;
        private int magicDefense;

        public Hero(string specialName, int skillPoints, string name, string spriteName, double hitPoints, int speed, int strength,
            int intelligence, int defense, int magicDefense) : base(name, spriteName, hitPoints, speed, strength, intelligence, defense, magicDefense)
        {
            this.specialName = specialName;
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

        public string SpecialName { get => specialName; }
    }
}