using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        /// <summary>
        /// Gönderici
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        /// <summary>
        /// Alıcı
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Recipient { get; set; }
        /// <summary>
        /// Konu
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }
        /// <summary>
        /// İçerik
        /// </summary>
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }


        public ICollection<Products> Products { get; set; }
    }
}