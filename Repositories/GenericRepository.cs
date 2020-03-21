using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reponsitory_Demo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Reponsitory_Demo.Repositories
{
    // connect to database 
    // trien khai cac function da declare
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        // DB_Entities is database context
        // DbSet là một DbSet (table) của kiểu dữ liệu T nằm trong DbContext.
        public DB_Entities _context = null;
        public DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new DB_Entities();
            this._context.Configuration.ValidateOnSaveEnabled = false ;
            this.table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            var data = table.Find(id);
            table.Remove(data);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}