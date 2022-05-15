using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataModel
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string? UserName { get; set; }

        public int? ApartmentNo { get; set; }

        public int? Price { get; set; }

        public string? Status { get; set; }

        public DateTime DueDate { get; set; }

        public string? Description { get; set; }

        public int? ApartmentId { get; set; }

        public Apartment? Apartment { get; set; }
    }
}
