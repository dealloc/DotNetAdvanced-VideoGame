using System.Xml.Serialization;
using VideoGame.Console.Contracts;
using VideoGame.Console.Entities.Items;
using VideoGame.Console.Entities.Weapons;

namespace VideoGame.Console.Entities
{
    /// <summary>
    /// Onze <see cref="Player"/> klasse stelt de speler voor die momenteel aan het spelen is.
    /// </summary>
    [XmlRoot, XmlInclude(typeof(Sword)), XmlInclude(typeof(Wand))]
    public class Player : Character, IDamageDealer
    {
        /// <summary>
        /// Welk <see cref="PlayerType"/> onze speler momenteel speelt.
        /// We kiezen hier enkel 'get' zodat het type niet kan worden gewijzigd na aanmaken van de speler.
        /// </summary>
        [XmlAttribute("Type")]
        public PlayerType Type { get; set; }

        /// <summary>
        /// Het wapen dat onze speler gebruikt, als deze property op null staat heeft de speler geen wapen equipped en doet hij 0 damage.
        /// </summary>
        [XmlElement]
        public Weapon? Weapon { get; set; }

        /// <summary>
        /// De <see cref="Item"/>s die de speler momenteel bij zich heeft die hij kan gebruiken.
        /// </summary>
        [XmlIgnore]
        public List<Item> Inventory { get; set; } = new List<Item>();

        [Obsolete]
        public Player() : base("<INVALID>", 0)
        {

        }

        /// <summary>
        /// De constructor van onze speler klasse.
        /// </summary>
        /// <param name="name">De naam die onze speler kiest (word ingevuld in de <see cref="Name"/> property.</param>
        /// <param name="type">Het type dat onze speler kiest (word ingevuld in de <see cref="Type"/> property.</param>
        ///                                           base <- hier refereert naar de constructor van de base klasse: Character.
        public Player(string name, PlayerType type) : base(name, 100)
        {
            Type = type;

            if (type == PlayerType.Warrior)
            {
                Weapon = new Sword();
            }
            else
            {
                Weapon = new Wand();
            }
        }

        /// <summary>
        /// We geven de schade terug die ons wapen kan doen, als Weapon null is geven we 0 terug.
        /// </summary>
        /// De ?. operator kan je schrijven als:
        /// if (Weapon is null)
        ///     return null;
        /// else
        ///     Weapon?.AmountOfDamage();
        /// De ?? operator kan je ook schrijven als:
        /// if (Weapon?.AmountOfDamage() is null)
        ///     return null;
        /// else
        ///     Weapon?.AmountOfDamage();
        public float AmountOfDamage() => Weapon?.AmountOfDamage() ?? 0;

        /// <summary>
        /// Het type speler, kan enkel <see cref="Warrior"/> of <see cref="Warlock"/> zijn.
        /// </summary>
        public enum PlayerType
        {
            [XmlEnum(Name = "Warrior")]
            Warrior,
            [XmlEnum(Name = "Warlock")]
            Warlock
        }
    }
}
