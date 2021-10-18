namespace VideoGame.Console.Entities
{
    public abstract class Character
    {
        /// <summary>
        /// Hoeveel leven onze <see cref="Character"/> op dit moment nog heeft.
        /// </summary>
        public float Health { get; set; }

        /// <summary>
        /// Onder welke naam onze <see cref="Character"/> speelt.
        /// We kiezen hier enkel 'get' zodat de naam niet kan worden gewijzigd na aanmaken van de speler.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Onze constructor zorgt ervoor dat er altijd een naam en een health meegegeven word.
        /// </summary>
        public Character(string name, float health)
        {
            Name = name;
            Health = health;
        }
    }
}
