﻿using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villa> query = _db.Villas;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }
        public async Task Create(Villa villa)
        {
            await _db.Villas.AddAsync(villa);
            await SaveChanges();

        }

        public async Task Remove(Villa villa)
        {
            _db.Villas.Remove(villa);
            await SaveChanges();
        }


        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

    }
}
