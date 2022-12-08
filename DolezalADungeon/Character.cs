using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DolezalADungeon
{
    public class Character
    {
        #region Fields
        private string name;
        private string spriteName;
        private double hitPoints;
        private int speed;
        private int strength;
        private int intelligence;
        private int defense;
        private bool isDefending;
        private int magicDefense;
        private double currentHitPoints;
        private int skillPoints;
        private string specialName;
        private int specialChoice;
        private int heroHitPointsPool = 100;
        #endregion

        #region Constructors
        public Character(string name, string spriteName, double hitPoints, int speed, int strength, int intelligence, int defense, int magicDefense, int skillPoints, string specialName, int specialChoice)
        {
            this.name = name;
            this.spriteName = spriteName;
            this.hitPoints = hitPoints;
            this.currentHitPoints = hitPoints;
            this.speed = speed;
            this.strength = strength;
            this.intelligence = intelligence;
            this.defense = defense;
            this.isDefending = false;
            this.magicDefense = magicDefense;
            this.skillPoints = skillPoints;
            this.specialName = specialName;
            this.specialChoice = specialChoice;
        }
        public Character()
        {
            name = "Sprite";
            spriteName = "Image Name";
        }
        #endregion

        #region Properties
        public string Name { get => name; }
        public string SpriteName { get => spriteName; }
        public double HitPoints { get => hitPoints; set => hitPoints = value; }
        public int Speed { get => speed; }
        public int Strength { get => strength; }
        public int Intelligence { get => intelligence; }
        public int Defense { get => defense; }
        public bool IsDefending { get => isDefending; set => isDefending = value; }
        public int MagicDefense { get => magicDefense; }
        public double CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
        public int SkillPoints { get => skillPoints; }
        public string SpecialName { get => specialName; set => specialName = value; }
        public int HeroHitPointsPool { get => heroHitPointsPool; }
        public int SpecialChoice { get => specialChoice; set => specialChoice = value; }
        #endregion

        #region Methods
        public virtual int Attack(Character target)
        {
            int reduceHitPointsBy = (int)(strength + intelligence) / 3;
            target.currentHitPoints = target.currentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }

        public virtual void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy = attackPoints - (defense / 10);
            currentHitPoints = currentHitPoints + reduceAttackPointsBy;
        }

        public virtual int Special(List<Character> characters, int target)
        {
            specialName = "";
            return 0;
        }
        #endregion
    }
}