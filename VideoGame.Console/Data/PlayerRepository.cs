using System.Data.SqlClient;
using VideoGame.Console.Entities;

namespace VideoGame.Console.Data
{
    /// <summary>
    /// De <see cref="PlayerRepository"/> is verantwoordelijk voor het managen van <see cref="Player"/> instanties in de databank.
    /// </summary>
    public class PlayerRepository : BaseRepository<Player>
    {
        protected override Player Insert(Player player)
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

        protected override void Update(Player player)
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
