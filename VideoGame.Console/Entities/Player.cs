namespace VideoGame.Console.Entities
{
    /// <summary>
    /// Onze <see cref="Player"/> klasse stelt de speler voor die momenteel aan het spelen is.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Hoeveel leven onze speler op dit moment nog heeft.
        /// Een nieuwe speler heeft standaard 100 health.
        /// </summary>
        public float Health { get; set; } = 100;

        /// <summary>
        /// Welk <see cref="PlayerType"/> onze speler momenteel speelt.
        /// We kiezen hier enkel 'get' zodat het type niet kan worden gewijzigd na aanmaken van de speler.
        /// </summary>
        public PlayerType Type { get; }

        /// <summary>
        /// Onder welke naam onze speler speelt.
        /// We kiezen hier enkel 'get' zodat de naam niet kan worden gewijzigd na aanmaken van de speler.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// De constructor van onze speler klasse.
        /// </summary>
        /// <param name="name">De naam die onze speler kiest (word ingevuld in de <see cref="Name"/> property.</param>
        /// <param name="type">Het type dat onze speler kiest (word ingevuld in de <see cref="Type"/> property.</param>
        public Player(string name, PlayerType type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Het type speler, kan enkel <see cref="Warrior"/> of <see cref="Warlock"/> zijn.
        /// </summary>
        public enum PlayerType
        {
            Warrior,
            Warlock
        }
    }
}
