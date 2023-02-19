using Microsoft.Data.SqlClient;

namespace ChinookApp.SqlHelpers
{
    public static class SqlConnectionHelper {
        /// <summary>
        /// Gets the connection string to open a sql client connection to database.
        /// </summary>
        /// <returns>The build connection string as <see cref="string"/>.</returns>
        public static string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost\\SQLEXPRESS",
                InitialCatalog = "Chinook",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }
    }
}
