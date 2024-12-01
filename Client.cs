using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Client : Person
    {
        public Trainer PersonalTrainer { get; set; }

        public Subscription CurrentSubscription;

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set {
                if (value < 0)
                    throw new ArgumentException("Баланс повинен бути > 0 $");
                balance = value;
            }
        }
        public void PurchaseSubscription(Subscription subscription)
        {
            if (CurrentSubscription != null)
            {
                Console.WriteLine("You already have an active subscription.");
                return;
            }

            if (Balance >= subscription.Price)
            {
                Balance -= subscription.Price;

                CurrentSubscription = subscription;
                Console.WriteLine($"Місячний абонемент успішно придбано!\n З балансу списано {CurrentSubscription.Price}$");

          
                subscription.StartDate = DateTime.Now;
                subscription.EndDate = DateTime.Now.AddMonths(1); 
            }
            else
            {
                Console.WriteLine("Insufficient funds for the subscription.");
            }
        }

        public void ExtendSubscription()
        {
            if (CurrentSubscription != null)
            {
                if (Balance >= CurrentSubscription.Price)
                {
                    Balance -= CurrentSubscription.Price;
                    CurrentSubscription.EndDate = CurrentSubscription.EndDate.AddMonths(1);
                    Console.WriteLine("Абонемент подовжено на місяць!");
                }
                else Console.WriteLine("Insufficient funds for the subscription.");
            }
            else Console.WriteLine("Client don't have subscription yet.");
            
        }

        
        public void AssignTrainer (Trainer trainer, Client client)
        {
            PersonalTrainer = trainer;
            Trainer.AssignedClients.Add (client);
        }

        public void RemoveTrainer (Trainer trainer, Client client)
        {
            PersonalTrainer = null;
            Trainer.AssignedClients.Remove (client);
        }
        public void AddFunds(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Balance updated. New balance: {Balance}");
        }

        public override void GetInfo()
        {
            base.GetInfo();
        }
        public void GetInformation()
        {
            
            string subscriptionInfo = CurrentSubscription != null ?
                                      $"Subscription: Month (Valid from {CurrentSubscription.StartDate.ToShortDateString()} to {CurrentSubscription.EndDate.ToShortDateString()})" :
                                      "No active subscription.";
            string trainerInfo = PersonalTrainer != null ?
                                       $"Trainer Name : {PersonalTrainer.Name}; Trainer Age: {PersonalTrainer.Age}" :
                                       "Client has not trainer";
            Console.WriteLine($"Client Name: {Name}\nTrainer: {trainerInfo}\nBalance: {Balance}$\n{subscriptionInfo}");
        }
    }
}
