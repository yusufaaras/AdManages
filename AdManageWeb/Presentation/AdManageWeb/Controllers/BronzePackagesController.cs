
using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Application.ViewModels;
using AdManage.Domain.Entities;
using AdManage.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class BronzePackagesController : Controller
    {
        private readonly CreateBronzeCommandHandler _createBronzeCommandHandler;
        private readonly GetBronzeByIdQueryHandler _getBronzeByIdQueryHandler;
        private readonly GetBronzeQueryHandler _getBronzeQueryHandler;
        private readonly UpdateBronzeCommandHandler _updateBronzeCommandHandler;
        private readonly RemoveBronzeCommandHandler _removeBronzeCommandHandler;
        private readonly IBronzeRepository _bronzerepository;


        public BronzePackagesController(CreateBronzeCommandHandler createBronzeCommandHandler, GetBronzeByIdQueryHandler getBronzeByIdQueryHandler, GetBronzeQueryHandler getBronzeQueryHandler, UpdateBronzeCommandHandler updateBronzeCommandHandler, RemoveBronzeCommandHandler removeBronzeCommandHandler, IBronzeRepository bronzerepository)
        {
            _createBronzeCommandHandler = createBronzeCommandHandler;
            _getBronzeByIdQueryHandler = getBronzeByIdQueryHandler;
            _getBronzeQueryHandler = getBronzeQueryHandler;
            _updateBronzeCommandHandler = updateBronzeCommandHandler;
            _removeBronzeCommandHandler = removeBronzeCommandHandler;
            _bronzerepository = bronzerepository;
        }

        public async Task<IActionResult> Index()
        {
            var bronzePackages = await _getBronzeQueryHandler.Handle();
            var bronzePackagesList = bronzePackages.Select(result => new AdManage.Domain.Entities.BronzePackages
            {
                Id = result.Id,
                Description = result.Description,
                Price = result.Price,
                Image = result.Image,
                CoverImage = result.CoverImage,
                Details1 = result.Details1,
                Details2 = result.Details2,
                Image2 = result.Image2
            }).ToList();

            return View(bronzePackagesList);
        }

        public async Task<IActionResult> PackagesBronze()
        {
            var bronzePackages = await _bronzerepository.GetBronzeListWithPackages();
            var bronzePackagesList = bronzePackages.Select(package => new BronzePackageViewModel
            {
                Id = package.Id,
                Description = package.Description,
                Price = package.Price,
                Image = package.Image,
                CoverImage = package.CoverImage,
                Details1 = package.Details1,
                Details2 = package.Details2,
                Image2 = package.Image2
            }).ToList();

            return View(bronzePackagesList);
        }

    }
}
