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
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Balance { get; set; } = 100;

        public void ProcessPayment (decimal amount)
        {
            Balance += amount;
        }

        public bool RefundPayment (decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public bool IsActive ()
        {
            if (EndDate < DateTime.Now)
                return true;
            return false;
        }

        public void Extend()
        {
            if (Balance >= Price)
            {
                Balance -= Price;
                StartDate = EndDate;
                EndDate = DateTime.Now.AddMonths(1);
            }
            else Console.WriteLine("Insufficient funds for the subscription.");
        }
        public void GetDetails()
        {
            Console.WriteLine($"Balance = {Balance}\nPrice of subscription = {Price}");
        }
    }
}
