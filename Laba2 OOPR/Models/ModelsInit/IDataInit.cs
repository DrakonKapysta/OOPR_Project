using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR.Models.ModelsInit
{
    public interface IDataInit<T>
    {
        int Add(T entity);
        int AddRange(IList<T> entities);
        int Save(T entity);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetAll();
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}
