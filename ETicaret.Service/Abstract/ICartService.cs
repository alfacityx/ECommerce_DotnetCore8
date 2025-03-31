using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Core.Entities;

namespace ETicaret.Service.Abstract
{
    public interface ICartService
    {
        void AddProduct(Product product,int quantity);
        void UpdateProduct(Product product, int quantity);
        void RemoveProduct(Product product);
        decimal TotalPrice();
        void ClearAll();
    }
}
