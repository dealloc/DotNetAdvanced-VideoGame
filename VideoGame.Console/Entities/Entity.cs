namespace VideoGame.Console.Entities
{
    public abstract class Entity
    {
        /// <summary>
        /// De ID van deze entiteit in de databank.
        /// Als de Id op null staat is deze entiteit nog niet opgeslagen in de databank.
        /// </summary>
        public int? Id { get; set; }
    }
}
