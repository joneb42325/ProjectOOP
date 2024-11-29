using ProjectOOP;

Gym gym = new Gym();
Trainer trainer = new Trainer();
Client client = new Client();
Subscription subscription = new Subscription();
gym.AddTrainer(trainer);
gym.AddClient(client);
client.Name = "Vlad";
trainer.Name = "Emanuel";
Client client2  = new Client();
client2.Name = "Dan";
gym.AddClient(client2);
client2.Balance = 500;
client2.PurchaseSubscription(subscription);
trainer.Specialization = "Worker";
trainer.AssignClient(client);
foreach (var item in gym.clients)
{
    Console.WriteLine(item.GetInformation());
}


//Console.WriteLine(trainer.GetInformation());

    