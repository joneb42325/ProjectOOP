using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Subscription : IPayment
    {
        private decimal price; 
        public DateTime StartDate;
        public DateTime EndDate;

        public decimal Balance;

        public decimal Price { get; set; } = 10;
        
        public bool IsActive ()
        {
            return DateTime.Now <= EndDate;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Balance = {Balance}\nPrice of subscription = {Price}");
        }
    }
}
