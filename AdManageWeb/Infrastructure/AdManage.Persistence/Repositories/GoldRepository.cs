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
    public class GoldRepository : IGoldRepository
    {
        private readonly AdManageDbContext _context;
        public GoldRepository(AdManageDbContext context)
        {
            _context = context;
        }
        public int GetGoldCount()
        {
            var value = _context.GoldPackages.Count();
            return value;
        }

        public async Task<List<GoldPackages>> GetGoldListWithPackages()
        {
            var values = await _context.GoldPackages.Include(x => x.Description).ToListAsync();
            return values;
        }

        public async Task<List<GoldPackages>> GetGoldListWithPackages2()
        {
            var values = await _context.GoldPackages.ToListAsync();
            return values;
        }


        public List<GoldPackages> GetLast5GoldWithPackages()
        {
            var values = _context.GoldPackages.Include(x => x.Description).OrderByDescending(x => x.Id).Take(5).ToList();
            return values;
        }
    }
}
