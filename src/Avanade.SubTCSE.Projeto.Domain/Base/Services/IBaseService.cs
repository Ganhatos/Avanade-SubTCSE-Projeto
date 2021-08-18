using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Base.Services
{
    public interface IBaseService<TEntity, Tid>
        where TEntity : BaseEntity<Tid>
    {
        Task<TEntity> AddEmployeeRoleAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Tid Id);

        Task DeleteById(Tid Id);

        Task UpdateByIdAsync(TEntity entity);
    }
}
