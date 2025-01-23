using ExpenseTracker.Model;

namespace ExpenseTracker.ConsoleUI.InputManager
{
    public class DataTypeValidator
    {
        public static int CheckInputAmountFormat(string inputField)
        {
            bool isInputCorrectFormat = int.TryParse(inputField, out int parsedAmount);
            while (!isInputCorrectFormat)
            {
                Console.Write("The Input Amount is Invalid !!\nType the input amount again : ");
                isInputCorrectFormat = int.TryParse(Console.ReadLine(), out parsedAmount);
            }
            return parsedAmount;
        }

        public static DateOnly CheckInputDateFormat(string inputField)
        {
            bool isInputCorrectFormat = DateOnly.TryParse(inputField, out DateOnly parsedDate);
            while (!isInputCorrectFormat)
            {
                Console.Write("The Input is Invalid !!\nType the input date again : ");
                isInputCorrectFormat = DateOnly.TryParse(Console.ReadLine(), out parsedDate);
            }
            return parsedDate;
        }
    }
}
