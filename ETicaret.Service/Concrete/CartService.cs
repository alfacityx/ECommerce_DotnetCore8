using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Core.Entities;
using ETicaret.Service.Abstract;

namespace ETicaret.Service.Concrete
{
    public class CartService : ICartService
    {
        public List<CartLine> CartLines = new(); //Sepetteki ürünleri cartline da tuttuk.
        public void AddProduct(Product product, int quantity)
        {
            var urun = CartLines.FirstOrDefault(p => p.Product.Id == product.Id);
            if (urun != null)
            {
                urun.Quantity += quantity; //Ürün null değilse ürünün miktarını arttır

            }
            else
            {
                CartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void ClearAll()
        {
            CartLines.Clear();
        }

        public void RemoveProduct(Product product)
        {
            CartLines.RemoveAll(p => p.Product.Id == product.Id);
        }

        public decimal TotalPrice()
        {
            return CartLines.Sum(p => p.Product.Price * p.Quantity);
        }

        public void UpdateProduct(Product product, int quantity)
        {
            var urun = CartLines.FirstOrDefault(p => p.Product.Id == product.Id);
            if (urun != null)
            {
                urun.Quantity = quantity;
            }
            else
            {
                CartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }
    }
}
