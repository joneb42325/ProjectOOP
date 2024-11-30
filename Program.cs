using ProjectOOP;

Console.OutputEncoding = System.Text.Encoding.UTF8;
List<Gym> gyms = new List<Gym>();
bool working = true; bool clientworking = true; bool trainerworking = true;
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
            clientworking = true;
            while (clientworking)
            {
                Console.WriteLine("1 - Додати клієнта\n2 - Покласти гроші на карту клієнта\n3 - Оновити контактний номер\n4 - Купити абономент\n5 - Подовжити абонемент\n6 - Записатися до тренера\n7 - Відмовитися від тренера\n8 - Перевірити чи дійсний абонемент\n9 - Вивести інформацію про клієнта\n10 - Вивести інформацію про абонемент\n11 - Вивести особисту інформацію клієнта\n12 - Вийти");
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
                        Console.Write("Введіть баланс клієнта: ");
                        client1.Balance = decimal.Parse(Console.ReadLine());
                        selectedGym.AddClient(client1);
                        Console.WriteLine("Клієнта додано!");
                        break;
                    case 2:
                        if (selectedGym.clients.Count == 0 ) { Console.WriteLine("Пока немає клієнтів"); break; }
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
                    case 3:

                        break;
                    case 4:
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        Subscription subscription1 = new Subscription();

                        selectedClient.PurchaseSubscription(subscription1);
                        break;
                    case 5:
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        selectedClient.ExtendSubscription();
                        break;

                    case 6: // Запис до тренера
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        Console.WriteLine("Оберіть тренера:");
                        for (int i = 0; i < gyms.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                        }
                        int trainerIndex = int.Parse(Console.ReadLine()) - 1;
                        Trainer selectedTrainer = selectedGym.trainers[trainerIndex];

                        selectedClient.AssignTrainer(selectedTrainer, selectedClient);
                        Console.WriteLine($"Клієнта {selectedClient.Name} записано до тренера {selectedTrainer.Name}.");
                        break;

                    case 7: // Відмова від тренера
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < gyms.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        if (selectedClient.PersonalTrainer != null)
                        {
                            selectedTrainer = selectedClient.PersonalTrainer;
                            selectedClient.RemoveTrainer(selectedTrainer, selectedClient);
                            Console.WriteLine($"Клієнт {selectedClient.Name} більше не має тренера {selectedTrainer.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Клієнт не має тренера.");
                        }
                        break;

                    case 8:
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];
                        if (selectedClient.CurrentSubscription == null)
                        {
                            Console.WriteLine("У клієнта ще немає абонемента");
                            break;
                        }
                        if (selectedClient.CurrentSubscription.IsActive())
                            Console.WriteLine("Абонемент активний");
                        else Console.WriteLine("Абонемент просрочений");

                        break;
                    case 9:
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        selectedClient.GetInformation();
                        break;
                    case 10: // Вивести інформацію про абонемент
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < gyms.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];

                        if (selectedClient.CurrentSubscription != null)
                        {
                            selectedClient.CurrentSubscription.GetDetails();
                        }
                        else
                        {
                            Console.WriteLine("У клієнта немає активного абонемента.");
                        }
                        break;
                    case 11:
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.clients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                        }
                        clientIndex = int.Parse(Console.ReadLine()) - 1;
                        selectedClient = selectedGym.clients[clientIndex];
                        selectedClient.GetInfo();
                        break;
                    case 12:
                        clientworking = false;
                        break;
                    default:
                        Console.WriteLine("Невідомий пункт меню");
                        break;

                }
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
            selectedGym = gyms[gymChoice2];
            trainerworking = true;
            while (trainerworking)
            {
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
                        selectedGym.AddTrainer(trainer1);
                        Console.WriteLine("Тренера додано!");
                        break;
                    case 2:
                        break;
                    case 5:

                        break;
                    case 6:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        Console.WriteLine("Оберіть клієнта:");
                        for (int i = 0; i < selectedGym.trainers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                        }
                        int trainerIndex = int.Parse(Console.ReadLine()) - 1;
                        Trainer selectedTrainer = selectedGym.trainers[trainerIndex];
                        selectedTrainer.GetInfo();
                        break;
                    case 7:
                        trainerworking = false;
                        break;
                    default:
                        Console.WriteLine("Невідомий пункт меню");
                        break;
                }
                }
              break;
             default:
            Console.WriteLine("Невідомий пункт меню");
                break;
    }
    
}


    