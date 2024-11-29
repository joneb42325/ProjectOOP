using ProjectOOP;

Console.OutputEncoding = System.Text.Encoding.UTF8;
List<Gym> gyms = new List<Gym>();
bool working = true;
while (working)
{
    Console.WriteLine("Menu\n1 - Додати спортзал\n2 - Дії з клієнтом \n3 - Дії з тренером\n");
    int menu = int.Parse(Console.ReadLine());
    switch (menu)
    {
        case 1:
            Gym gym1 = new Gym();
            Console.Write("Input name of gym-->");
            gym1.Name = Console.ReadLine();
            Console.Write("Input adress of gym-->");
            gym1.Adress = Console.ReadLine();
            gyms.Add(gym1);
            Console.WriteLine("Gym added!");
            break;

        case 2:
            if (gyms.Count == 0)
            {
                Console.WriteLine("Спочатку додайте спортзал.");
                break;
            }

            Console.WriteLine("Оберіть спортзал:");
            for (int i = 0; i < gyms.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {gyms[i].Name}");
            }
            int gymChoice = int.Parse(Console.ReadLine()) - 1;
            Gym selectedGym = gyms[gymChoice];

            Console.WriteLine("1 - Додати клієнта\n2 - Покласти гроші на карту\n3 - Покласти гроші на клієнтську карту (абонемент)\n4 - Купити абономент\n5 - Подовжити абонемент\n6 - Записатися до тренера\n7 - Відмовитися від тренера\n8 - Перевірити чи дійсний абонемент\n9 - Вивести інформацію про клієнта\n10 - Вивести інформацію про абонемент\n11 - Вивести особисту інформацію клієнта");
            int menuClient = int.Parse(Console.ReadLine());
            switch (menuClient)
            {
                case 1:
                    Client client1 = new Client();
                    Console.Write("Введіть ім'я клієнта: ");
                    client1.Name = Console.ReadLine();
                    Console.Write("Введіть вік клієнта: ");
                    client1.Age = int.Parse(Console.ReadLine());
                    Console.Write("Введіть номер телефону клієнта (+380...): ");
                    client1.PhoneNumber = Console.ReadLine();
                    selectedGym.AddClient(client1);
                    Console.WriteLine("Клієнта додано!");
                    break;
                case 2:
                    Console.WriteLine("Оберіть клієнта:");
                    for (int i = 0; i < selectedGym.clients.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                    }
                    int clientIndex = int.Parse(Console.ReadLine()) - 1;
                    Client selectedClient = selectedGym.clients[clientIndex];

                    Console.Write("Сума для поповнення: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    selectedClient.AddFunds(amount);
                    break;
                case 9:
                    Console.WriteLine("Оберіть клієнта:");
                    for (int i = 0; i < selectedGym.clients.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                    }
                    clientIndex = int.Parse(Console.ReadLine()) - 1;
                    selectedClient = selectedGym.clients[clientIndex];

                    Console.WriteLine(selectedClient.GetInformation());
                    break;
            }

            break;
        case 3:
            if (gyms.Count == 0)
            {
                Console.WriteLine("Спочатку додайте спортзал.");
                break;
            }

            Console.WriteLine("Оберіть спортзал:");
            for (int i = 0; i < gyms.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {gyms[i].Name}");
            }
            int gymChoice2 = int.Parse(Console.ReadLine()) - 1;
            Gym selectedGym2 = gyms[gymChoice2];

            Console.WriteLine("1 - Додати клієнта\n2 - Вивести список записаних до тренера клієнтів\n3 - Видалити клієнта\n4 - Розрахувати щомісячний дохід\n5 - Вевсти інформацію про тренера\n6 - Вивести особисту інформацію");
            int menuTrainer = int.Parse(Console.ReadLine());
            switch (menuTrainer)
            {
                case 1:
                    Trainer trainer1 = new Trainer();
                    Console.Write("Введіть ім'я тренера: ");
                    trainer1.Name = Console.ReadLine();
                    Console.Write("Введіть вік тренера: ");
                    trainer1.Age = int.Parse(Console.ReadLine());
                    Console.Write("Введіть спеціалізацію тренера: ");
                    trainer1.Specialization = Console.ReadLine();
                    Console.Write("Введіть погодинну ставку тренера: ");
                    trainer1.HourlyRate = decimal.Parse(Console.ReadLine());
                    selectedGym2.AddTrainer(trainer1);
                    Console.WriteLine("Тренера додано!");
                    break;
                case 2:
                    break;
            }
            break;
    }
}
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

    