using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Dues
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public DateTime  DuesTime{ get; set; }
        public DateTime? GivenDate { get; set; }
    }
}
