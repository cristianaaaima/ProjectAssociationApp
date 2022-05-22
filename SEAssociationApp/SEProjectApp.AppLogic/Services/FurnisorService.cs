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
    public class FurnisorService : BaseService
    {
        public FurnisorService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Furnisor> GetFurnisor()
        {
            return repositoryWrapper.FurnisorRepository.FindAll().ToList();
        }

        //public List<Furnisor> GetFurnisorByCondition(Expression<Func<Building, bool>> expression)
        //{
        //    return repositoryWrapper.FurnisorRepository.FindByCondition(expression).ToList();
        //}

        public void AddFurnisor(Furnisor furnisor)
        {
            repositoryWrapper.FurnisorRepository.Create(furnisor);
        }

        public void UpdateFurnisor(Furnisor furnisor)
        {
            repositoryWrapper.FurnisorRepository.Update(furnisor);
        }

        public void DeleteFurnisor(Furnisor furnisor)
        {
            repositoryWrapper.FurnisorRepository.Delete(furnisor);
        }

        public int GetNoFurnisorsWhereFurnisorName(string name, List<Furnisor> furnisors)
        {
            int cnt = 0;
            foreach (var f in furnisors)
            {
                if (f.FurnisorName.Equals(name))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public string GetNameWhereFurnisorId(int id, List<Furnisor> furnisors)
        {
            var name = "";
            foreach (var f in furnisors)
            {
                if (f.FurnisorId == id)
                {
                    name = f.FurnisorName;
                }
            }
            return name;
        }

        public string GetNameWhereStartDate(DateTime dt, List<Furnisor> furnisors)
        {
            var name = "";
            foreach (var f in furnisors)
            {
                if (f.StartDate == dt)
                {
                    name = f.FurnisorName;
                }
            }
            return name;
        }

        public int GetIdWhereDueDate(DateTime dt, List<Furnisor> furnisors)
        {
            var id = 0;
            foreach (var f in furnisors)
            {
                if (f.DueDate == dt)
                {
                    id = f.FurnisorId;
                }
            }
            return id;
        }

        public int GetNoFurnisorsWhereStartDateLessThan(DateTime dt, List<Furnisor> furnisors)
        {
            int cnt = 0;
            foreach (var f in furnisors)
            {
                if (f.StartDate.CompareTo(dt) == -1)
                {
                    cnt++;
                }
            }
            return cnt;
        }

    }
}

