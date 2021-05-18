using InterestExplorerApp.Bll.Abstract;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Bll.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin Login(string userName, string password)
        {
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                return _adminDal.Login(userName, password);
            }
            return null;
        }
    }
}
