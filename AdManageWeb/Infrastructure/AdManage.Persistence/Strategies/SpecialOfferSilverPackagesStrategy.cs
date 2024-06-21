using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Features.CQRS.Queries;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Strategies
{
    public class SpecialOfferSilverPackagesStrategy : ISilverPackagesStrategy //TODO BEHAVIOURAL- STRATEGY METHOD USAGE 2
    {
        private readonly GetSilverByIdQueryHandler _getSilverByIdQueryHandler;

        public SpecialOfferSilverPackagesStrategy(GetSilverByIdQueryHandler getSilverByIdQueryHandler)
        {
            _getSilverByIdQueryHandler = getSilverByIdQueryHandler;
        }

        public async Task<List<SilverPackages>> GetSilverPackages()
        {
            int defaultId = 1;
            var query = new GetSilverByIdQuery(defaultId);
            var result = await _getSilverByIdQueryHandler.Handle(query);

            var silverPackagesList = new List<SilverPackages>
        {
            new SilverPackages
            {
                Id = result.Id,
                Description = result.Description,
                Price = result.Price,
                Image = result.Image,
                CoverImage = result.CoverImage,
                Details1 = result.Details1,
                Details2 = result.Details2,
                Image2 = result.Image2
            }
        };

            return silverPackagesList;
        }
    }


}
