using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using MVCAppStore.Models;

namespace MVCAppStore.Controllers
{
    public class CartController : Controller
    {
        DataTable dt;
        DataAccess.DataAccess _daccess = new DataAccess.DataAccess();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult AddItem(string ProductID)
        {

            ProductDetails pdetails = GetSelectedProduct(ProductID);
            if (Session["cart"] == null)
            {
                List<ProductDetails> list = new List<ProductDetails>();

                list.Add(pdetails);
                Session["cart"] = list;
                ViewBag.cart = list.Count();

                Session["count"] = 1;
            }
            else
            {
                List<ProductDetails> list = (List<ProductDetails>)Session["cart"];
                list.Add(pdetails);
                Session["cart"] = list;
                ViewBag.cart = list.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("MyCart");
        }

        public ActionResult RemoveItem(string ProductID)
        {
            ProductDetails pdetails = GetSelectedProduct(ProductID);
            List<ProductDetails> list = (List<ProductDetails>)Session["cart"];
            list.RemoveAll(x => x.ProductID == pdetails.ProductID);
            Session["cart"] = list;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("MyCart");
        }

        public ActionResult MyCart()
        {
            return View((List<ProductDetails>)Session["cart"]);

        }

        public ProductDetails GetSelectedProduct(string ProductID)
        {
            string cmd = "select * from ProductDetails where ProductID =" + Convert.ToString(ProductID);
            dt = new DataTable();

            dt = _daccess.GetProducts(cmd);
            ProductDetails pdetail = new ProductDetails();
            pdetail.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
            pdetail.ProductName = dt.Rows[0]["ProductName"].ToString();
            pdetail.Price = Convert.ToDouble(dt.Rows[0]["Price"]);
            pdetail.ProductDescription = dt.Rows[0]["ProductDescription"].ToString();
            pdetail.Url = dt.Rows[0]["Url"].ToString();

            return pdetail;
        }

    }
}
