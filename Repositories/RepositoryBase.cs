using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T :class, new()
    //Dbsetlerle çalışıldığı için tip referance tipli olmalı ve newlenebilir olmalı kısıtlayıcılar.
    {
        protected readonly RepositoryContext _context;
        // veri tabanına bağlama contexti IoC çözümleme yapar.
        //Devralnınan klasörde context gerekli olursa protected kullanılır.
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //Baseclası devralanlar newlenebilecek devralmayanlar newlenemez o yüzden  abstract yapıldı.
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
            ?_context.Set<T>()
            : _context.Set<T>().AsNoTracking();

        }
        //yukarıda kontrol yapısı vardır 
        //değişiklikleri izleme parametresi true ise set yapıp 
        //yerleştirme yapar ilgili nesneye
        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ?_context.Set<T>().Where(expression).SingleOrDefault()
            :_context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
       
    }
}