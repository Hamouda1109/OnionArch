using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Core.Repositories
{
    public interface ICurrency <TEntity>
    {
        int Create(TEntity cureency);
        void Update(TEntity cureency);
        void Delete(int id);
        TEntity Find(int id);
        IEnumerable<TEntity> GetAll();
        TEntity FindByName(string name);
    }
}
