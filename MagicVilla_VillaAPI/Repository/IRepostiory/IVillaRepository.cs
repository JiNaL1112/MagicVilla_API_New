using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepostiory
{
    public interface IVillaRepository : IRepository<Villa>
    {

        Task<List<Villa>> GetAll(Expression<Func<Villa,bool>> filter = null);

        Task<Villa> Get(Expression<Func<Villa,bool>> filter = null,bool tracked =true );

        Task Create(Villa villa);

        Task Remove(Villa villa);

        Task SaveChanges();
    }
}
