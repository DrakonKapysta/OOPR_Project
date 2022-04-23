using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.EF;

namespace Laba2_OOPR.Models.ModelsInit
{
   public class Userinitializer<T> :IDisposable, IDataInit<T> where T: BaseRepo, new()
    {
        private readonly UserContext _db;
        private readonly DbSet<T> _table;

        protected UserContext Context => _db;

        public Userinitializer()
        {
            _db = new UserContext();
            _table = _db.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(T entity)
        {

            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => _table.SqlQuery(sql, sqlParametersObjects).ToList();

        public List<T> GetAll() =>_table.ToList();

        public T GetOne(int? id)=>_table.Find(id);

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
    }
}
