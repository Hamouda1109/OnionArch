using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository
{
    public interface IRepository<T> where T : Base
    {
        string Get(int id);
        IEnumerable<T> GetAll();



    }
}
