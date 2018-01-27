using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly Repository<Brewery> repository;

        public BreweryRepository(DbContext context)
        {
            repository = new Repository<Brewery>(context);
        }

        public int Create(Brewery brewery) => repository.Create(brewery);

        public Brewery Get(Expression<Func<Brewery, bool>> predicate) =>
            repository.Get(predicate);

        public IEnumerable<Brewery> GetAll(Expression<Func<Brewery, bool>> predicate = null) =>
            repository.GetAll(predicate);

        public int Update(Brewery brewery) => repository.Update(brewery);

        public int Delete(Brewery brewery) => repository.Delete(brewery);
    }
}
