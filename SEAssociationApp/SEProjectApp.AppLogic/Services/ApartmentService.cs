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
    }
}
