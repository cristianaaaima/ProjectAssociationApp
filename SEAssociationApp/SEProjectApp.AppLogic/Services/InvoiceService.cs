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

        public int GetNoInvoicesWhereStatus(string status, List<Invoice> invoices)
        {
            int cnt = 0;
            foreach (var i in invoices)
            {
                if (i.Status.Equals(status))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public string GetUserNameWhereInvoiceId(int id, List<Invoice> invoices)
        {
            var name = "";
            foreach (var i in invoices)
            {
                if (i.InvoiceId == id)
                {
                    name = i.UserName;
                }
            }
            return name;
        }

        public int GetNoInvoicesWithPriceLowerThan(int price1, List<Invoice> invoices)
        {
            int cnt = 0;
            foreach (var i in invoices)
            {
                if (i.Price < price1)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public int GetNoInvoicesWithApartmentIdAndStatus(int id, string status, List<Invoice> invoices)
        {
            int cnt = 0;
            foreach (var i in invoices)
            {
                if (i.ApartmentId == id && i.Status.Equals(status))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public int GetApartmentIdWhereUserNameIs(string name, List<Invoice> invoices)
        {
            var id = 0;
            foreach (var i in invoices)
            {
                if (i.UserName.Equals(name))
                {
                    id = i.ApartmentId;
                }
            }
            return id;
        }
    }
}
