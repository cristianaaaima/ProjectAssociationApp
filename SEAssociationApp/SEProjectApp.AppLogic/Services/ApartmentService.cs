using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataAccess;
using SEProjectApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.AppLogic.Services
{
    public class ApartmentService : BaseService
    {
        //private AssociationContext associationContext;
        public ApartmentService(IRepositoryWrapper repositoryWrapper)
            : base (repositoryWrapper)
        {
        }

        public List<Apartment> GetAllApartments()
        {
            return repositoryWrapper.ApartmentRepository.FindAll().ToList();
        }

        public List<Apartment> GetApartmentByCondition(Expression<Func<Apartment, bool>> expression)
        {
            return repositoryWrapper.ApartmentRepository.FindByCondition(expression).ToList();
        }

        public void AddApartment(Apartment apartment)
        {
            repositoryWrapper.ApartmentRepository.Create(apartment);
        }

        public void UpdateApartment(Apartment apartment)
        {
            repositoryWrapper.ApartmentRepository.Update(apartment);
        }

        public void DeleteApartment(Apartment apartment)
        {
            repositoryWrapper.ApartmentRepository.Delete(apartment);
        }

        public int GetNoInvoicesWithPriceLowerThan(int price1, Apartment a)
        {
            int cnt = 0;
            foreach (var invoice in a.Invoices)
            {
                var price = invoice.Price;
                if (price < price1)
                {
                    cnt++;
                }
            }

            return cnt;
        }

        public int GetNoApartmentsWhereUserName(string name, List<Apartment> aps)
        {
            int cnt = 0;
            foreach (var a in aps)
            {
                if (a.UserName.Equals(name))
                    cnt++;
            }
            return cnt;
        }

        public int GetNoApartmentsWhereBuildingId(int id, List<Apartment> aps)
        {
            int cnt = 0;
            foreach (var a in aps)
            {
                if (a.BuildingId == id)
                    cnt++;
            }
            return cnt;
        }

        public int GetNoApartmentsWhereBuildingIdAndUserName(int id, string username, List<Apartment> aps)
        {
            int cnt = 0;
            foreach (var a in aps)
            {
                if (a.BuildingId == id && a.UserName.Equals(username))
                    cnt++;
            }
            return cnt;
        }

        public int GetNoApartmentsWhereApartmentNoAndApartmentId(int id, int apNo, List<Apartment> aps)
        {
            int cnt = 0;
            foreach (var a in aps)
            {
                if (a.ApartmentNo == apNo && a.ApartmentId == id)
                    cnt++;
            }
            return cnt;
        }
    }
}
