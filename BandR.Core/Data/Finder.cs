using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using BandR.Core.Exceptions;
using BandR.Core.Specifications;

namespace BandR.Core.Data
{
    public class Finder<TEntity> where TEntity : class, IPersistEntity
    {
        private readonly IQueryable<TEntity> candidates;

        public Finder(IQueryable<TEntity> candidates)
        {
            if (candidates == null)
            {
                throw new PersistException("Cannot create entity Finder with NULL argument.");
            }

            this.candidates = candidates;
        }

        public IEnumerable<TEntity> All(Specification<TEntity> specification)
        {
            return this.candidates.Where(specification).ToList();
        }

        public IEnumerable<TEntity> All(Specification<TEntity> specification, int page, int rows)
        {
            return this.candidates.Where(specification).Skip((page - 1) * rows).Take(rows);
        }

        public IEnumerable<TEntity> All<TKey>(Specification<TEntity> specification, Func<TEntity, TKey> keySelector, ListSortDirection sortDirection, int page, int rows)
        {
            var sortedCandidates = sortDirection == ListSortDirection.Ascending
                                        ? this.candidates.OrderBy(keySelector)
                                        : this.candidates.OrderByDescending(keySelector);
            return sortedCandidates.Where(specification).Skip((page - 1) * rows).Take(rows);
        }

        public IEnumerable<TEntity> All<TKey>(Specification<TEntity> specification, Func<TEntity, TKey> keySelector, ListSortDirection sortDirection)
        {
            var sortedCandidates = sortDirection == ListSortDirection.Ascending
                                        ? this.candidates.OrderBy(keySelector)
                                        : this.candidates.OrderByDescending(keySelector);
            return sortedCandidates.Where(specification);
        }

        public TEntity One(Specification<TEntity> specification)
        {
            return this.candidates.FirstOrDefault(specification);
        }

        public int Count(Specification<TEntity> specification)
        {
            return this.candidates.Count(specification);
        }

        public Finder<TEntity> Including<TProperty>(Expression<Func<TEntity, TProperty>> path)
        {
            return new Finder<TEntity>(this.candidates.Include(path));
        }
    }
}