using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data
{
    public class BeerRepository : IBeerRepository
    {
        private readonly Repository<Beer> repository;

        public BeerRepository(DbContext context)
        {
            repository = new Repository<Beer>(context);
        }

        public int Create(Beer beer) => repository.Create(beer);

        public Beer Get(Expression<Func<Beer, bool>> predicate) =>
            repository.Get(predicate);

        public IEnumerable<Beer> GetAll(Expression<Func<Beer, bool>> predicate = null) =>
            repository.GetAll(predicate);

        public int Update(Beer beer) => repository.Update(beer);

        public int Delete(Beer beer) => repository.Delete(beer);
    }
}
