using ExpenseTracker.Model;
using ExpenseTracker.Utility.TransactionUtility;
using ExpenseTracker.ConsoleUI.InputManager;

namespace ExpenseTracker.Utility.LoginCredentialsUtility
{
    public class LoginCredentialsOperations
    {
        PasswordValidator passwordValidator = new PasswordValidator();
        private List<LoginCredentials> _loginCredentialsList = new List<LoginCredentials>();
        public string GetNewUserName()
        {
            Console.Write("Create a UserName : ");
            string loginUserName = Console.ReadLine();
            return GetUniqueLoginUserName(loginUserName);
        }

        public string bootUpInterface(List<LoginCredentials> loginCredentialsList)
        {
            Console.WriteLine("HELLO !!\n[1] Enter the application \n[2] Exit the application ");
            string enterChoice = Console.ReadLine();
            if (enterChoice == "1")
            {
                CheckNewUser(loginCredentialsList);
                return "1";
            }
            else
            {
                Console.WriteLine("-----PRESS ANY KEY TO EXIT-----");
                return "2";
            }
        }
        public int CheckNewUser(List<LoginCredentials> loginCredentialsList)
        {
            Console.WriteLine("------WELCOME TO THE EXPENSE TRACKER-------");
            Console.Write("Are you a new user ?\nY/N :");
            string userChoice = Console.ReadLine();
            if (userChoice.ToUpper() == "Y")
            {
                AddLoginCredentials();
                return -1;

            }
            else if (userChoice.ToUpper() == "N")
            {
                return CheckLoginCredentials();
            }
            else
            {
                return -1;
            }
        }
        public string GetNewPassword()
        {
            Console.Write("Create a Password : ");
            string validPassword = passwordValidator.GetValidLoginPassword(Console.ReadLine());
            Console.Write("ReConfirm your Password : ");
            string setPassword = passwordValidator.GetConfirmedPassword(validPassword);
            Console.WriteLine("The password is successfully added !!");
            return setPassword;
        }

        public int GetOldUserName()
        {
            Console.Write("Type the Username : ");
            int inputIndex = ReturnIndex(Console.ReadLine());
            if (inputIndex == -1)
            {
                Console.WriteLine("The Username is not present !!");
                return CheckNewUser(_loginCredentialsList);
            }
            else
            {
                return GetOldPassword(inputIndex);
            }
        }

        public int GetOldPassword(int inputIndex)
        {
            Console.Write("Type the password : ");
            string inputPassword = Console.ReadLine();
            if (inputPassword == _loginCredentialsList[inputIndex].Password)
            {
                List<List<Transaction>> transactionsList = new List<List<Transaction>>();
                Console.WriteLine("You're successfully logged in !! ");
                Console.WriteLine(inputIndex);
                TransactionFeatures.UserTransactionInterface(transactionsList, _loginCredentialsList, inputIndex);
                return inputIndex;
            }
            else
            {
                int passwordAttempt = 0;
                while (passwordAttempt < 2)
                {
                    Console.WriteLine("You've entered the wrong password !! ");
                    Console.Write("Type the password : ");
                    inputPassword = Console.ReadLine();
                    if (inputPassword == _loginCredentialsList[inputIndex].Password)
                    {
                        Console.WriteLine("You're successfully logged in !! ");
                        return inputIndex;
                    }
                    passwordAttempt++;
                }
                Console.WriteLine("Wrong password attempts have exceeded 3 times !!!");
                Console.WriteLine("------------EXITING---------");
                return inputIndex;
            }
        }


        public void AddLoginCredentials()
        {
            string inputUserName = GetNewUserName();
            string inputPassword = GetNewPassword();
            LoginCredentials loginCredentials = new LoginCredentials(inputUserName, inputPassword);
            _loginCredentialsList.Add(loginCredentials);
        }

        public int CheckLoginCredentials()
        {
            return GetOldUserName();
        }

        public string GetUniqueLoginUserName(string inputLoginUserName)
        {
            bool isUniqueUserName = false;
            while (!isUniqueUserName)
            {
                if (ReturnIndex(inputLoginUserName) == -1)
                {
                    isUniqueUserName = true;
                }
                else
                {
                    Console.Write("The Login UserName is already present !!\nProvide a new UserName :");
                    inputLoginUserName = Console.ReadLine();
                }
            }
            return inputLoginUserName;
        }

        public int ReturnIndex(string searchUserName)
        {
            foreach (LoginCredentials loginCredentials in _loginCredentialsList)
            {
                if (searchUserName == loginCredentials.Username)
                {
                    return _loginCredentialsList.IndexOf(loginCredentials);
                }
            }
            return -1;
        }
    }
}
