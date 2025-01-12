public class IndexSearch
{
    DataValidation dataValidation = new DataValidation();
    public int ReturnIndex(List<Product> productList, string inputParameter, bool isProductName)
    {
        foreach (Product product in productList)
        {
            if (IsIdOrNamePresent(product, inputParameter, isProductName))
            {
                return productList.IndexOf(product);    
            }
        }
        return -1;
    }
    public bool IsIdOrNamePresent(Product product, string inputParameter, bool isProductName)
    {
        return isProductName ? (product.ProductName == inputParameter) : (product.ProductId == dataValidation.CheckDataIsInt(inputParameter));
    }
}





