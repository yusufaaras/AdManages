using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using AdManage.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AdManageDbContext _context;
        public ReservationRepository(AdManageDbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetLast5ReservationWithPackages()
        {
            var values = _context.Reservations.Include(x => x.Description).OrderByDescending(x => x.ReservationId).Take(5).ToList();
            return values;
        }

        public int GetReservationCount()
        {
            var value = _context.Reservations.Count();
            return value;
        }

        public async Task<List<Reservation>> GetReservationListWithPackages()
        {
            var values = await _context.Reservations.Include(x => x.Description).ToListAsync();
            return values;
        }
    }
}
