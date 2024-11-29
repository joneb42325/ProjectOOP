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
        private string Name { get; set; }
        private string Adress { get; set; }


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
