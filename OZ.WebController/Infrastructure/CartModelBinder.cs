using OZ.DomainModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            CartDomainModel cart = null;
            if(controllerContext.HttpContext.Session !=null)
            {
                cart = (CartDomainModel)controllerContext.HttpContext.Session[sessionKey];
            }
            if(cart==null)
            {
                cart = new CartDomainModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}
