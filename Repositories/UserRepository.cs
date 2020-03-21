using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reponsitory_Demo.Models;

namespace Reponsitory_Demo.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public User WhereEmail(string email)
        {
            var data = table.FirstOrDefault(s => s.Email == email);
            return data;
        }

        public IEnumerable<User> CheckLogin(string email, string password)
        {
            var data = table.Where(s => s.Email.Equals(email) &&
                        s.Password.Equals(password)).ToList();
            return data;
        }
    }
}