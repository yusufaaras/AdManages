using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class GoldPackagesController : Controller
    {
        private readonly CreateGoldCommandHandler _createGoldCommandHandler;
        private readonly GetGoldByIdQueryHandler _getGoldByIdQueryHandler;
        private readonly GetGoldQueryHandler _getGoldQueryHandler;
        private readonly UpdateGoldCommandHandler _updateGoldCommandHandler;
        private readonly RemoveGoldCommandHandler _removeGoldCommandHandler;

        private readonly IGoldRepository _goldRepository;

        public GoldPackagesController(
            CreateGoldCommandHandler createGoldCommandHandler, 
            GetGoldByIdQueryHandler getGoldByIdQueryHandler, 
            GetGoldQueryHandler getGoldQueryHandler, 
            UpdateGoldCommandHandler updateGoldCommandHandler, 
            RemoveGoldCommandHandler removeBronzeCommandHandler,
            IRepositoryFactory repositoryFactory)//TODO CREATIONAL - FACTORY METHOD USAGE 2
        {
            _createGoldCommandHandler = createGoldCommandHandler;
            _getGoldByIdQueryHandler = getGoldByIdQueryHandler;
            _getGoldQueryHandler = getGoldQueryHandler;
            _updateGoldCommandHandler = updateGoldCommandHandler;
            _removeGoldCommandHandler = removeBronzeCommandHandler;

            _goldRepository = repositoryFactory.CreateGoldRepository();
        }

        public async Task<IActionResult> PackagesGold()
        {
            var goldPackages = await _getGoldQueryHandler.Handle();
            var goldPackagesList = goldPackages.Select(result => new AdManage.Domain.Entities.GoldPackages
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

            return View(goldPackagesList);
        }

        public async Task<IActionResult> Index()//TODO CREATIONAL - FACTORY METHOD USAGE 3
        {
            var goldPackages = await _goldRepository.GetGoldListWithPackages2();
            var goldPackagesList = goldPackages.Select(package => new GoldPackageViewModel
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

            return View(goldPackagesList);
        }


        public IActionResult GetLast5GoldPackages()
        {
            var goldPackages = _goldRepository.GetLast5GoldWithPackages();
            return View(goldPackages);
        }
    }
}

