using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace datingedit.Models
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool GetUser(string navn, string adgangskode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM UserProfiles WHERE Navn = @Navn AND Adgangskode = @Adgangskode"; // Antager din tabel hedder 'Brugere'
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Navn", navn);
                    command.Parameters.AddWithValue("@Adgangskode", adgangskode);

                    using (var reader = command.ExecuteReader())
                    {
                        bool result =  reader.HasRows;
                        return result;
                    }
                }
            }
        }
    }
}

