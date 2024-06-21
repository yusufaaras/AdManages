using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Decorators
{
    public class BronzeRepositoryWithLogging : IBronzeRepository //TODO STRUCTURAL - DECORATORS METHOD USAGE 1
    {
        private readonly IBronzeRepository _innerRepository;
        private readonly ILogger<BronzeRepositoryWithLogging> _logger;

        public BronzeRepositoryWithLogging(IBronzeRepository innerRepository, ILogger<BronzeRepositoryWithLogging> logger)
        {
            _innerRepository = innerRepository;
            _logger = logger;
        }

        public async Task<List<BronzePackages>> GetBronzeListWithPackages()
        {
            _logger.LogInformation("GetBronzeListWithPackages çağırıldı");
            var result = await _innerRepository.GetBronzeListWithPackages();
            _logger.LogInformation("GetBronzeListWithPackages tamamlandı");
            return result;
        }

        public List<BronzePackages> GetLast5BronzeWithPackages()
        {
            _logger.LogInformation("GetLast5BronzeWithPackages çağırıldı");
            var result = _innerRepository.GetLast5BronzeWithPackages();
            _logger.LogInformation("GetLast5BronzeWithPackages tamamlandı");
            return result;
        }

        public int GetBronzeCount()
        {
            _logger.LogInformation("GetBronzeCount çağırıldı");
            var result = _innerRepository.GetBronzeCount();
            _logger.LogInformation("GetBronzeCount tamamlandı");
            return result;
        }
    }
}

