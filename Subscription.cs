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

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Вартість абонементу не може бути від'ємною");
                price = value;
            }
        }
        public void ProcessPayment (decimal amount)
        {
            Balance += amount;
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
