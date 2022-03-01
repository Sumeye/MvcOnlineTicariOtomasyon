using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillDynamicViewModel
    {
        public IEnumerable<Bills> Bills { get; set; }
        public IEnumerable<ExpenseItems>  ExpenseItems{ get; set; }
    }
}