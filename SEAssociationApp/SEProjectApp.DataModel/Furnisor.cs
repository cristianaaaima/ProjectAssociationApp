using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataModel
{
    public class Furnisor
    {
        public int FurnisorId { get; set; }

        public string? FurnisorName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
    }
}
