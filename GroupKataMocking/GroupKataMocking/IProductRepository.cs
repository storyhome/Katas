using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupKataMocking
{
    public interface IProductRepository
    {

        void Save(Product product);

        List<Product> Find();
    }
}
