﻿using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private StoreDbContext _context;
        public BaseRepository(StoreDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            T? result = await this._context.Set<T>().FindAsync(id);
            return result;
        }

        //public async Task<T> GetBySerial(string serial)
        //{
        //    T? result = await this._context.Set<T>().Where(x=>x.GetType().GetProperty("Serial").GetValue(serial,null).Equals(serial)).FirstOrDefaultAsync();
        //    return result;
        //}

        //public async Task Save()
        //{
        //    await this._context.SaveChangesAsync();
        //}

        public async Task Update(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            
        }
        public async Task<T> Add(T entity)
        {
            var result = await this._context.Set<T>().AddAsync(entity);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }

    }
}
