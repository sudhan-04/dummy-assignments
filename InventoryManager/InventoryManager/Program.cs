using System.Xml.Linq;

List<Product> productList = new List<Product>();

//Prompt the User for a choice
Console.WriteLine("Hello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[D]elete the Product\n[E]xit the Product List\n");
Console.Write("Type your Choice: ");
string userChoice = Console.ReadLine();
DataValidation dataValidation = new DataValidation();
IndexSearch indexSearch = new IndexSearch();
UniqueInformation uniqueInformation = new UniqueInformation();
ProductInformation productInformation = new ProductInformation();
//Looping Continuously till the User wishes to exit
do
{
    switch (userChoice)
    {
        //Add New Contact Information
        case "A":
        case "a":
            Console.Write("Enter the Product Name :  ");
            string productName = uniqueInformation.DistinctInputs(productList, Console.ReadLine(), true);
            Console.Write("Enter the Product Price :  ");
            decimal productPrice = dataValidation.CheckProductPrice(Console.ReadLine());
            Console.Write("Enter the Product ID :  ");
            int productId = int.Parse(uniqueInformation.DistinctInputs(productList, Console.ReadLine(), false));      
            Console.Write("Enter the Product Quantity  ");
            int productQuantity = dataValidation.CheckDataIsInt(Console.ReadLine());
            Product product = new Product(productId, productName, productPrice, productQuantity);
            productList.Add(product);
            Console.WriteLine("The Product Information has been successfully added.\n");
            break;
        //Search for Specific Contact Information
        case "S":
        case "s":
            if (productList.Count > 0)
            {
                Console.Write("Search for the Product Name : ");
                string productHint = Console.ReadLine();
                bool isSearchPresent = false;
                foreach (Product searchproduct in productList)
                {
                    if (searchproduct.ProductName.Contains(productHint))
                    {
                        Console.WriteLine($"{searchproduct.ProductName} - Product ID : {searchproduct.ProductId}\n");
                        isSearchPresent = true;
                    }
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
                else
                {
                    Console.Write("Do you want to view the Contact Information of any specific Contact ?\nY/N : ");
                    string viewChoice = Console.ReadLine();
                    if (viewChoice == "Y" || viewChoice == "y")
                    {
                        Console.Write("Search by [N]ame / [I]d : ");
                        string searchField = (Console.ReadLine() == "N" || Console.ReadLine() == "n") ? "Name" : "ID";
                        Console.Write($"Kindly provide the {searchField} of the Product that must be viewed : ");
                        productInformation.PrintProductInformation(productList, Console.ReadLine(), true);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Contact Information has been added yet");
            }
            break;
        //Delete the Specific User Information
        case "d":
        case "D":
            Console.Write("Enter the Name of the Contact that must be deleted :  ");
            string deleteChoice = Console.ReadLine();
            Console.WriteLine($"The Contact Information of {deleteChoice} has been deleted successfully.");
            productList.RemoveAt(indexSearch.ReturnIndex(productList, deleteChoice, true));
            break;
        //Modify the Contact Information
        case "m":
        case "M":
            Console.WriteLine("Enter the Name of the Product that must be edited :  ");
            string editChoice = Console.ReadLine();
            Console.WriteLine("Choose the Information that must be edited : \n [N]ame of the Product \n [I]D of the Product \n [P]rice of the Product \n [Q]uantity of the product \n [A]ll");
            Console.Write("Type your Choice: ");
            string editField = Console.ReadLine();
            switch (editField)
            {
                case "N":
                case "n":
                    Console.WriteLine("Enter the Edited Product Name : ");
                    productList[indexSearch.ReturnIndex(productList, editChoice,true)].ProductName = Console.ReadLine();
                    break;
                case "I":
                case "i":
                    Console.WriteLine("Enter the Edited Product ID : ");
                    productList[indexSearch.ReturnIndex(productList, editChoice,true)].ProductId = dataValidation.CheckDataIsInt(Console.ReadLine());
                    break;
                case "P":
                case "p":
                    Console.WriteLine("Enter the Edited Product Price : ");
                    productList[indexSearch.ReturnIndex(productList, editChoice,true)].ProductPrice = dataValidation.CheckProductPrice(Console.ReadLine());
                    break;
                case "Q":
                case "q":
                    Console.WriteLine("Enter the Edited Product Quantity : ");
                    productList[indexSearch.ReturnIndex(productList, editChoice,true)].ProductQuantity = dataValidation.CheckDataIsInt(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid Choice !!");
                    break;
            }
            break;
        //View all the Contact Names in the Contact List
        case "v":
        case "V":
            if (productList.Count > 0)
            {
                Console.WriteLine("All the Product Names in the Contact List are : ");
                for (int i = 1; i <= productList.Count; i++)
                {
                    Console.WriteLine($"{i}.{productList[i - 1].ProductName}");
                }
            }
            else
            {
                Console.WriteLine("The Product List is Empty.");
            }
            break;
        default:
            Console.WriteLine("Invalid Choice !!");
            break;
    }
    Console.WriteLine("Hello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[D]elete the Product\n[E]xit the Product List\n");
    Console.Write("Type your Choice: ");
    userChoice = Console.ReadLine();
} while (userChoice != "e" && userChoice != "E"); // Exit the Application if the User gives the input as "E"
