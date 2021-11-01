using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpensePlace { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpenseTime { get; set; }

    }
}
