using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Branch { get; set; }
        public short Stock { get; set; }
        /// <summary>
        /// Alış Fiyatı
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// Satış Fiyatı
        /// </summary>
        public decimal SalePrice { get; set; }

        public bool Status { get; set; }
        /// <summary>
        /// ürün görseli
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }

        public int CategoryId { get; set; }

        public virtual Categories Categories { get; set; }
        public ICollection<SalesMovements> Sales_Movements { get; set; }
    }
}