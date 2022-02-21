using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    /// <summary>
    /// Fatura Kalemleri
    /// </summary>
    public class ExpenseItems
    {
        /// <summary>
        /// Fatura kalem ID
        /// </summary>
        [Key]
        public int ExpenseItemId { get; set; }

        /// <summary>
        /// Açıklama
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// Miktar
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Birim Fiyat
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Tutar
        /// </summary>
        public decimal Amount { get; set; }

        //FaturaID
        public int BillID { get; set; }
        //Bir fatura kaleminin sadece bir faturası olabilir
        public virtual Bills Bills { get; set; }
    }
}