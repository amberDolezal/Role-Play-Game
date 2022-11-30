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
        private string specialName1;
        private string specialName2;    
        #endregion

        #region Constructors
        public Character(string name, string spriteName, double hitPoints, int speed, int strength, int intelligence, int defense, int magicDefense, int skillPoints, string specialName1, string specialName2)
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
            this.specialName1 = specialName1;
            this.specialName2 = specialName2;
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
        public string SpecialName1 { get => specialName1; }
        public string SpecialName2 { get => specialName2; }
        #endregion

        #region Methods
        public int Attack(Character target)
        {
            int reduceHitPointsBy = (int)strength/3;
            target.currentHitPoints = target.currentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }

        public void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy = attackPoints*(defense/10);
            currentHitPoints = currentHitPoints + reduceAttackPointsBy;
        }

        public virtual void Special(Character target)
        {

        }
        #endregion
    }
}