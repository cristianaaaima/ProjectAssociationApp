using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataModel;

namespace SEProjectApp.DataAccess
{
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(AssociationContext associationContext)
            : base(associationContext)
        {
        }
    }
}
