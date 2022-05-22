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
    public class BuildingService : BaseService
    {
        public BuildingService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Building> GetAllBuildings()
        {
            return repositoryWrapper.BuildingRepository.FindAll().ToList();
        }

        public List<Building> GetBuildingByCondition(Expression<Func<Building, bool>> expression)
        {
            return repositoryWrapper.BuildingRepository.FindByCondition(expression).ToList();
        }

        public void AddBuilding(Building building)
        {
            repositoryWrapper.BuildingRepository.Create(building);
        }

        public void UpdateBuilding(Building building)
        {
            repositoryWrapper.BuildingRepository.Update(building);
        }

        public void DeleteBuilding(Building building)
        {
            repositoryWrapper.BuildingRepository.Delete(building);
        }
    }
}
