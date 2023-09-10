using Domain;
using OA_Core.Repositories;
using OA_Core.Services;
using OA_Repository.Validations.Currency;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    public class CurrencyService : ICurrencyService<Currency>
    {
        private ICurrency<Currency> CurrencyRepository { get; set; }
        public CurrencyService(ICurrency<Currency> currencyRepository)
        {
            CurrencyRepository = currencyRepository;
        }

        public int Create(Currency currency)
        {
            return  this.CurrencyRepository.Create(currency);
        }
        public void Delete(int id)
        {
            this.CurrencyRepository.Delete(id);
        }
        public Currency Find(int id)
        {
            return this.CurrencyRepository.Find(id);
        }
        public Currency FindByName(string name)
        {
            return this.CurrencyRepository.FindByName(name);
        }
        public IEnumerable<Currency> GetAll()
        {
            return this.CurrencyRepository.GetAll();
        }
        public void Update(Currency currency)
        {
            this.CurrencyRepository.Update(currency);
        }
    }
}
