using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> GetById(Guid id);
        //Task<IEnumerable<TEntity>> ReadExpression(Expression<Func<TEntity, bool>> predicateExpression);
        Task<int> SaveChanges();
    }
}
