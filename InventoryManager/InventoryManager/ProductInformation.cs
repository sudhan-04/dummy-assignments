public class ProductInformation
{
    IndexSearch indexSearch = new IndexSearch();
    public void PrintProductInformation (List<Product> productList, string viewProduct, bool isProductName)
    {
        Console.WriteLine($"Product Name : {productList[indexSearch.ReturnIndex(productList, viewProduct, isProductName)].ProductName}");
        Console.WriteLine($"Product ID : {productList[indexSearch.ReturnIndex(productList, viewProduct, isProductName)].ProductId}");
        Console.WriteLine($"Product Quantity : {productList[indexSearch.ReturnIndex(productList, viewProduct, isProductName)].ProductQuantity}");
        Console.WriteLine($"Product Price : {productList[indexSearch.ReturnIndex(productList, viewProduct, isProductName)].ProductPrice}");
    }
}
