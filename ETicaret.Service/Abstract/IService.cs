using System.Linq.Expressions;
using ETicaret.Core.Entities;

namespace ETicaret.Service.Abstract
{
    public interface IService<T> where T : class,IEntity,new()
    {
        //Senkron metotlar
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T,bool>> expression);
        IQueryable<T> GetQueryable(); //IQueryable gelen T değerini sorgulanabilir bir şekilde yollar.
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        int SaveChanges();
        //Asenkron metotlar
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync(); 



    }
}
