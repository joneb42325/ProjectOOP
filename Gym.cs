using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Gym
    {
        private string name { get; set; }
        private string adress { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Назва спортзалу не може бути пустою.");
                }
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Назва спортзалу має містити від 3 до 10 символів.");
                }
                name = value;
            }
        }
        public string Adress
        {
            get { return adress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Адреса спортзалу не може бути пустою.");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Адреса спортзалу має містити від 5 до 10 символів.");
                }
                if (!value.Any(char.IsLetter) || !value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Адреса повинна містити хоча б одну букву і цифру.");
                }
                adress = value;
            }
        }
        public List<Client> clients = new List<Client>();

        public List<Trainer> trainers = new List<Trainer>();
        public void AddTrainer(Trainer trainer)
        {
            trainers.Add(trainer);
        }
        public void RemoveTrainer(Trainer trainer)
        {
           trainers.Remove(trainer);
        }
        public void AddClient(Client client)
        {
            clients.Add(client);
        } 
        public void RemoveClient(Client client)
        {
            clients.Remove(client);
        }
       
    }
}
