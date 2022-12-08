using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace DolezalADungeon
{
    public class Bandit : Enemy
    {
        private static int banditDefense = 1;
        private static double banditHitPoints = 10;
        private static int banditStrength = 5;
        private static int banditSpeed = 10;
        private static int banditIntelligence = 1;
        private static int banditMagicDefense = banditDefense;
        private static string banditName = "Bandit";
        private static string banditSpriteName = "C:\\Users\\macmi\\OneDrive\\Documents\\CS 3020\\DolezalADungeon\\sprites\\Bandit.png";
        private static string specialName = "";
        private static int banditSkillPoints = 2;
        private static int banditSpecialChoice = 0;

        public Bandit() : base(specialName, banditSkillPoints, banditName, banditSpriteName, banditHitPoints, banditSpeed, banditStrength, 
            banditIntelligence, banditDefense, banditMagicDefense, banditSpecialChoice)
        {
        }
        //Physical attack
        public override int Attack(Character target)
        {
            int reduceHitPointsBy = (banditStrength + banditIntelligence) / 3;
            target.CurrentHitPoints = target.CurrentHitPoints - reduceHitPointsBy;
            return reduceHitPointsBy;
        }
        //low defense, weak to both physical and magical defense
        public override void Defend(Character attacker, int attackPoints)
        {
            int reduceAttackPointsBy = attackPoints - banditDefense;
            CurrentHitPoints = CurrentHitPoints + reduceAttackPointsBy;
        }
    }
}