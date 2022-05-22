using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataAccess
{
    public class FurnisorRepository : BaseRepository<Furnisor>, IFurnisorRepository
    {
        public FurnisorRepository(AssociationContext associationContext)
            : base(associationContext)
        {
        }
    }
}
