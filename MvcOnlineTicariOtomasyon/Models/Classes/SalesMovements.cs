using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    /// <summary>
    /// SatışHareketleri
    /// </summary>
    public class SalesMovements
    {
        [Key]
        public int SalesID { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// Adet
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Fiyat   
        /// </summary>
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int CurrentId { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Products Products { get; set; }
        public virtual Current Currents { get; set; }
        public virtual Employees Employees { get; set; }
    }
}