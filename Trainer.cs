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

        public string Specialization 
        {
            get { return specialization; }
            set {

                if (value.Length < 3 || value.Length > 30)
                {
                    throw new Exception("Спеціалізація повинна містити від 3 до 30 символів.");
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
                    Console.WriteLine("Ставка тренера повинна бути не менше 3$ за годину");
                hourlyRate = value;
            }
        }
   
        public void RemoveClient(Client client)
        {
            AssignedClients.Remove (client);
            Console.WriteLine("Ви успішно відмовилися від клієнта!");
        }

        public decimal CalculateMonthlyEarnings(int hoursWorked)
        {
            return HourlyRate * hoursWorked;
        }

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
