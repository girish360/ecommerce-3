using OZ.DataModel;
using OZ.DomainModel;
using OZ.DomainModel.Cart;
using OZ.DomainModel.Products;
using OZ.ViewModel;
using OZ.WebController.SharedBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Default
{
    public class CartController : FrontendControllerBase
    {
        ProductDomainModel productDomain = new ProductDomainModel();
        public ViewResult Index(CartDomainModel cart, string returnUrl)
        {
            return View(new CartIndexViewModel {
                Cart=cart,
                ReturnUrl = returnUrl
            });
        }
        //public CartDomainModel GetCart()
        //{
        //    CartDomainModel cart = (CartDomainModel)Session["cart"];

        //    if(cart ==null)
        //    {
        //        cart = new CartDomainModel();
        //        Session["cart"] = cart;
        //    }
        //    return cart;
        //}
        public RedirectToRouteResult AddToCart(CartDomainModel cart, string productId, int quantity, string returnUrl)
        {
            Product p = productDomain.GetById(productId);
            cart.AddCartLine(p, quantity);

            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(CartDomainModel cart, string productId, string returnUrl)
        {
            cart.RemoveCartLine(
                 new DataModel.Product
                 {
                     ID = new Guid(productId)
                 }
             );
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Checkout(CartDomainModel cart, Order order)
        {
            if(cart.GetCartLines.Count()==0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                OrderDomainModel od = new OrderDomainModel();
                order.ID = Guid.NewGuid();
                order.Status = 0;
                order.CreateDatetime = DateTime.Now.ToUniversalTime();
                order.UpdateDatetime = DateTime.Now.ToUniversalTime();
                order.OrderItems = new List<OrderItem>();

                IEnumerable<CartLine> cartLines = cart.GetCartLines;

                foreach(CartLine ca in cartLines)
                {
                    OrderItem oi = new OrderItem();
                    oi.ID = Guid.NewGuid();
                    //oi.OrderID = order.ID;
                    oi.ProductID = ca.Product.ID;
                    oi.Price = ca.Product.Price;
                    oi.Quantity = ca.Quantity;
                    oi.Status = 0;
                    oi.CreateDatetime = DateTime.Now.ToUniversalTime();
                    oi.UpdateDatetime = DateTime.Now.ToUniversalTime();
                    order.OrderItems.Add(oi);
                }

                od.SaveOrder(order);
                cart.Clear();
                return View("Completed");
            } else
            {
                return View(order);
            }


            return View();
        }
    }
}
