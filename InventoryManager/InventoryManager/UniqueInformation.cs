public class UniqueInformation
{
    IndexSearch indexSearch = new IndexSearch();
    //Method to Check whether the given input field is already present in the contact list

    //Method to Prompt the user for Inputs till a unique input is received
    public string DistinctInputs(List<Product> productList, string inputParameter, bool isProductName)
    { 
        while (indexSearch.ReturnIndex(productList, inputParameter, isProductName) != -1)
        {
            Console.WriteLine("The Product Field is Already Present !");
            Console.Write("Give a new Field : ");
            inputParameter = Console.ReadLine();
        }
        //Console.WriteLine("The Product Field has been successfully added.");
        return inputParameter; 
    }
}


