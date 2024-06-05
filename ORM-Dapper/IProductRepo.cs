using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProdcuts();
        public void CreateProduct(string name, double price, int categoryID,bool onSale, int stockLevel);

        public void UpdateProduct(int productID,string newName);

         public void DeleteProduct(int productID);
    }
}
