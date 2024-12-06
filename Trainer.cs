using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Trainer : Person
    {
        public static List<Client> AssignedClients = new List<Client>();

        private string specialization;

        private decimal hourlyRate;

        private int age;

        public Func<int, decimal> CalculateEarnings;

        public Predicate<Client> CanTakeClient { get; set; }

        public bool AddClientIfEligible(Client client)
        {
            if (CanTakeClient(client))
            {
                return true;
            }
           
            return false;
        }


        public string Specialization 
        {
            get { return specialization; }
            set {

                if (value.Length < 3 || value.Length > 30)
                {
                    throw new Exception("Спеціалізація повинна містити від 3 до 100 символів.");
                }
                if (value.Count(char.IsLetter) < 5) 
                {
                    throw new ArgumentException("Спеціалізація повинна містити не менше 5 букв.");
                }
                specialization = value; 
            }
        }

        public decimal HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                if (value <= 3)
                    throw new Exception("Ставка тренера повинна бути не менше 3$ за годину");
                hourlyRate = value;
            }
        }

        public override int Age {
            // get => base.Age; set => base.Age = value;
            get { return age; }
            set
            {
                if (value <= 18 || value >= 50)
                {
                    throw new ArgumentException("Enter real life from 18 to 50 years");
                }
                age = value;
            }
        }

        public void RemoveClient(Client client)
        {
            AssignedClients.Remove (client);
        }

        
       /* public decimal CalculateMonthlyEarnings(int hoursWorked)
        {
            return HourlyRate * hoursWorked;
        } */

        public override void GetInfo()
        {
            base.GetInfo(); 
        }
        public void GetInformation ()
        {
            Console.WriteLine( $"Trainer Name: {Name}\n Speсialization: {Specialization}\n Amount of Clients: {AssignedClients.Count}");
        }
    }
}
