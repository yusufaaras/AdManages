using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class CreateReservationCommandHandler
    {
        private IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand command)
        {
            await _repository.CreateAsync(new Reservation
            {
                ReservationDate =command.ReservationDate,
                Title=command.Title,
                Description=command.Description,
                AppUser=command.AppUser,
                AppUserId=command.AppUserId,
                BronzePackages=command.BronzePackages,
                GoldPackages=command.GoldPackages,
                SilverPackages=command.SilverPackages,
                BronzePackagesId=command.BronzePackagesId,
                GoldPackagesId=command.BronzePackagesId,
                SilverPackagesId = command.SilverPackagesId
                
            });
        }
    }
}
