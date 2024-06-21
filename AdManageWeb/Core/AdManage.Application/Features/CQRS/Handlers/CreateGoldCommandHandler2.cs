using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class CreateGoldCommandHandler2 : IHandleMessages<CreateGoldCommand>
    {
        private IRepository<GoldPackages> _repository;

        public CreateGoldCommandHandler2(IRepository<GoldPackages> repository)
        {
            _repository = repository;
        }
        public Task Handle(CreateGoldCommand command, IMessageHandlerContext context)
        {
            _repository.CreateAsync(new GoldPackages
            {
                Description = command.Description,
                CoverImage = command.CoverImage,
                Details1 = command.Details1,
                Details2 = command.Details2,
                Image = command.Image,
                Image2 = command.Image2,
                Price = command.Price
            });

            return Task.CompletedTask;
        }
    }
}
