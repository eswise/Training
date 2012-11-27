using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringToInterfaces
{
    public class ProductRepository
    {
        public IList<Product> GetAllProducts()
        {
            return new List<Product>();
        }
    }
}
