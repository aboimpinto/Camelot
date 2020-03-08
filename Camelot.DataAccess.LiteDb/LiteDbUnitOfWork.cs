﻿using System.Threading.Tasks;
using Camelot.DataAccess.Repositories;
using Camelot.DataAccess.UnitOfWork;
using LiteDB;

namespace Camelot.DataAccess.LiteDb
{
    public class LiteDbUnitOfWork : IUnitOfWork
    {
        private readonly LiteDatabase _database;
        
        public LiteDbUnitOfWork(LiteDatabase database)
        {
            _database = database;
        }
        
        public IRepository<T> GetRepository<T>() where T : class
        {
            var collection = _database.GetCollection<T>();
            
            return new Repository<T>(collection);
        }

        public Task SaveChangesAsync()
        {
            _database.Commit();

            return Task.CompletedTask;
        }
        
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}