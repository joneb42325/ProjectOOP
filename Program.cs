using ProjectOOP;
using System;
using System.Xml.Linq;
using static ProjectOOP.Client;

Console.OutputEncoding = System.Text.Encoding.UTF8;
List<Gym> gyms = new List<Gym>();
bool working = true; bool clientworking = true; bool trainerworking = true;
bool problem = false; int menu = 1; int gymChoice = 0; int clientIndex = 0; int trainerIndex = 0;
int menuTrainer = 0;
while (working)
{
    
    do
    {
        try
        {
            problem = false;
            Console.WriteLine("Menu\n1 - Додати спортзал\n2 - Дії з клієнтом \n3 - Дії з тренером\n4 - Вийти з програми");
            menu = int.Parse(Console.ReadLine());
        }
        catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

    } while (problem);
    switch (menu)
    {
        case 1:
            Gym gym = new Gym();
            do
            {
                try
                {
                    problem = false;
                    Console.Write("Input name of gym-->");
                    gym.Name = Console.ReadLine();
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                
            } while (problem);
            do
            {
                try
                {
                    problem = false;
                    Console.Write("Input adress of gym-->");
                    gym.Adress = Console.ReadLine();
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
            } while (problem);
            
            gyms.Add(gym);
            Console.WriteLine("Gym added!");
            break;

        case 2:
            if (gyms.Count == 0)
            {
                Console.WriteLine("Спочатку додайте спортзал.");
                break;
            }


            Gym selectedGym = gyms[0];
            do
            {
                try
                {
                    problem = false;
                    Console.WriteLine("Оберіть спортзал:");
                    for (int i = 0; i < gyms.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {gyms[i].Name}");
                    }
                    gymChoice = int.Parse(Console.ReadLine()) - 1;
                    selectedGym = gyms[gymChoice];
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
            } while (problem);
            
            clientworking = true;
            while (clientworking)
            {
                Console.WriteLine("1 - Додати клієнта\n2 - Покласти гроші на карту клієнта\n3 - Оновити контактний номер\n4 - Купити абономент\n5 - Подовжити абонемент\n6 - Записатися до тренера\n7 - Відмовитися від тренера\n8 - Перевірити чи дійсний абонемент\n9 - Вивести інформацію про клієнта\n10 - Вивести інформацію про абонемент\n11 - Вивести особисту інформацію клієнта\n12 - Вийти");
                int menuClient = int.Parse(Console.ReadLine());
                switch (menuClient)
                {
                    case 1:
                        Client client = new Client();
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть ім'я клієнта: ");
                                client.Name = Console.ReadLine();
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть вік клієнта: ");
                                client.Age = int.Parse(Console.ReadLine());
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
  
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть номер телефону клієнта (+380...): ");
                                client.PhoneNumber = Console.ReadLine();
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                        
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть баланс клієнта '$': ");
                                client.Balance = decimal.Parse(Console.ReadLine());
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                        selectedGym.AddClient(client);
                        Console.WriteLine("Клієнта додано!");
                        break;
                    case 2:
                        if (selectedGym.clients.Count == 0 ) { Console.WriteLine("Пока немає клієнтів"); break; }

                        Client selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        selectedClient.ClientMoneyChanged += amount =>
                        {
                            Console.WriteLine($"Подія: Баланс клієнта збільшено на {amount}$.");
                        };
                        try
                        {
                            do
                            {
                                problem = false;
                                Console.Write("Сума для поповнення: ");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                selectedClient.AddFunds(amount);
                            } while (problem);
                        }
                        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message ); problem = true; }
                      // ClientMoneyChanged += selectedClient.AddFunds(amount);
                        break;
                    case 3:

                        if (selectedGym.clients.Count == 0)
                        {
                            Console.WriteLine("Поки немає клієнтів");
                            break;
                        }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);
                        do
                        {
                            try
                            {

                                problem = false;
                                Console.Write("Введіть новий номер телефону: ");
                                string newClientPhoneNumber = Console.ReadLine();

                                selectedClient.UpdateContactInfo(newClientPhoneNumber);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}"); problem = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}"); problem = true;
                            }

                        } while (problem);
                        break;
                    case 4: // Купити абонемент
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        Subscription subscription = new Subscription();

                        selectedClient.PurchaseSubscription(subscription);
                        break;
                    case 5: //Подовжити абонемент
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        selectedClient.ExtendSubscription();
                        break;

                    case 6: // Запис до тренера
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }

                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        if (selectedClient.CurrentSubscription == null || !selectedClient.CurrentSubscription.IsActive())
                        {
                            Console.WriteLine("У вас немає дійсного абонементу");
                            break;
                        }
                        Trainer selectedTrainer = selectedGym.trainers[0];  
                        do
                        {
                            try
                            {
                                problem = false;
                            
                            Console.WriteLine("Оберіть тренера:");
                            for (int i = 0; i < gyms.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                            }
                            trainerIndex = int.Parse(Console.ReadLine()) - 1;
                            selectedTrainer = selectedGym.trainers[trainerIndex];
                        }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        selectedTrainer.CanTakeClient = client => Trainer.AssignedClients.Count < 10;

                        if (selectedTrainer.AddClientIfEligible(selectedClient))
                        {
                            selectedClient.TrainerChanged += (selectedTrainer, selectedClient) =>
                        {
                            Console.WriteLine($"Подія: Клієнта {selectedClient.Name} записано до тренера {selectedTrainer.Name}.");
                        };
                            selectedClient.AssignTrainer(selectedTrainer, selectedClient);
                        }
                        else
                        {
                            Console.WriteLine($"Тренер {selectedTrainer.Name} не може прийняти більше клієнтів.");
                        }
                       // Console.WriteLine($"Клієнта {selectedClient.Name} записано до тренера {selectedTrainer.Name}.");
                        break;

                    case 7: // Відмова від тренера
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        if (selectedClient.CurrentSubscription == null || !selectedClient.CurrentSubscription.IsActive())
                        {
                            Console.WriteLine("У вас немає дійсного абонементу");
                            break;
                        }
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

                    case 8: // Перевірити чи активний абонемент
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        if (selectedClient.CurrentSubscription == null)
                        {
                            Console.WriteLine("У клієнта ще немає абонемента");
                            break;
                        }
                        if (selectedClient.CurrentSubscription.IsActive())
                            Console.WriteLine("Абонемент активний");
                        else Console.WriteLine("Абонемент просрочений");

                        break;
                    case 9: // Вивід інформації про клієнта
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        selectedClient.GetInformation();
                        break;
                    case 10: // Вивести інформацію про абонемент
                        Subscription subscription1 = new Subscription();
                        subscription1.GetDetails();
                        break;
                    case 11: //Вивести особисту інформацію клієнта
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedClient = selectedGym.clients[0];
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.WriteLine("Оберіть клієнта:");
                                for (int i = 0; i < selectedGym.clients.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.clients[i].Name}");
                                }
                                clientIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedClient = selectedGym.clients[clientIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

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

            
            selectedGym = gyms[0];
            do
            {
                try
                {
                    problem = false;
                    Console.WriteLine("Оберіть спортзал:");
                    for (int i = 0; i < gyms.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {gyms[i].Name}");
                    }
                    gymChoice = int.Parse(Console.ReadLine()) - 1;
                    selectedGym = gyms[gymChoice];
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
            } while (problem);
            trainerworking = true;
            while (trainerworking)
               
            {
                do
                {
                    try
                    {
                        problem = false;
                        Console.WriteLine("1 - Додати тренера\n2 - Вивести список записаних до тренера клієнтів\n3 - Видалити клієнта\n4 - Розрахувати щомісячний дохід\n5 - Вивести інформацію про тренера\n6 - Вивести особисту інформацію\n7 - Вийти");
                        menuTrainer = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                } while (problem);
                switch (menuTrainer)
                {
                    case 1:
                        Trainer trainer = new Trainer();
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть ім'я тренера: ");
                                trainer.Name = Console.ReadLine();
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть вік тренера: ");
                                trainer.Age = int.Parse(Console.ReadLine());
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);

                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть номер телефону тренера (+380...): ");
                                trainer.PhoneNumber = Console.ReadLine();
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);

                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть спеціалізацію тренера: ");
                                trainer.Specialization = Console.ReadLine();
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                       
                        do
                        {
                            try
                            {
                                problem = false;
                                Console.Write("Введіть погодинну ставку тренера: ");
                                trainer.HourlyRate = decimal.Parse(Console.ReadLine());
                            }
                            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }

                        } while (problem);
                        selectedGym.AddTrainer(trainer);
                        Console.WriteLine("Тренера додано!");
                        break;
                    case 2:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }

                        Trainer selectedTrainer = selectedGym.trainers[0];
                        do
                        {
                            try
                            {
                                problem = false;

                                Console.WriteLine("Оберіть тренера:");
                                for (int i = 0; i < gyms.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                                }
                                trainerIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedTrainer = selectedGym.trainers[trainerIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        if (Trainer.AssignedClients.Count == 0)
                        {
                            Console.WriteLine("У цього тренера поки немає клієнтів");
                            break;
                        }

                        Console.WriteLine($"Список клієнтів тренера {selectedTrainer.Name}:");
                        foreach (var client in Trainer.AssignedClients)
                        {
                            Console.WriteLine($"- {client.Name}");
                        }
                        break;
                    case 3:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        if (selectedGym.clients.Count == 0) { Console.WriteLine("Пока немає клієнтів"); break; }
                        selectedTrainer = selectedGym.trainers[0];
                        do
                        {
                            try
                            {
                                problem = false;

                                Console.WriteLine("Оберіть тренера:");
                                for (int i = 0; i < gyms.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                                }
                                trainerIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedTrainer = selectedGym.trainers[trainerIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        if (Trainer.AssignedClients.Count == 0)
                        {
                            Console.WriteLine("У цього тренера немає клієнтів для видалення");
                            break;
                        }

                        Console.WriteLine("Оберіть клієнта для видалення:");
                        for (int i = 0; i < Trainer.AssignedClients.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Trainer.AssignedClients[i].Name}");
                        }
                        int clientToRemoveIndex = int.Parse(Console.ReadLine()) - 1;
                        Client clientToRemove = Trainer.AssignedClients[clientToRemoveIndex];

                        clientToRemove.RemoveTrainer(selectedTrainer, clientToRemove);
                        Console.WriteLine($"Клієнта {clientToRemove.Name} видалено з тренера {selectedTrainer.Name}");
                        break;

                    case 4:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        selectedTrainer = selectedGym.trainers[0];
                        do
                        {
                            try
                            {
                                problem = false;

                                Console.WriteLine("Оберіть тренера:");
                                for (int i = 0; i < gyms.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                                }
                                trainerIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedTrainer = selectedGym.trainers[trainerIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        Console.Write("Введіть кількість відпрацьованих годин за місяць: ");
                        int hoursWorked = int.Parse(Console.ReadLine());
                        // decimal earnings = selectedTrainer.CalculateMonthlyEarnings(hoursWorked);
                        Func<int, decimal> calculateEarnings = hours => selectedTrainer.HourlyRate * hours;
                        decimal earnings = calculateEarnings(hoursWorked);
                        Console.WriteLine($"Щомісячний дохід тренера {selectedTrainer.Name}: {earnings}$");
                        break;
  
                    case 5:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        selectedTrainer = selectedGym.trainers[0];
                        do
                        {
                            try
                            {
                                problem = false;

                                Console.WriteLine("Оберіть тренера:");
                                for (int i = 0; i < gyms.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                                }
                                trainerIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedTrainer = selectedGym.trainers[trainerIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);

                        selectedTrainer.GetInformation();
                        break;
                    case 6:
                        if (selectedGym.trainers.Count == 0) { Console.WriteLine("Пока немає тренерів"); break; }
                        selectedTrainer = selectedGym.trainers[0];
                        do
                        {
                            try
                            {
                                problem = false;

                                Console.WriteLine("Оберіть тренера:");
                                for (int i = 0; i < gyms.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {selectedGym.trainers[i].Name}");
                                }
                                trainerIndex = int.Parse(Console.ReadLine()) - 1;
                                selectedTrainer = selectedGym.trainers[trainerIndex];
                            }
                            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); problem = true; }
                        } while (problem);
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
        case 4:
            working = false;
            break;
             default:
            Console.WriteLine("Невідомий пункт меню");
                break;
    }
    
}

void SelectedClient_BalanceChanged(string obj)
{
    throw new NotImplementedException();
}

