using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppStore.Models
{
    public class ProductDetails
    {
        public ProductDetails()
        {

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string Url { get; set; }
    }



}