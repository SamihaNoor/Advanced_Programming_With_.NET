using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Models
{
    public class CartModel
    {
        //Data Access methods 

        ///// Get Cart From Data Store () method

        private List<ProductViewModel> GetCartFromDataStore()
        {
            List<ProductViewModel> cart;
            object objCart = HttpContext.Current.Session["cart"];
            //Convert objCart to List<ProductViewModel>
            //________________________________
            cart = (List<ProductViewModel>)objCart;
            if (cart == null)
            {   //Create the object cart
                //__________________________________
                HttpContext.Current.Session["cart"] = new List<ProductViewModel>();
                //Assign cart to the Session object cart
                //____________________________________________
                cart = (List<ProductViewModel>)HttpContext.Current.Session["cart"];
            }
            return cart;
        }

        ///// Get Selected Product () method


        private ProductViewModel GetSelectedProduct(string id)
        {   //Create an OrderModel object called order
            //_______________________________
            OrderModel order = new OrderModel();
            //Call the method GetSelectedProduct of the class OrderModel. Return the object returned by the call.
            //return _____________________________________
            return order.GetSelectedProduct(id);
        }


        //// Get Cart ()


        public CartViewModel GetCart(string id = "")
        {
            CartViewModel model = new CartViewModel();
            //Call the method GetCartFromDataStore
            //____________________________________
            model.Cart = GetCartFromDataStore();
            if (!string.IsNullOrEmpty(id))
                //Called the method GetSelectedProduct with parameter id and assign the return object to the AddedProduct
                //____________________________________________
                model.AddedProduct = GetSelectedProduct(id);
            return model;
        }


        // Add Item to Data Store () method


        private void AddItemToDataStore(CartViewModel model)
        {   //Add the AddedProduct to the cart
            //__________________________________________
            model.Cart.Add(model.AddedProduct);
        }


        /////add to cart method


        public void AddToCart(CartViewModel model)
        {
            if (model.AddedProduct.ProductID != null)
            {
                //Get the product id of the added product
                //______________________________________________
                string id = model.AddedProduct.ProductID;
                //Find the product in the car that matches the id using lambda expression.
                //__________________________________________
                ProductViewModel inCart = model.Cart.Where(p => p.ProductID == id).FirstOrDefault();
                if (inCart == null)
                    //Call the method AddItemToDataStore
                    //_________________________________________
                    AddItemToDataStore(model);
                else
                    //Increase the Quantity by the quantity of the added product
                    //________________________________________
                    inCart.Quantity += model.AddedProduct.Quantity;
            }
        }
    }
}