using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.Abstractions.Repository
{
    public  interface IRepositoryWrapper
    {
        IInvoiceRepository InvoiceRepository { get; }
        IBuildingRepository BuildingRepository { get; }
        IApartmentRepository ApartmentRepository { get; }
        void Save();
    }
}
