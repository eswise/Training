using System.Collections.Generic;
using System.Web;

namespace RefactoringToInterfaces
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public IList<Product> GetProductList()
        {
            const string storageKey = "ALL_PRODUCTS";

            IList<Product> products = (List<Product>) HttpContext.Current.Cache.Get(storageKey);

            if (products == null)
            {
                products = _productRepository.GetAllProducts();
                HttpContext.Current.Cache.Insert(storageKey, products);
            }

            return products;
        }
    }
}
