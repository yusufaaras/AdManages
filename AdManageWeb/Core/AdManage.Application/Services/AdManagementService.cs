using AdManage.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Services
{
    public class AdManagementService : IAdManagementService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public AdManagementService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task PerformOperations()
        {
            var goldRepo = _repositoryFactory.CreateGoldRepository();
            var goldCount = goldRepo.GetGoldCount();
            var goldPackages = await goldRepo.GetGoldListWithPackages();

            var silverRepo = _repositoryFactory.CreateSilverRepository();
            var silverCount = silverRepo.GetSilverCount();
            var silverPackages = await silverRepo.GetSilverListWithPackages();

            var bronzeRepo = _repositoryFactory.CreateBronzeRepository();
            var bronzeCount = bronzeRepo.GetBronzeCount();
            var bronzePackages = await bronzeRepo.GetBronzeListWithPackages();

            // Diğer operasyonlar...
        }
    }

}
