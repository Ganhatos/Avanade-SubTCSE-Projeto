using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Base.Repository
{
    public interface IBaseRepository<TEntity, Tid>
        where TEntity : BaseEntity<Tid>
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(Tid Id);

        Task<List<TEntity>> FindAllAsync();

        Task DeleteByIdAsync(Tid Id);

        Task UpdateByIdAsync(TEntity entity);

        //TODO: IEnumerable, IList, List
    }
}
