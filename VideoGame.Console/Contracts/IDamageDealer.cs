namespace VideoGame.Console.Contracts
{
    /// <summary>
    /// Een interface bevat geen implementatie (we schrijven niet hoe de 'AmountOfDamage' functie werkt)
    /// maar wel hoe de functionaliteit eruit ziet (AmountOfDamage returned een float en neemt geen parameters).
    ///
    /// Deze interface laat ons toe om logica te definieren voor iets dat schade kan toebrengen zonder te definieren *hoe*.
    /// </summary>
    public interface IDamageDealer
    {
        /// <summary>
        /// Deze methode returned hoeveel damage we zouden doen in een aanval.
        /// </summary>
        float AmountOfDamage();
    }
}
