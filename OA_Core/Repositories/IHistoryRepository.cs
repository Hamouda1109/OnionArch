using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Core.Repositories
{
   public  interface IHistoryRepository<TEntity>
    {
        int Create(TEntity currency);
        IEnumerable<TEntity> GetHighestNCurrencies(int number);
        IEnumerable<TEntity> GetLowestNCurrencies(int number);
        IEnumerable<TEntity> GetLeastNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate);
        IEnumerable<TEntity> GetMostNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate);
    }
}
