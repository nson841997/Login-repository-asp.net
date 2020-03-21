using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Reponsitory_Demo.Models;

namespace Reponsitory_Demo.Repositories
{
    // định nghĩa 6 method để thao tác với mỗi entity 
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int obj);
        void Save();

        // Need create file inheritance from class here. 
    }
}
