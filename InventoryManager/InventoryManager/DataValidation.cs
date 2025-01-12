//Method to Check whether the given string for the Phone number can be formatted to the Phone number format

public class DataValidation
{
    public int CheckDataIsInt(string inputProductField)
    {
        //string printType = isProductId ? "ID" : "Quantity";
        bool isProductFieldInt = int.TryParse(inputProductField, out int parsedField);
        while (!isProductFieldInt)
        {       
            Console.WriteLine($"The Product field is invalid !!\nType the Product field Again : ");
            isProductFieldInt = int.TryParse(Console.ReadLine(), out parsedField);
        }
        return parsedField;
    }

    public decimal CheckProductPrice(string inputProductPrice)
    {
        bool isProductPriceDecimal = decimal.TryParse(inputProductPrice, out decimal parsedPrice);
        while (!isProductPriceDecimal)
        {

            Console.WriteLine("The Product Price is invalid !!\nType the Product Price Again : ");
            isProductPriceDecimal = decimal.TryParse(Console.ReadLine(), out parsedPrice);
        }
        return parsedPrice;
    }

}



