using Domain;
using OA_Core.Repositories;
using OA_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA_Service
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository<ExchangeHistory> HistoryRepository { get; set; }

        public HistoryService(IHistoryRepository<ExchangeHistory> historyRepository)
        {
            HistoryRepository = historyRepository;
        }
        public int Create(ExchangeHistory history)
        {
            return this.HistoryRepository.Create(history);
        }

        public IEnumerable<ExchangeHistory> GetHighestNCurrencies(int count)
        {
            return this.HistoryRepository.GetHighestNCurrencies(count);
        }

        public IEnumerable<ExchangeHistory> GetLowestNCurrencies(int count)
        {
            return this.HistoryRepository.GetLowestNCurrencies(count);
        }

        public List<object> GetLeastNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate)
        {
            IEnumerable<ExchangeHistory> users = this.HistoryRepository.GetLeastNImprovedCurrenciesByDate(startDate, endDate);
            List<ExchangeHistory> test = users.ToList();
            var usersGroupedByCountry = test.GroupBy(user => user.CurrencyId);
            List<object> res =new List<object>();
            foreach (var group in usersGroupedByCountry)
            {
                Console.WriteLine("Users from " + group.Key + ":");
                
                foreach (var user in group)
                {

                    object x = new {
                        currencyName = user.CurrencyId,
                        currencyRate = (group.Max(x=>x.Rate) - group.Min(x => x.Rate))
                    };
                     res.Add(x);

                }
            }
            return res.Distinct().OrderBy(i => i).ToList();
        }
        public List<object> GetMostNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate)
        {
            IEnumerable<ExchangeHistory> users = this.HistoryRepository.GetMostNImprovedCurrenciesByDate(startDate, endDate);
            List<ExchangeHistory> test = users.ToList();
            var usersGroupedByCountry = test.GroupBy(user => user.CurrencyId);
            List<object> res = new List<object>();
            foreach (var group in usersGroupedByCountry)
            {
                Console.WriteLine("Users from " + group.Key + ":");

                foreach (var user in group)
                {

                    object x = new
                    {
                        currencyName = user.CurrencyId,
                        currencyRate = (group.Max(x => x.Rate) - group.Min(x => x.Rate))
                    };
                    res.Add(x);

                }
            }
            return res.Distinct().OrderByDescending(i => i).ToList();
        }
    }
}
