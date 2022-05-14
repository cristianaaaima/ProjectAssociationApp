using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.AppLogic.Services
{
    public class InvoiceService : BaseService
    {
        public InvoiceService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Invoice> GetInvoice()
        {
            return repositoryWrapper.InvoiceRepository.FindAll().ToList();
        }

        public List<Invoice> GetInvoiceByCondition(Expression<Func<Invoice, bool>> expression)
        {
            return repositoryWrapper.InvoiceRepository.FindByCondition(expression).ToList();
        }

        public void AddInvoice(Invoice invoice)
        {
            repositoryWrapper.InvoiceRepository.Create(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            repositoryWrapper.InvoiceRepository.Update(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            repositoryWrapper.InvoiceRepository.Delete(invoice);
        }
    }
}
