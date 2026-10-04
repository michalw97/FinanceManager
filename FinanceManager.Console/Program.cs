bool financeManagerActive = true;
List<(int id, DateTime date, TransactionType transactionType, decimal amount)> transactions = [];

int transactionId = 0;

while (financeManagerActive)
{
    Console.WriteLine("========== MENU ==========");
    Console.WriteLine("1. Dodaj Nową Transakcję.");
    Console.WriteLine("2. Usuń Transakcję.");
    Console.WriteLine("3. Edytuj Transakcję.");
    Console.WriteLine("4. Wyświetl Wszystkie Transakcje.");
    Console.WriteLine("5. Zakończ Program.\n");
    
    Console.Write("Wybierz opcję do wyboru: ");
    var isValidInput = int.TryParse(Console.ReadLine(), out int userChoice);

    switch (userChoice)
    {
        case 0:
            
            switch (isValidInput)
            {
                case true:
                    Console.WriteLine("Nie ma takiej opcji. Spróbuj ponownie!\n");
                    break;
                case false:
                    Console.WriteLine("Opcja musi być liczbą!\n");
                    break;
            }
            break;
        
        case 1:
            
            TransactionType transactionType;
            decimal userValidAmount;
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Wpłata.");
                Console.WriteLine("2. Wypłata.\n");
                Console.Write("Wybierz typ transakcji: ");
                int.TryParse(Console.ReadLine(), out int userChoiceTransType);
                
                if (userChoiceTransType == 1)
                {
                    transactionType = TransactionType.Deposit;
                    break;
                } 
                else if (userChoiceTransType == 2)
                {
                    transactionType = TransactionType.Withdrawal;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna opcja!");
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.Write("Podaj kwotę którą chcesz zdeponować/wypłacić: ");
                var isValidAmount = decimal.TryParse(Console.ReadLine(), out userValidAmount);

                if (isValidAmount)
                {
                    if (userValidAmount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Podana kwota jest błędna.");
                    }
                }
                else
                {
                    Console.WriteLine("Musisz wprowadzić liczbę!");
                }
            }

            if (transactionType == TransactionType.Withdrawal)
            {
                userValidAmount = userValidAmount * -1;
            }

            transactionId += 1;
            DateTime dateValidTransaction = DateTime.Now;

            (int id, DateTime date, TransactionType transactionType, decimal amount) transaction = (transactionId, dateValidTransaction, transactionType, userValidAmount);
            transactions.Add(transaction);
            Console.WriteLine();
            Console.WriteLine("Operacja zakończona sukcesem.");
            
            break;
        case 2:
            Console.WriteLine("Usuń transakcję\n");
            break;
        case 3:
            Console.WriteLine("Edytuj transakcję\n");
            break;
        case 4:
            Console.WriteLine("Wyświetl transakcje\n");
            break;
        case 5:
            Console.WriteLine("Zakończ program!");
            financeManagerActive = false;
            break;
        default:
            Console.WriteLine("Nie można odczytać opcji. Spróbuj ponownie.\n");
            break;
    }
}

enum TransactionType
{
    Deposit,
    Withdrawal
}