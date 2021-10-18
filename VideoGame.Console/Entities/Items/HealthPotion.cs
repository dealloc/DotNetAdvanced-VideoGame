namespace VideoGame.Console.Entities.Items
{
    /// <summary>
    /// De <see cref="HealthPotion"/> klasse is een soort <see cref="Item"/> die de speler +20 health geeft wanneer hij word gebruikt.
    /// </summary>
    public class HealthPotion : Item
    {
        public override void Use(Player player)
        {
            player.Health += 20;
        }
    }
}
