using ApiFvj.Models;
using ApiFvj.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiFvj.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private StringConnection _context = new StringConnection();
        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            _dbSet = _context.Set<T>();
        }

        public T Create(T listT)
        {
            try
            {
                _dbSet.Add(listT);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listT;
        }

        public void Delete(T item)
        {
            var result = _dbSet.SingleOrDefault(p => p.Id == item.Id);
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch{}
        }

        public bool Exist(int Id)
        {
            return _dbSet.Any(x => x.Id == Id);
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(int Id)
        {
            return _dbSet.Where(x => x.Id == Id).FirstOrDefault();
        }

        public T Update(T item)
        {
            if (!Exist(item.Id)) return null;

            var result = _dbSet.SingleOrDefault(p => p.Id == item.Id);
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }
            return item;
        }
    }
}