using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIfilms.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        ActionResult<IEnumerable<TEntity>> GetAll();
        //ActionResult<TEntity> GetById(int id);
        // ActionResult<TEntity> GetByString(string str);
       
        Task<ActionResult<TEntity>> GetByIdAsync(int id);
        Task<ActionResult<TEntity>> GetByStringAsync(string str);


        //Task AddAsync(TEntity entity);
         void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        //Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
