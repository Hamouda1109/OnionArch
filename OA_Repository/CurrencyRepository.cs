using Domain;
using Microsoft.EntityFrameworkCore;
using OA_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA_Repository
{
    public class CurrencyRepository : ICurrency<Currency>
    {
        ApplicationContext db;
        public CurrencyRepository(ApplicationContext _db)
        {
            db = _db;
        }
        public int Create(Currency currency)
        {
            db.Currencies.Add(currency);
            return  db.SaveChanges();

        }

        public void Delete(int id)
        {
            db.Currencies.Remove(Find(id));
            db.SaveChanges();
        }

        public Currency Find(int id)
        {
            
            return db.Currencies.SingleOrDefault(b => b.Id == id);

        }
        public Currency FindByName(string name)
        {

            return db.Currencies.SingleOrDefault(b => b.Name == name);

        }
        public IEnumerable<Currency> GetAll()
        {
            return db.Currencies.AsEnumerable();
        }

        public void Update(Currency cureency)
        {
            db.Currencies.Update(cureency);
            db.SaveChanges();
        }
    }
}
