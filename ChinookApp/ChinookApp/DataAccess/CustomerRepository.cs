using ChinookApp.Models;
using ChinookApp.SqlHelpers;
using Microsoft.Data.SqlClient;

namespace ChinookApp.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Adds a new <see cref="Customer"/> to the databse.
        /// </summary>
        /// <param name="entity">The <see cref="Customer"/> object to add to the database.</param>
        public void Add(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Country", entity.Country);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// NOT IMPLEMENTED!!!
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all <see cref="Customer"/> objects in the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Customer"/> objects.</returns>
        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetSafeString(1),
                    reader.GetSafeString(2),
                    reader.GetSafeString(3),
                    reader.GetSafeString(4),
                    reader.GetSafeString(5),
                    reader.GetSafeString(6)
                    );
            }
        }

        /// <summary>
        /// Gets a single <see cref="Customer"/> by id from the database.
        /// </summary>
        /// <param name="id">The id to search for, as <see cref="int"/>.</param>
        /// <returns>A <see cref="Customer"/> object.</returns>
        public Customer GetById(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using var reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = new Customer(
                    reader.GetInt32(0),
                    reader.GetSafeString(1),
                    reader.GetSafeString(2),
                    reader.GetSafeString(3),
                    reader.GetSafeString(4),
                    reader.GetSafeString(5),
                    reader.GetSafeString(6)
                    );
            }

            return result;
        }

        /// <summary>
        /// Gets a single <see cref="Customer"/> by their first and last name.
        /// </summary>
        /// <param name="firstName">The first name to search for, as <see cref="string"/>.</param>
        /// <param name="lastName">The last name to search for, as <see cref="string"/>.</param>
        /// <returns>A <see cref="Customer"/> object.</returns>
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT TOP 1 CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @FirstName AND LastName LIKE @LastName";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            using var reader = command.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                result = new Customer(
                    reader.GetInt32(0),
                    reader.GetSafeString(1),
                    reader.GetSafeString(2),
                    reader.GetSafeString(3),
                    reader.GetSafeString(4),
                    reader.GetSafeString(5),
                    reader.GetSafeString(6)
                    );
            }

            return result;
        }

        /// <summary>
        /// Get a page of <see cref="Customer"/> objects, limited to, and offset by the given parameters.
        /// </summary>
        /// <param name="limit">The amount of <see cref="Customer"/> objects to get.</param>
        /// <param name="offset">The offset of selection.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Customer"/> objects.</returns>
        public IEnumerable<Customer> GetCustomerPage(int limit, int offset)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Limit", limit);
            command.Parameters.AddWithValue("@Offset", offset);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetSafeString(1),
                    reader.GetSafeString(2),
                    reader.GetSafeString(3),
                    reader.GetSafeString(4),
                    reader.GetSafeString(5),
                    reader.GetSafeString(6)
                    );
            }
        }

        /// <summary>
        /// Gets <see cref="CustomerSpender"/> objects with customer's name and their total spending ranked in order of most to least.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CustomerSpender"/> objects.</returns>
        public IEnumerable<CustomerSpender> GetCustomersByHigestSpending()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Customer.CustomerId, FirstName, LastName, SUM(Total) AS Spending FROM Customer LEFT JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId GROUP BY Customer.CustomerId, FirstName, LastName ORDER BY Spending DESC";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerSpender(
                    reader.GetInt32(0),
                    reader.GetSafeString(1),
                    reader.GetSafeString(2),
                    reader.GetSafeDecimal(3)
                    );
            }
        }

        /// <summary>
        /// Gets <see cref="CustomerGenre"/> objects with name and quantity of tracks of a specific genre for a customer with a given id.
        /// </summary>
        /// <remarks>Only returns more than one <see cref="CustomerGenre"/> object if the top genre is tied for quantity.</remarks>
        /// <param name="id">The id to search for, as <see cref="int"/>.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CustomerGenre"/> objects.</returns>
        public IEnumerable<CustomerGenre> GetMostPopularGenreByCustomerId(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT TOP 1 WITH TIES Genre.Name, SUM(InvoiceLine.Quantity) as TrackQuantity FROM Genre LEFT JOIN Track ON Genre.GenreId = Track.GenreId LEFT JOIN InvoiceLine ON Track.TrackId = InvoiceLine.TrackId LEFT JOIN Invoice ON Invoice.InvoiceId = InvoiceLine.InvoiceId WHERE Invoice.CustomerId = @CustomerId GROUP BY Genre.Name ORDER BY TrackQuantity DESC";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerGenre(
                    reader.GetSafeString(0),
                    reader.GetInt32(1)
                    );
            }
        }

        /// <summary>
        /// Gets <see cref="CustomerCountry"/> objects with country name and quantity of customers in that country, ranked by most to least.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CustomerCountry"/> objects.</returns>
        public IEnumerable<CustomerCountry> GetCountriesCustomerCount()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Country, COUNT(Country) AS CountryCount FROM Customer GROUP BY Country ORDER BY CountryCount DESC";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerCountry(
                    reader.GetSafeString(0),
                    reader.GetInt32(1)
                    );
            }
        }

        /// <summary>
        /// Updates a specific <see cref="Customer"/> in the database, with new values.
        /// </summary>
        /// <param name="entity">The new values to update as a <see cref="Customer"/> object.</param>
        public void Update(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Country", entity.Country);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@CustomerId", entity.Id);
            command.ExecuteNonQuery();
        }
    }
}
