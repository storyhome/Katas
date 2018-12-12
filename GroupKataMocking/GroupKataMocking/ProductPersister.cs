using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupKataMocking
{
    public class ProductPersister
    {
        private IProductRepository _productRepository;

        public ProductPersister(IProductRepository productRepository)
        {
            _productRepository = productRepository;
                    
        }

        public void Save(Product product)
        {
            if (product.ExpirationDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Invalid Expiration Date.");
            }

            _productRepository.Save(product);
        }

        public List<Product> Find()
        {
            return _productRepository.Find();
        }


        public Product FindByName(string productName)
        {
            return new Product();
        }
    }
}
