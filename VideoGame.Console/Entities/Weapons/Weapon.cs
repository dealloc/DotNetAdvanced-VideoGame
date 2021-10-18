using VideoGame.Console.Contracts;

namespace VideoGame.Console.Entities.Weapons
{
    /// <summary>
    /// De <see cref="Weapon"/> klasse word gebruikt als basis voor alle wapens in ons spel.
    /// Alle logica die in elk wapen gebruikt kan worden kunnen we in deze klasse plaatsen zodat ze onmiddelijk beschikbaar is in alle klassen die hiervan overerven.
    /// We maken deze klasse 'abstract' zodat we geen instanties kunnen maken van 'Weapon' zelf, enkel van zijn (niet abstracte) subklassen.
    /// </summary>
    public abstract class Weapon : IDamageDealer
    {
        /// <summary>
        /// De ID die in de databank opgeslagen is, of null als dit wapen nog niet opgeslagen is!
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Hoeveel damage deze <see cref="Weapon"/> doet.
        /// </summary>
        public float Damage { get; set; }

        /// <summary>
        /// Een wapen doet schade naargelang de 'Damage' eigenschap.
        /// </summary>
        /// Deze syntax is dezelfde als:
        /// public float AmountOfDamage()
        /// {
        ///     return Damage;
        /// }
        ///
        /// Als een functie enkel een return statement bevat, kan je deze als een arrow functie schrijven.
        public float AmountOfDamage() => Damage;
    }
}
