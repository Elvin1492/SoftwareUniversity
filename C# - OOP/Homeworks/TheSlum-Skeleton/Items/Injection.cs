namespace TheSlum.Items
{
    using TheSlum;

    public class Injection :Bonus
    {
         public Injection(string id, int healthEffect = 200, int defenseEffect = 0, int attackEffect =100)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 3;
            this.Timeout = 3;
            this.HasTimedOut = false;
        }
    }
}
