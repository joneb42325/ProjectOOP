using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public abstract class Person
    {
        private string name;

        private int age;  
        private string phoneNumber { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                foreach (char c in value)
                    if (char.IsDigit(c))
                    {
                        throw new Exception("The name must not contain digits");
                    }
                if (value.Length < 3)
                {
                    throw new Exception("The name must contain at least 3 characters.");
                }
                name = value;
            }
        }

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value <= 0 || value >= 120)
                {
                    throw new ArgumentException("Enter real life from 0 to 120 years");
                }
                age = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!value.StartsWith("+380"))
                {
                    throw new ArgumentException("Phone number must start with +380.");
                }
                if (value.Length != 13 || !value.Skip(1).All(char.IsDigit))
                {
                    throw new ArgumentException("Phone number must contain exactly 13 characters and consist of digits after +380.");
                }
                phoneNumber = value;
            }
        }
        

        public void UpdateContactInfo (string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
            Console.WriteLine("Номер телефону змінено!");
        }



        public virtual void GetInfo()
        {
            Console.WriteLine($"Name = {Name}, Age = {Age}, PhoneNumber = {PhoneNumber}");
            
        }

    }
}
