using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataModel;

namespace SEProjectApp.DataAccess
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(AssociationContext associationContext)
            : base(associationContext)
        {
        }
    

    }
}
