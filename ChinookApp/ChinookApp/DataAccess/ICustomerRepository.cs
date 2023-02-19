using ChinookApp.Models;

namespace ChinookApp.DataAccess
{
    internal interface ICustomerRepository : ICrudRepository<Customer, int>
    {
        Customer GetCustomerByName(string firstName, string lastName);
        IEnumerable<Customer> GetCustomerPage(int limit, int offset);
        IEnumerable<CustomerCountry> GetCountriesCustomerCount();
        IEnumerable<CustomerSpender> GetCustomersByHigestSpending();
        IEnumerable<CustomerGenre> GetMostPopularGenreByCustomerId(int id);
    }
}
