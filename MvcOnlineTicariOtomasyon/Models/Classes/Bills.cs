using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    /// <summary>
    /// Faturalar
    /// </summary>
    public class Bills
    {
        [Key]
        public int BillID { get; set; }

        /// <summary>
        /// Fatura SeriNo
        /// </summary>
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }

        /// <summary>
        /// Fatura Sıra No
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillRowNumber { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Vergi Dairesi
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }


        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        /// <summary>
        /// Teslim Alan kişi
        /// </summary>
        /// 
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        /// <summary>
        /// Teslim Eden Kişi
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryPerson { get; set; }

        public decimal TotalPrice { get; set; }

        //Bir faturanın birden fazla kalemi olabilir
        public ICollection<ExpenseItems> ExpenseItems { get; set; }
    }
}