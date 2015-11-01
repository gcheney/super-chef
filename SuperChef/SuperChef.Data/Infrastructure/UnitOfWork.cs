﻿using SuperChef.Core.Infrastructure;
using System;

namespace SuperChef.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private readonly IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            if (dbFactory == null)
            {
                throw new ArgumentNullException("dbFactory");
            }
            _dbFactory = dbFactory;
        }

        protected AppDbContext Context
        {
            get { return _context ?? (_context = _dbFactory.GetContext()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
