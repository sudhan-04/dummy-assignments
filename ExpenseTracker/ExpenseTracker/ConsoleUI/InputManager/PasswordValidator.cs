using ExpenseTracker.Utility.LoginCredentialsUtility;

namespace ExpenseTracker.ConsoleUI.InputManager
{
    public class PasswordValidator
    {
        //LoginCredentialsOperations loginCredentialsOperations = new LoginCredentialsOperations();
        public string CheckPasswordFormat(string password)
        {
            while (!Conditions.ConditionApprover(password))
            {
                Console.Write("The password is invalid !!\nProvide a Valid Password : ");
                password = Console.ReadLine();
            }
            return password;
        }

        public string GetValidLoginPassword(string inputLoginPassword)
        {
            string validPassword = CheckPasswordFormat(inputLoginPassword);
            return validPassword;
        }
        public string GetConfirmedPassword(string inputLoginPassword)
        {
            bool isPasswordConfirmed = false;
            while (!isPasswordConfirmed)
            {
                if (Console.ReadLine() == inputLoginPassword)
                {
                    isPasswordConfirmed = true;
                }
                else
                {
                    Console.WriteLine("The Password doesn't match the initial password !! ");
                }
            }
            return inputLoginPassword;
        }
    }
}