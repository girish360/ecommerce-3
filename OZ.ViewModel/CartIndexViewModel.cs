using OZ.DomainModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.ViewModel
{
    public class CartIndexViewModel
    {
        public CartDomainModel Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
