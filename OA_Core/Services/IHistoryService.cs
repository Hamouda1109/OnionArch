using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Core.Services
{
   public interface IHistoryService 
    {

        int Create(ExchangeHistory history);

        IEnumerable<ExchangeHistory> GetHighestNCurrencies(int count);
        IEnumerable<ExchangeHistory> GetLowestNCurrencies(int count);
        List<object> GetLeastNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate);
        List<object> GetMostNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate);

    }
}
