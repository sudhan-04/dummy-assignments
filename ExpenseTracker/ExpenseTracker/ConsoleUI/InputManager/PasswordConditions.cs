namespace ExpenseTracker.ConsoleUI.InputManager
{
    public class Conditions
    {
        public static bool ConditionApprover(string password)
        {
            bool conditionsSatisfied = false;
            foreach (char character in password)
            {
                if (CheckLowerCase(character))
                {
                    conditionsSatisfied = true;
                    break;
                }
            }
            if (conditionsSatisfied)
            {
                conditionsSatisfied = false;
                foreach (char character in password)
                {
                    if (CheckUpperCase(character))
                    {
                        conditionsSatisfied = true;
                        break;
                    }
                }
            }
            else
            {
                return false;
            }
            if (conditionsSatisfied)
            {
                conditionsSatisfied = false;
                foreach (char character in password)
                {
                    if (CheckNumbers(character))
                    {
                        conditionsSatisfied = true;
                        break;
                    }
                }
            }
            else
            {
                return false;
            }
            if (conditionsSatisfied)
            {
                conditionsSatisfied = false;
                foreach (char character in password)
                {
                    if (CheckSpecialCharacters(character))
                    {
                        conditionsSatisfied = true;
                        break;
                    }
                }
            }
            else
            {
                return false;
            }
            if (conditionsSatisfied)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckLowerCase(char character) => character >= 'a' && character <= 'z';
        public static bool CheckUpperCase(char character) => character >= 'A' && character <= 'Z';
        public static bool CheckNumbers(char character) => character >= '0' && character <= '9';
        public static bool CheckSpecialCharacters(char character) => new char[] { '@', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+' }.Contains(character);
    }
}
