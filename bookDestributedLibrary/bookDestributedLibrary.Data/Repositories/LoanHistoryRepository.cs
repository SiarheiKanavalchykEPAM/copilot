using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bookDestributedLibrary.Data.Repositories
{
    public class LoanHistoryRepository : IGenericRepository<LoanHistory>
    {
        private readonly ApplicationDbContext _context;

        public LoanHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanHistory> AddAsync(LoanHistory entity)
        {
            await _context.LoanHistory.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var loanHistory = await _context.LoanHistory.FindAsync(id);
            if (loanHistory != null)
            {
                _context.LoanHistory.Remove(loanHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<LoanHistory>> GetAllAsync()
        {
            return _context.LoanHistory;
        }

        public async Task<LoanHistory> GetByIdAsync(int id)
        {
            return await _context.LoanHistory.FindAsync(id);
        }

        public async Task<LoanHistory> UpdateAsync(LoanHistory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}