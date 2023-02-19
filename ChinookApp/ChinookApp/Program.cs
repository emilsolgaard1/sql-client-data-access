using ChinookApp.DataAccess;
using ChinookApp.Models;
using ChinookApp.SqlHelpers;

internal class Program
{
    private static void Main(string[] args)
    {
        var customerRepository = new CustomerRepository { ConnectionString = SqlConnectionHelper.GetConnectionString() };

        //customerRepository.Add(new Customer(0, "TEST", "TESTSON", "TESTLAND", "8888", "88888888", "TEST@TEST.TEST"));
        //customerRepository.Update(new Customer(60, "TEST", "T. TESTSON", "NEW TESTLAND", "8888", "88888888", "TEST@TEST.TEST"));

        //var customers = customerRepository.GetAll();
        //foreach (var customer in customers)
        //{
        //    Console.WriteLine($"Customer id: {customer.Id}, Customer name: {customer.FirstName} {customer.LastName}");
        //}

        //var customer = customerRepository.GetById(60);
        //Console.WriteLine($"Customer name: {customer.FirstName} {customer.LastName}");

        //var customer = customerRepository.GetCustomerByName("TEST", "T. TESTSON");
        //Console.WriteLine($"Customer id: {customer.Id}, Customer name: {customer.FirstName} {customer.LastName}");

        //var customers = customerRepository.GetCustomerPage(10, 0);
        //foreach (var customer in customers)
        //{
        //    Console.WriteLine($"Customer id: {customer.Id}, Customer name: {customer.FirstName} {customer.LastName}");
        //}

        //var customerSpenders = customerRepository.GetCustomersByHigestSpending();
        //foreach (var customerSpender in customerSpenders)
        //{
        //    Console.WriteLine($"Customer spending: {customerSpender.Spending}, Customer name: {customerSpender.CustomerFirstName} {customerSpender.CustomerLastName}");
        //}

        //var customerGenres = customerRepository.GetMostPopularGenreByCustomerId(1);
        //if (customerGenres.ToList().Count > 0)
        //{
        //    Console.WriteLine($"Customer's favorite genre: {customerGenres.ToArray()[0].CustomerGenreName}, with {customerGenres.ToArray()[0].CustomerGenreQuantity} tracks");
        //    if (customerGenres.ToList().Count > 1)
        //    {
        //        Console.Write($" tied with {customerGenres.ToArray()[0].CustomerGenreName}, with {customerGenres.ToArray()[0].CustomerGenreQuantity} tracks");
        //    }
        //}
        //else Console.WriteLine("Customer has no tracks.");

        //var customerCountries = customerRepository.GetCountriesCustomerCount();
        //foreach (var customerCountry in customerCountries)
        //{
        //    Console.WriteLine($"Country name: {customerCountry.CustomerCountryName}, number of customers: {customerCountry.CustomerCountryCount}");
        //}

        Console.WriteLine("\nPress any key to Exit.");
        Console.ReadKey();
    }
}