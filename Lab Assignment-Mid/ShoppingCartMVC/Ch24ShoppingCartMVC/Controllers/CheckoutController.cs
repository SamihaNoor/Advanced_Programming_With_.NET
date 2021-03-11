using Ch24ShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        private CartModel cart = new CartModel();

        [HttpGet]
        public ActionResult Index()
        {
            CartViewModel model = (CartViewModel)TempData["cart"];
            if (model == null)
            {
                model = cart.GetCart();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel order)
        {
            CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
            model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
            cart.AddToCart(model);
            TempData["cart"] = model;
            return View(model);
        }

        [HttpGet]

        public ActionResult Checkout()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Submit()
        {
            Session.Clear();
            return RedirectToAction("Checkout", "Checkout");
        }

    }
}
