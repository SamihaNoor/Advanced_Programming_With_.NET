using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.DataAccess;

namespace Ch24ShoppingCartMVC.Models
{
    public class OrderModel
    {
        private List<ProductViewModel> products;
        //Implement GetAllProductsFromDataStore
        public List<Product> GetAllProductsFromDataStore()      ///////GetAllProducts() method
        {
            using (HalloweenEntities data = new HalloweenEntities())
            {  //get all the products from the Collection Products order by name using HalloweenEntities
                //_________________________________________
                return data.Products.OrderBy(product => product.Name).ToList();
            }
        }
        //Implement the method ConvertToViewModel
        private ProductViewModel ConvertToViewModel(Product product)
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductID = product.ProductID;
            model.Name = product.Name;
            //implement other required properties
            //___________________________________________
            model.ShortDescription = product.ShortDescription;
            model.LongDescription = product.LongDescription;
            model.UnitPrice = product.UnitPrice;
            model.ImageFile = product.ImageFile;
            
            return model;
        }
        //Implement the method GetProductList
        public List<ProductViewModel> GetProductsList()
        {
            if (this.products == null)
                //Call the method GetAllProducts
                //________________________________
                this.products = GetAllProducts();       ////////GetProductList() method
            //Return the products
            // return ____________________________
            return this.products;
        }
        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> productmodels = new List<ProductViewModel>();
            // Call the GetAllProductsFromDataStore()
            //_________________________________________________
            List<Product> products = GetAllProductsFromDataStore();
            foreach (Product p in products)
            {  //Call the method ConvertToViewModel to convert p and pass the method ConvertToViewModel to the method add of the productmodels
                //_________________________________________
                productmodels.Add(ConvertToViewModel(p));
            }                                               ///////GetAllProducts() method
            return productmodels;
        }

        public Product GetProductByIdFromDataStore(string id)
        {
            using (HalloweenEntities data = new HalloweenEntities())
            {  //Get a product from Products of data where ProductID is matched with id parameter
                // return _________________________________________.FirstOrDefault();
                return data.Products.Where(p => p.ProductID == id).FirstOrDefault();
            }                                                         ////// GetProductById method
        }
        public OrderViewModel GetOrderInfo(string id)
        {
            OrderViewModel order = new OrderViewModel();        ///GetOrderInfo()
            //Call the method GetSelectedProduct and assign the return value to SelectedProduct property
            //_________________________________________________________
            order.SelectedProduct = GetSelectedProduct(id);
            return order;
        }
        public ProductViewModel GetSelectedProduct(string id)
        {
            if (this.products == null)
                //call the method ConvertToViewModel and pass the method GetProductByIdFromDataStore(id)
                //return ______________________________________
                return ConvertToViewModel(GetProductByIdFromDataStore(id));
            else
                //Get the product from the products where ProductID is matched with id (Using Lambda expression)
                // return ______________________________________________
                return products.Where(p => p.ProductID == id).FirstOrDefault();
        }
    }
}