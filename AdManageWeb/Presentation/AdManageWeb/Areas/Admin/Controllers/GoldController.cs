using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System.Threading.Tasks;

namespace AdManageWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GoldController : Controller
    {
        private readonly CreateGoldCommandHandler _createGoldCommandHandler;
        private readonly GetGoldByIdQueryHandler _getGoldByIdQueryHandler;
        private readonly GetGoldQueryHandler _getGoldQueryHandler;
        private readonly UpdateGoldCommandHandler _updateGoldCommandHandler;
        private readonly RemoveGoldCommandHandler _removeGoldCommandHandler;

        public GoldController(CreateGoldCommandHandler createGoldCommandHandler, GetGoldByIdQueryHandler getGoldByIdQueryHandler, GetGoldQueryHandler getGoldQueryHandler, UpdateGoldCommandHandler updateGoldCommandHandler, RemoveGoldCommandHandler removeGoldCommandHandler)
        {
            _createGoldCommandHandler = createGoldCommandHandler;
            _getGoldByIdQueryHandler = getGoldByIdQueryHandler;
            _getGoldQueryHandler = getGoldQueryHandler;
            _updateGoldCommandHandler = updateGoldCommandHandler;
            _removeGoldCommandHandler = removeGoldCommandHandler;
        }

        public async Task<IActionResult> Index()
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
        [HttpGet]
        public IActionResult AddGold()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGold(CreateGoldCommand command)
        {
            await _createGoldCommandHandler.Handle(command);
            return RedirectToAction("Gold", "Admin");
        }
        public async Task<IActionResult> DeleteGold(int id)
        {
            await _removeGoldCommandHandler.Handle(new RemoveGoldCommand(id));
            return RedirectToAction("Gold", "Admin");
        }

        [HttpGet]
		public async Task<IActionResult> UpdateGold(int id)
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
			}).ToList().FirstOrDefault((result => result.Id == id));
			return View(goldPackagesList);
		}
		[HttpPost]
        public async Task<IActionResult> UpdateGold(UpdateGoldCommand command)
        {
            
            await _updateGoldCommandHandler.Handle(command);
            return RedirectToAction("Gold", "Admin");
        }
    }
}
