namespace VideoGame.Console.Entities.Items
{
    /// <summary>
    /// De item klasse is onze base klasse voor alle voorwerpen die onze speler kan gebruiken, zoals health potions.
    /// </summary>
    public abstract class Item : Entity
    {
        /// <summary>
        /// Word opgeroepen wanneer het item gebruikt word op de <see cref="Player"/> instantie die het item gebruikt.
        /// 
        /// Door de methode abstract te maken verplichten we subklassen om deze te implementeren.
        /// </summary>
        public abstract void Use(Player player);
    }
}
