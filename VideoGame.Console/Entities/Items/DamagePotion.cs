namespace VideoGame.Console.Entities.Items
{
    /// <summary>
    /// De <see cref="DamagePotion"/> geeft het wapen van de speler +10 damage.
    /// </summary>
    public class DamagePotion : Item
    {
        public override void Use(Player player)
        {
            if (player.Weapon is not null)
            {
                player.Weapon.Damage += 10;
            }
        }
    }
}
