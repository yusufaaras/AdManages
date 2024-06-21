using AdManage.Application.Features.CQRS.Queries;
using AdManage.Application.Features.CQRS.Results;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class GetReservationByIdQueryHandler
    {
        private readonly IRepository<Reservation> _repository;
        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }
        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetReservationByIdQueryResult
            {
                ReservationDate = values.ReservationDate,
                Title = values.Title,
                Description = values.Description,
                AppUser = values.AppUser,
                BronzePackages = values.BronzePackages,
                GoldPackages = values.GoldPackages,
                SilverPackages = values.SilverPackages,
                BronzePackagesId = values.BronzePackagesId,
                GoldPackagesId = values.BronzePackagesId,
                SilverPackagesId = values.SilverPackagesId

            };
        }
    }
}
