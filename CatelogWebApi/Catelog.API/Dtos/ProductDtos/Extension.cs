

using Catelog.API.Models;


namespace Catelog.API.Dtos.ProductDtos
{
    public static class Extension
    {
        public static ProductDto AsDtos(this Product product)
        {
            return new ProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice
            };
        }
    }
}
