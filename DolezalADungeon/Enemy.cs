using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DolezalADungeon
{
    public class Enemy : Character
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

        public Enemy(string specialName1, string specialName2, int skillPoints, string name, string spriteName, double hitPoints, int speed, int strength, 
            int intelligence, int defense, int magicDefense) : base(name, spriteName, hitPoints, speed, strength, intelligence, defense, magicDefense)
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

        public string SpecialName1 { get => specialName1; }
        public string SpecialName2 { get => specialName2; }
    }
}