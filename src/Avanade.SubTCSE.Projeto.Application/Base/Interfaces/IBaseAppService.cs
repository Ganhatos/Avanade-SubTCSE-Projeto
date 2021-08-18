using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Base.Interfaces
{
    public interface IBaseAppService<IEntity, Tid>
    {
        Task<IEntity> AddAsync(IEntity entity);

        Task<List<IEntity>> FindAllAsync();

        Task<IEntity> GetByIdAsync(Tid Id);

        Task DeleteById(Tid Id);

        Task UpdateByIdAsync(IEntity entity);
    }
}