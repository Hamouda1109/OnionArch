using System.Collections.Generic;

namespace OA_Core.Services
{
    public interface ICurrencyService<TEntity>
    {
        int Create(TEntity currency);
        void Update(TEntity currency);
        void Delete(int id);
        TEntity Find(int id);
        IEnumerable<TEntity> GetAll();
        TEntity FindByName(string name);

    }
}
