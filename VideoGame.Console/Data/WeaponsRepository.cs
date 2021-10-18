using System.Data.SqlClient;
using VideoGame.Console.Entities.Weapons;

namespace VideoGame.Console.Data
{
    public class WeaponsRepository
    {
        private readonly SqlConnection _connection = new SqlConnection("Data Source=(local);Initial Catalog=VideoGame;Integrated Security=True");

        public WeaponsRepository()
        {
            _connection.Open();
        }

        public Weapon Save(Weapon weapon)
        {
            // Als de speler nog geen Id heeft is hij nog niet opgeslagen!
            if (weapon.Id is null)
            {
                weapon = Insert(weapon);
            }
            else
            {
                Update(weapon);
            }

            return weapon;
        }

        private Weapon Insert(Weapon weapon)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO [Weapons] (Class, Damage) VALUES (@Class, @Damage); SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@Class", weapon.GetType().FullName);
            command.Parameters.AddWithValue("@Damage", weapon.Damage);

            using var reader = command.ExecuteReader();
            reader.Read();
            weapon.Id = (int)reader.GetDecimal(0);

            return weapon;
        }

        private void Update(Weapon weapon)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE [Weapons] SET [Class] = @Class, [Damage] = @Damage";
            command.Parameters.AddWithValue("@Class", weapon.GetType().FullName);
            command.Parameters.AddWithValue("@Damage", weapon.Damage);

            command.ExecuteNonQuery();
        }
    }
}
