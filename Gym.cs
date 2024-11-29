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
            set {  name = value; }
       }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
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
