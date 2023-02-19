using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookApp.Models
{
    public readonly record struct CustomerSpender(int CustomerId, string CustomerFirstName, string CustomerLastName, decimal Spending);
}
