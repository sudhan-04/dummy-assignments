
using ExpenseTracker.Model;
using ExpenseTracker.Utility.LoginCredentialsUtility;


List<LoginCredentials> loginCredentialsList = new List<LoginCredentials>();
LoginCredentialsOperations loginCredentialsOperations = new LoginCredentialsOperations();
string userChoice = "1";
while (userChoice != "2")
{
    userChoice = loginCredentialsOperations.bootUpInterface(loginCredentialsList);
}
Console.ReadKey();