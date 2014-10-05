namespace TheSlum.Chatachters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, int healthPoints, int defensePoints,int healingPoiints, Team team, int range)
            : base(id, x, y, healthPoints,defensePoints, team, range )
        {
            this.HealingPoints = healingPoiints;
        }
         
        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targets = from target in targetsList
                          where target.IsAlive && target.Team == this.Team && target != this
                          orderby target.HealthPoints
                          select target;

            return targets.FirstOrDefault() as Character;
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
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" Healing: {0}", this.HealingPoints);
        }

    }
}
