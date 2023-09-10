using Domain;
using Microsoft.EntityFrameworkCore;
using OA_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA_Repository
{
    public class HistoryRepository : IHistoryRepository<ExchangeHistory>
    {
        ApplicationContext db;
        public HistoryRepository(ApplicationContext _db)
        {
            db = _db;
        }
        public int Create(ExchangeHistory history)
        {
            db.ExchangeHistories.Add(history);
            return db.SaveChanges();
        }

        public IEnumerable<ExchangeHistory> GetHighestNCurrencies(int number)
        {
            return db.ExchangeHistories.AsEnumerable().Distinct().OrderByDescending(x => x.Rate).Take(number);

        }
        public IEnumerable<ExchangeHistory> GetLowestNCurrencies(int number)
        {
            return db.ExchangeHistories.AsEnumerable().Distinct().OrderBy(x => x.Rate).Take(number);

        }
        public IEnumerable<ExchangeHistory> GetLeastNImprovedCurrenciesByDate(DateTime startDate,DateTime endDate)
        {
             return db.ExchangeHistories.AsEnumerable()
            .Where(x => x.ExchangeTime >= startDate)
            .Where(xc => xc.ExchangeTime <= endDate);
        }
        public IEnumerable<ExchangeHistory> GetMostNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate)
        {
            return db.ExchangeHistories.AsEnumerable()
          .Where(x => x.ExchangeTime >= startDate)
          .Where(xc => xc.ExchangeTime <= endDate);
        }
    }
}
