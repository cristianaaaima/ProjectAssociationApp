using SEProjectApp.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.AppLogic.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper repositoryWrapper;
        public BaseService(IRepositoryWrapper iRepositoryWrapper)
        {
            repositoryWrapper = iRepositoryWrapper;
        }

        public void Save()
        {
            repositoryWrapper.Save();
        }
    }
}
