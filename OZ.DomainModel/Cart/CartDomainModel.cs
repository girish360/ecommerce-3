using OZ.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DomainModel.Cart
{
    public class CartDomainModel
    {
        private List<CartLine> cartLines = new List<CartLine>();

        public IEnumerable<CartLine> GetCartLines
        {
            get { return cartLines; }
        }

        public void AddCartLine(Product product, int quantity)
        {
            CartLine line = cartLines
                .Where(p => p.Product.ID == product.ID)
                .FirstOrDefault();
            if(line==null)
            {
                cartLines.Add(new CartLine { Product= product,Quantity = quantity });
            }else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveCartLine(Product product)
        {
            cartLines.RemoveAll(l => l.Product.ID == product.ID);
        }
        public decimal ComputeTotal()
        {
            return cartLines.Sum(s => s.Product.Price*s.Quantity);
        }
        public void Clear()
        {
            cartLines.Clear();
        }

    }
}
