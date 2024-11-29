using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public class Client : Person
    {
        public Trainer PersonalTrainer;

        public Subscription CurrentSubscription;

        public decimal Balance;
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
                subscription.ProcessPayment(subscription.Price);

                CurrentSubscription = subscription;
                Console.WriteLine($"Month subscription purchased successfully");

          
                subscription.StartDate = DateTime.Now;
                subscription.EndDate = DateTime.Now.AddMonths(1); 
            }
            else
            {
                Console.WriteLine("Insufficient funds for the subscription.");
            }
        }

        public void UpdateSubscription()
        {
            if (CurrentSubscription != null)
                CurrentSubscription.Extend();
            else Console.WriteLine("Client don't have subscription yet.");
        }


        public void AssignTrainer (Trainer trainer, Client client)
        {
            trainer = PersonalTrainer;
            Trainer.AssignedClients.Add (client);
        }

        public void AddFunds(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Balance updated. New balance: {Balance}");
        }
        public string GetInformation()
        {
            string s;
            string subscriptionInfo = CurrentSubscription != null ?
                                      $"Subscription: Month (Valid from {CurrentSubscription.StartDate.ToShortDateString()} to {CurrentSubscription.EndDate.ToShortDateString()})" :
                                      "No active subscription.";
            string trainerInfo = PersonalTrainer != null ?
                                       $"Trainer Name : {PersonalTrainer.Name} Trainer Age: {PersonalTrainer.Age}" :
                                       "Client has not trainer";
            s=  $"Client Name: {Name}\nTrainer: {trainerInfo}\nBalance: {Balance:C}\n{subscriptionInfo}";
            return s;
        }
    }
}
