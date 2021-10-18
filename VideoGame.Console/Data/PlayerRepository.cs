using System.Data.SqlClient;
using VideoGame.Console.Entities;

namespace VideoGame.Console.Data
{
    /// <summary>
    /// De <see cref="PlayerRepository"/> is verantwoordelijk voor het managen van <see cref="Player"/> instanties in de databank.
    /// </summary>
    public class PlayerRepository
    {
        // Onze SqlConnection naar de databank.
        private readonly SqlConnection _connection = new SqlConnection("Data Source=(local);Initial Catalog=VideoGame;Integrated Security=True");

        public PlayerRepository()
        {
            _connection.Open();
        }

        /// <summary>
        /// De Save methode gaat een <see cref="Player"/> opslaan in de databank.
        /// Als de <see cref="Player"/> al bestaat in de databank (=> Id field is ingevuld) doen we een update, anders een insert.
        /// </summary>
        public Player Save(Player player)
        {
            // Als de speler nog geen Id heeft is hij nog niet opgeslagen!
            if (player.Id is null)
            {
                player = Insert(player);
            }
            else
            {
                Update(player);
            }

            return player;
        }

        private Player Insert(Player player)
        {
            using var command = _connection.CreateCommand();
            // Merk op dat we SELECT SCOPE_IDENTITY() zetten op het einde!
            command.CommandText = "INSERT INTO [Players] (Username, Class, Health, WeaponId) VALUES (@Username, @Class, @Health, @WeaponId); SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@Username", player.Name);
            command.Parameters.AddWithValue("@Class", player.Type.ToString());
            command.Parameters.AddWithValue("@Health", player.Health);
            command.Parameters.AddWithValue("@WeaponId", player.Weapon?.Id);

            // De SCOPE_IDENTITY geeft de Id terug van de insert die we net deden, zo weten we direct welke Id onze speler gekregen heeft!
            using var reader = command.ExecuteReader();
            reader.Read();
            player.Id = (int)reader.GetDecimal(0); // We lezen de ID onmiddelijk in op ons player object.

            return player;
        }

        private void Update(Player player)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE [Players] SET [username] = @Username, [Health] = @Health, [Class] = @Class, WeaponId = @WeaponId";
            command.Parameters.AddWithValue("@Username", player.Name);
            command.Parameters.AddWithValue("@Class", player.Type.ToString());
            command.Parameters.AddWithValue("@Health", player.Health);
            command.Parameters.AddWithValue("@WeaponId", player.Weapon?.Id);

            command.ExecuteNonQuery();
        }
    }
}
