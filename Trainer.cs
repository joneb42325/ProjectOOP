using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Trainer : Person
    {
        public static List<Client> AssignedClients = new List<Client>();

       public string Specialization { get; set; }

        decimal HourlyRate;

        public void AssignClient (Client client)
        {
            AssignedClients.Add (client);
            client.PersonalTrainer = this;
        }
        public void RemoveClient(Client client)
        {
            AssignedClients.Remove (client);    
        }

        public decimal CalculateMonthlyEarnings(int hoursWorked)
        {
            return HourlyRate * hoursWorked;
        }

        public string GetInformation ()
        {
            string s;
            s = $"Trainer Name: {Name}\n Spesialization: {Specialization}\n Amount of Clients: {AssignedClients.Count}";
            return s;
        }
    }
}
