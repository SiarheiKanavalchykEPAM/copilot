using bookDestributedLibrary.Data.Models;
using bookDestributedLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bookDestributedLibrary.Data.Repositories
{
    public class ReservationQueueRepository : IGenericRepository<ReservationQueue>
    {
        private readonly ApplicationDbContext _context;

        public ReservationQueueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationQueue> AddAsync(ReservationQueue entity)
        {
            await _context.ReservationQueues.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var reservationQueue = await _context.ReservationQueues.FindAsync(id);
            if (reservationQueue != null)
            {
                _context.ReservationQueues.Remove(reservationQueue);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<ReservationQueue>> GetAllAsync()
        {
            return _context.ReservationQueues;
        }

        public async Task<ReservationQueue> GetByIdAsync(int id)
        {
            return await _context.ReservationQueues.FindAsync(id);
        }

        public async Task<ReservationQueue> UpdateAsync(ReservationQueue entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
