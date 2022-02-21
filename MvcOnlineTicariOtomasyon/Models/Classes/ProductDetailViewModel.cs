using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetailViewModel
    {
        public IEnumerable<Products> products { get; set; }
        public IEnumerable<ProductDetail> productDetails { get; set; }

    }
}