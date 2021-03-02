using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class OrderController : Controller
    {
        private OrderModel order = new OrderModel();

        [HttpGet]
        public ActionResult Index(string id)
        {
            //get list for drop down from temp data called products 
            //SelectList products = (SelectList)T____________________;
            SelectList products = (SelectList)TempData["products"];
            if (products == null)
            {
                //CALL THE METHOD GetProductList 
                //var list = _________________________________
                var list = order.GetProductsList();
                //CREATE THE SelectList products
                //products = new ________________(list, _________________, "Name", id);
                products = new SelectList(list, "ProductId", "Name", id);
            }
            //if no URL parameter, get first product from list and refresh
            if (string.IsNullOrEmpty(id))
            {
                id = products.ElementAt(0).Value;
                //ASSIGN products to temp data called products
                //TempData["products"] = ________________________;
                TempData["products"] = products;
                //Redirect to the action method Index of the Order controller with id parameter.
                //_________________________________________________
                return RedirectToAction("Index", "Order", new { id });       ////(action, controller, object)
            }
            else
            { //get selected product and return in view method
              //Call the method GetOrderInfo to get an OrderViewModel object called model
              //_________________________________________________
                OrderViewModel model = order.GetOrderInfo(id);
                //Assign products to ProductsList property of model
                //_____________________________
                model.ProductsList = products;
                //Assign the quantity of the SelectProduct of the model to 1
                //__________________________________________
                model.SelectedProduct.Quantity = 1;
                //Send the model object to the view.
                //________________________________
                return View(model);
            }
        }
        [HttpPost] //post back - get selected ddl value and refresh
        public RedirectToRouteResult Index(FormCollection collection)
        {
            string pID = collection["ddlProducts"];
            //Redirect to the action method index of the Order controller with parameter the id assigned to pID
            //___________________________________________________
            return RedirectToAction("Index", "Order", new { @id = pID });
        }
    }
}
