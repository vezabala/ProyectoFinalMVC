﻿using Actividad7.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad7.Data
{
    public class Repository : IRepository
    {
        private readonly Actividad7Context context;

        public Repository(Actividad7Context context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAll<T>() where T : Entity
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(int id) where T : Entity
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return await context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public async Task Save<T>(T obj) where T : Entity
        {
            await context.Set<T>().AddAsync(obj);
        }

        public void Update<T>(T obj) where T : Entity
        {
            context.Set<T>().Update(obj);
        }

        public void Delete<T>(T obj) where T : Entity
        {
            context.Set<T>().Remove(obj);
        }
    }
}
