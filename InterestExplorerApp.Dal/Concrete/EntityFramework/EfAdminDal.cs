using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfAdminDal : IAdminDal
    {
        InterestExplorerContext _context = new InterestExplorerContext();

        public Admin Login(string userName, string password)
        {
            return _context.Admins.SingleOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
