using System.Data.SqlClient;
using VideoGame.Console.Entities;

namespace VideoGame.Console.Data
{
    /// <summary>
    /// Onze BaseRepository gaat voor een gegeven <typeparamref name="TEntity"/> de repository basis code aanbieden.
    /// 
    /// We erven van de interface <see cref="IDisposable"/> zodat ze 'using' statements kunnen gebruiken bij subklasses van BaseRepository.
    /// Dit zorgt er van weer voor dat onze connection mooi afgesloten word.
    /// </summary>
    /// <typeparam name="TEntity">De entity die we gaan beheren, kan eendert welke <see cref="Entity"/> subklasse zijn.</typeparam>
    public abstract class BaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        protected readonly SqlConnection _connection = new SqlConnection("Data Source=(local);Initial Catalog=VideoGame;Integrated Security=True");

        public BaseRepository()
        {
            _connection.Open();
        }

        /// <summary>
        /// De Save methode gaat een <typeparamref name="TEntity"/> opslaan in de databank.
        /// Als de <typeparamref name="TEntity"/> al bestaat in de databank (=> Id field is ingevuld) doen we een update, anders een insert.
        /// </summary>
        public TEntity Save(TEntity entity)
        {
            // Als de speler nog geen Id heeft is hij nog niet opgeslagen!
            if (entity.Id is null)
            {
                entity = Insert(entity);
            }
            else
            {
                Update(entity);
            }

            return entity;
        }

        protected abstract TEntity Insert(TEntity player);
        protected abstract void Update(TEntity player);

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
