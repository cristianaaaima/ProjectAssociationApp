using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataModel
{
    public  class Apartment
    {
        public int ApartmentId { get; set; }

        public int? ApartmentNo { get; set; }

        public Guid? UserId { get; set; }

        public string? UserName { get; set; }

        public int? BuildingId { get; set; }

        public string? BuildingNo { get; set; }

        public Building? Building { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
    }
}
