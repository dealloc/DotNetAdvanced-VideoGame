namespace VideoGame.Console.Entities.Weapons
{
    /// <summary>
    /// De <see cref="Weapon"/> klasse word gebruikt als basis voor alle wapens in ons spel.
    /// Alle logica die in elk wapen gebruikt kan worden kunnen we in deze klasse plaatsen zodat ze onmiddelijk beschikbaar is in alle klassen die hiervan overerven.
    /// We maken deze klasse 'abstract' zodat we geen instanties kunnen maken van 'Weapon' zelf, enkel van zijn (niet abstracte) subklassen.
    /// </summary>
    public abstract class Weapon
    {
        /// <summary>
        /// Hoeveel damage deze <see cref="Weapon"/> doet.
        /// </summary>
        public float Damage { get; set; }
    }
}
