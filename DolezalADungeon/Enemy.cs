using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DolezalADungeon
{
    public class Enemy : Character
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

        public Enemy(string specialName, int skillPoints, string name, string spriteName, double hitPoints, int speed, int strength, 
            int intelligence, int defense, int magicDefense) : base(name, spriteName, hitPoints, speed, strength, intelligence, defense, magicDefense, skillPoints, specialName)
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
            this.skillPoints = skillPoints;
        }

        public string SpecialName { get => specialName; }
    }
}