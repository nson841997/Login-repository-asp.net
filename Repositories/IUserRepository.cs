using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reponsitory_Demo.Models;
using System.Web;

namespace Reponsitory_Demo.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        // whereEmail : check email exits in database ?
        User WhereEmail(string email);
        // duyệt các phần từ theo chiều tiến IEnumerable
        IEnumerable<User> CheckLogin(string email, string password);
        
    }
}
