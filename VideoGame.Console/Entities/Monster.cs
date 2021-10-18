using VideoGame.Console.Contracts;

namespace VideoGame.Console.Entities
{
    /// <summary>
    /// De <see cref="Monster"/> klasse stelt een monster voor waartegen de <see cref="Player"/> kan vechten.
    /// </summary>
    public class Monster : IDamageDealer
    {
        /// <summary>
        /// Hoeveel leven het monster heeft op dit moment.
        /// Word meegegeven bij het aanmaken van een nieuw monster.
        /// </summary>
        public float Health { get; set; }

        /// <summary>
        /// De naam van het monster, zodat we weten waartegen de <see cref="Player"/> vecht.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Maakt een nieuw <see cref="Monster"/> aan met de opgegeven <paramref name="name"/> en <paramref name="health"/>.
        /// </summary>
        /// <param name="name">De naam van het monster.</param>
        /// <param name="health">Hoeveel leven het monster krijgt.</param>
        public Monster(string name, float health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Op dit moment doen monsters standaard 10 damage.
        /// </summary>
        /// <returns></returns>
        public float AmountOfDamage() => 10;
    }
}
