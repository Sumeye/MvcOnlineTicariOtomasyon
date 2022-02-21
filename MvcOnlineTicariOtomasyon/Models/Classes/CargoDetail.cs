using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }
        /// <summary>
        /// Kargo Takip Kodu
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Hangi personel kargoya verdi
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Employee { get; set; }

        /// <summary>
        ///Kargo  Alıcı
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Consignee { get; set; }
        /// <summary>
        /// Kargoya ne zaman verildi.
        /// </summary>
        public DateTime Date { get; set; }


    }
}