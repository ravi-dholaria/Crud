using Crud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Data
{
    internal interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
