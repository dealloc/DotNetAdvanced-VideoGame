namespace VideoGame.Console.Entities.Weapons
{
    /// <summary>
    /// Onze <see cref="Sword"/> word door onze <see cref="Player"/> gebruikt om te vechten tegen <see cref="Monster"/>s.
    /// Hij erft over van de <see cref="Weapon"/> klasse zodat we onder andere de <see cref="Weapon.Damage"/> property niet elke keer opnieuw moeten definieren.
    /// </summary>
    public class Sword : Weapon
    {
        public Sword()
        {
            Damage = 5;
        }
    }
}
