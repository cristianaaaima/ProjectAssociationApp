using SEProjectApp.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {


        private AssociationContext _associationContext;
        private IInvoiceRepository _invoiceRepository;
        private IBuildingRepository _buildingRepository;
        private IApartmentRepository _apartmentRepository;

        public IBuildingRepository BuildingRepository
        {
            get
            {
                if (_buildingRepository == null)
                {
                    _buildingRepository = new BuildingRepository(_associationContext);
                }
                return _buildingRepository;
            }
        }

        public IApartmentRepository ApartmentRepository
        {
            get
            {
                if (_apartmentRepository == null)
                {
                    _apartmentRepository = new ApartmentRepository(_associationContext);
                }
                return _apartmentRepository;
            }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(_associationContext);
                }
                return _invoiceRepository;
            }
        }

        public RepositoryWrapper(AssociationContext associationContext)
        {
            _associationContext = associationContext;
        }

        public void Save()
        {
            _associationContext.SaveChanges();
        }

    }
}
