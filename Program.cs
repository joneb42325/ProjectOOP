using ProjectOOP;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Menu\n1 - Додати спортзал\n2 - Дії з клієнтом \n3 - Дії з тренером\n");
Gym gym = new Gym();
Trainer trainer = new Trainer();
Client client = new Client();
Subscription subscription = new Subscription();
gym.AddTrainer(trainer);
gym.AddClient(client);
client.Name = "Vlad";
trainer.Name = "Emanuel";
trainer.Age = 30;
Client client2  = new Client();
client2.Name = "Dan";
gym.AddClient(client2);
client2.Balance = 500;
client2.PurchaseSubscription(subscription);
trainer.Specialization = "Worker";
client.AssignTrainer(trainer, client2);
foreach (var item in gym.clients)
{
    Console.WriteLine(item.GetInformation());
}


//Console.WriteLine(trainer.GetInformation());

    