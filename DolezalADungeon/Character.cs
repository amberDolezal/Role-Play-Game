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
        private int currentHitPoints;
        #endregion

        #region Constructors
        public Character(string name, string spriteName, double hitPoints, int speed, int strength, int intelligence, int defense, int magicDefense)
        {
            this.name = name;
            this.spriteName = spriteName;
            this.hitPoints = hitPoints;
            this.speed = speed;
            this.strength = strength;
            this.intelligence = intelligence;
            this.defense = defense;
            this.isDefending = false;
            this.magicDefense = magicDefense;
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
        public double HitPoints { get => hitPoints; }
        public int Speed { get => speed; }
        public int Strength { get => strength; }
        public int Intelligence { get => intelligence; }
        public int Defense { get => defense; }
        public bool IsDefending { get => isDefending; set => isDefending = value; }
        public int MagicDefense { get => magicDefense; }
        public int CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
        #endregion

        #region Methods
        public void Attack(Character target)
        {
            int reduceHitPointsBy = currentHitPoints/strength;
            target.currentHitPoints = target.currentHitPoints - reduceHitPointsBy;
        }

        public double Defend(Character defender)
        {
            double reduceAttackPointsBy;
            reduceAttackPointsBy = defense/10;
            return reduceAttackPointsBy;
        }
        #endregion
    }
}