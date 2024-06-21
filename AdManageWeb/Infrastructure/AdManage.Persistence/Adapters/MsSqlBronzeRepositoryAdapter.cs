using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Adapters
{
    public class MsSqlBronzeRepositoryAdapter : IBronzeRepository //TODO STRUCTURAL - ADAPTER METHOD USAGE 2
    {
        private readonly MsSqlBronzeRepository _msSqlBronzeRepository;

        public MsSqlBronzeRepositoryAdapter(MsSqlBronzeRepository msSqlBronzeRepository)
        {
            _msSqlBronzeRepository = msSqlBronzeRepository;
        }

        public async Task<List<BronzePackages>> GetBronzeListWithPackages()
        {
            return await _msSqlBronzeRepository.GetAllBronzePackages();
        }

        public List<BronzePackages> GetLast5BronzeWithPackages()
        {
            return _msSqlBronzeRepository.GetLast5BronzePackages();
        }

        public int GetBronzeCount()
        {
            return _msSqlBronzeRepository.GetBronzeCount();
        }
    }


}
