using System.Text;
using ExpenseTracker.ConsoleUI.InputManager;
using ExpenseTracker.Model;
using Newtonsoft.Json;
public class TransactionOperations
{
    private List<List<Transaction>> _trackerList = new List<List<Transaction>>();
    List<Transaction> transactions = new List<Transaction>();
    public void TransactionAddition(int userLoginIndex)
    {
        //Transaction transaction = new();
        _trackerList.Add(new List<Transaction>());
        Console.Write("Enter the Transaction Type (Income/Expense ) :  ");
        if (Console.ReadLine().ToUpper() == "INCOME")
        {
            Income income = new Income();
            income.Type = "INCOME";
            Console.Write("Enter the Transaction Amount :  ");
            income.Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
            Console.Write("Enter the Date of Transaction :  ");
            income.DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
            Console.Write("Enter the Source of Income : ");
            income.Source = Console.ReadLine();
            _trackerList[userLoginIndex] = new List<Transaction>();
            _trackerList[userLoginIndex].Add(income);
        }
        else
        {
            Expense expense = new();
            expense.Type = "EXPENSE";
            Console.Write("Enter the Transaction Amount :  ");
            expense.Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
            Console.Write("Enter the Date of Transaction :  ");
            expense.DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
            Console.Write("Enter the Category of expense : ");
            expense.Category = Console.ReadLine();
            _trackerList[userLoginIndex].Add(expense);
        }
        Console.WriteLine("The Transaction Information has been successfully added.\n");
    }

    public void TransactionDeletion(int userLoginIndex)
    {
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);
            }
        }
        Console.Write("Select the transaction index : ");
        string deleteChoiceIndex = Console.ReadLine();
        numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                if (numberOfMatchingChoices == int.Parse(deleteChoiceIndex))
                {
                    _trackerList[userLoginIndex].Remove(transaction);
                }
            }
        }
    }


    public void TransactionModification(int userLoginIndex)
    {
        int transactionIndex = SelectTransaction(userLoginIndex);
        Console.WriteLine("[1] Transaction Type\n[2] Transaction Amount\n[3] Transaction Date\n[4] Transaction Details");
        Console.Write("Select the field to edit :");
        string fieldToEdit = Console.ReadLine();
        switch (fieldToEdit)
        {
            case "1":
                Console.Write("Enter the new transaction type :");
                _trackerList[userLoginIndex][transactionIndex].Type = Console.ReadLine().ToUpper();
                break;
            case "2":
                Console.Write("Enter the new transaction amount :");
                _trackerList[userLoginIndex][transactionIndex].Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
                break;
            case "3":
                Console.Write("Enter the new transaction date :");
                _trackerList[userLoginIndex][transactionIndex].DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
                break;
            case "4":
                if (_trackerList[userLoginIndex][transactionIndex] is Income income)
                {
                    Console.Write("Enter the new income source :");
                    income.Source = Console.ReadLine();
                }
                else if (_trackerList[userLoginIndex][transactionIndex] is Expense expense)
                {
                    Console.Write("Enter the new expense category :");
                    expense.Category = Console.ReadLine();
                }
                break;
        }
    }

    public void TransactionSearch(int userLoginIndex)
    {
        int matchedIndex = 0;
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);
            }
        }
    }

    //public void TransactionSummary(int userLoginIndex)
    //{
    //    CalculateTotalTransactionAmount(_trackerList[userLoginIndex]);
    //} 

    public void PrintTransactionInformation(Transaction transaction)
    {
        Console.WriteLine("Transaction Type    : " + transaction.Type);
        Console.WriteLine("Transaction Amount  : " + transaction.Amount);
        Console.WriteLine("Transaction Date    : " + transaction.DateOfTransaction);
        if (transaction.Type == "INCOME")
        {
            Income income = (Income)transaction;
            Console.WriteLine("Transaction Source  : " + income.Source);
        }
        else
        {
            Expense expense = (Expense)transaction;
            Console.WriteLine("Transaction Source  : " + expense.Category);
        }
    }

    public int SelectTransaction(int userLoginIndex)
    {
        int matchedIndex = 0;
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);
            }
        }
        Console.Write("Select the transaction index : ");
        int deleteChoiceIndex = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
        numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                if (numberOfMatchingChoices == deleteChoiceIndex)
                {
                    matchedIndex = _trackerList[userLoginIndex].IndexOf(transaction);
                }
            }
        }
        return matchedIndex;
    }

    public void FileHandling()
    {
        string filePath = "Transaction2.txt";
        string filePath2 = "Transaction33.txt";
        StringBuilder sb = new StringBuilder();
        foreach (List<Transaction> transactionList in _trackerList)
        {
            foreach (Transaction transaction in transactionList)
            {
                if (transaction is Income income)
                {
                    sb.AppendLine($"{transaction.Type},{transaction.DateOfTransaction},{transaction.Amount},{income.Source}");
                }
                else if (transaction is Expense expense)
                {
                    sb.AppendLine($"{transaction.Type},{transaction.DateOfTransaction},{transaction.Amount},{expense.Category}");
                }
            }
            sb.AppendLine();
        }
        File.AppendAllText(filePath, sb.ToString());
    }
    public void SaveTransactionsToFile(string filePath)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        string json = JsonConvert.SerializeObject(_trackerList, settings);
        File.WriteAllText(filePath, json);
    }

    public void LoadTransactionsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            _trackerList = JsonConvert.DeserializeObject<List<List<Transaction>>>(json, settings);
        }
    }

}