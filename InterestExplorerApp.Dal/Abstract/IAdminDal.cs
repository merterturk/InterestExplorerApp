using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Abstract
{
   public interface IAdminDal
    {
        Admin Login(string userName,string password);
    }
}
