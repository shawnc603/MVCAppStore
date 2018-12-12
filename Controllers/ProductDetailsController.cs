using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVCAppStore.Models;

namespace MVCAppStore.Controllers
{
    public class ProductDetailsController : Controller
    {
        DataTable dt;
        DataAccess.DataAccess _accessobj = new DataAccess.DataAccess();


        public ActionResult Index()
        {

            return View();

        }

        public ActionResult DisplayProductDetails()
        {
            string cmd = "select * from ProductDetails";
            dt = new DataTable();

            dt = _accessobj.GetProducts(cmd);


            List<ProductDetails> list = new List<ProductDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductDetails pdetails = new ProductDetails();
                pdetails.ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                pdetails.ProductName = dt.Rows[i]["ProductName"].ToString();
                pdetails.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                pdetails.ProductDescription = dt.Rows[i]["ProductDescription"].ToString();
                pdetails.Url = dt.Rows[i]["Url"].ToString();
                list.Add(pdetails);
            }
            return View(list);

        }

    }
}
