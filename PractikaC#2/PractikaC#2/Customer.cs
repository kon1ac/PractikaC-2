using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikaC_2
{
    public partial class Laba1DataSet
    {
        public partial class CustomersRow
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string ContactName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
        }
    }
}
