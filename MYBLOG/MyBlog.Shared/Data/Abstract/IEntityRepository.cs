using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

// Asenkron metotlar kullanılacaktır.
namespace MyBlog.Shared.Data.Abstract
{
    //class, IEntity, new() özellikleri filtredir, interfacein newlenebilir, class, ve ı entity nesnesi olması gerektiğini belirtir.
    public interface IEntityRepository<T>where T : class, IEntity, new()
    {
        // Predicate-> Filtre istenilen kullanıcının expressionu denebilir.
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        //predicate=null varsayılanı ile oluşturmanın sebebi, bir expression gelmezse direkt tüm listeyi getirmesini istememiz.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
    params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task <bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null); // predicate==null yaparsak tüm verilerin sayısını dönecektir
    }
}
