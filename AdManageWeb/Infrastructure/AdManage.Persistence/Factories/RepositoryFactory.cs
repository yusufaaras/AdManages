using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Factories
{
    public class RepositoryFactory : IRepositoryFactory //TODO CREATIONAL - FACTORY METHOD USAGE 1
    {
        private readonly AdManageDbContext _context;

        public RepositoryFactory(AdManageDbContext context)
        {
            _context = context;
        }

        public IGoldRepository CreateGoldRepository()
        {
            return new GoldRepository(_context);
        }

        public ISilverRepository CreateSilverRepository()
        {
            return new SilverRepository(_context);
        }

        public IBronzeRepository CreateBronzeRepository()
        {
            return new BronzeRepository(_context);
        }
    }

}
