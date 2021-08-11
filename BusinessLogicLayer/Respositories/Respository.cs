using DataAccessLayer.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Respositories
{
    public class Respository<T> : IRespository<T> where T : class, new()
    {
        private DataContext db;
        private DbSet<T> tbl;

        public Respository()
        {
            db = new DataContext();
            tbl = db.Set<T>();
        }

        public bool CheckDuplicate(Expression<Func<T, bool>> predicate)
        {
            return tbl.AsNoTracking().Any(predicate);
        }

        public virtual bool Create(T t)
        {
            try
            {
                tbl.Add(t);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Delete(object id)
        {
            try
            {
                T t = FindById(id);
                tbl.Remove(t);
                Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(T t)
        {
            try
            {
                tbl.Remove(t);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual T FindById(object id)
        {
            try
            {
                T t = tbl.Find(id);
                return t;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public T GetOne(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsNoTracking().AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return tbl.AsNoTracking().ToList();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public virtual bool Update(T t)
        {
            try
            {
                db.Entry(t).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T SaveObject(T t)
        {
            try
            {
                tbl.Add(t);
                Save();
                db.Entry(t).Reload();
                return t;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
