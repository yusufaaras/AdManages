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
    public class MsSqlBronzeRepository //TODO STRUCTURAL - ADAPTER METHOD USAGE 1
    {
        private readonly AdManageDbContext _context;

        public MsSqlBronzeRepository(AdManageDbContext context)
        {
            _context = context;
        }

        public async Task<List<BronzePackages>> GetAllBronzePackages()
        {
            return await _context.BronzePackages.ToListAsync();
        }

        public List<BronzePackages> GetLast5BronzePackages()
        {
            return _context.BronzePackages.OrderByDescending(x => x.Id).Take(5).ToList();
        }

        public int GetBronzeCount()
        {
            return _context.BronzePackages.Count();
        }

        public async Task InsertBronzePackageAsync(BronzePackages package)
        {
            _context.BronzePackages.Add(package);
            await _context.SaveChangesAsync();
        }
    }


}
