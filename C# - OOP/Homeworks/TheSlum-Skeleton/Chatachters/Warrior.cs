namespace TheSlum.Chatachters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, int healthPoints, int defensePoints,int attackPoints, Team team, int range)
            : base(id, x, y, healthPoints,defensePoints, team, range )
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList.FirstOrDefault(ch => ch.Team != this.Team && ch.IsAlive);
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" Attack: {0}", this.AttackPoints);
        }
    }
}
