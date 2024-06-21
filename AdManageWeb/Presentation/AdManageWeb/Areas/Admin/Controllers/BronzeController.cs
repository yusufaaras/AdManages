using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BronzeController : Controller
    {
        private readonly CreateBronzeCommandHandler _createBronzeCommandHandler;
        private readonly GetBronzeByIdQueryHandler _getBronzeByIdQueryHandler;
        private readonly GetBronzeQueryHandler _getBronzeQueryHandler;
        private readonly UpdateBronzeCommandHandler _updateBronzeCommandHandler;
        private readonly RemoveBronzeCommandHandler _removeBronzeCommandHandler;

        public BronzeController(CreateBronzeCommandHandler createBronzeCommandHandler, GetBronzeByIdQueryHandler getBronzeByIdQueryHandler, GetBronzeQueryHandler getBronzeQueryHandler, UpdateBronzeCommandHandler updateBronzeCommandHandler, RemoveBronzeCommandHandler removeBronzeCommandHandler)
        {
            _createBronzeCommandHandler = createBronzeCommandHandler;
            _getBronzeByIdQueryHandler = getBronzeByIdQueryHandler;
            _getBronzeQueryHandler = getBronzeQueryHandler;
            _updateBronzeCommandHandler = updateBronzeCommandHandler;
            _removeBronzeCommandHandler = removeBronzeCommandHandler;
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
        [HttpGet]
        public IActionResult AddBronze()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBronze(CreateBronzeCommand command)
        {
            await _createBronzeCommandHandler.Handle(command);
            return RedirectToAction("Bronze", "Admin");
        }

        public async Task<IActionResult> DeleteBronze(int id)
        {
            await _removeBronzeCommandHandler.Handle(new RemoveBronzeCommand(id));
            return RedirectToAction("Bronze","Admin");
        }

        [HttpGet]
		public async Task<IActionResult> UpdateBronze(int id)
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
			}).ToList().FirstOrDefault((result => result.Id == id));
			return View(bronzePackagesList);
        }

        [HttpPost]        
        public async Task<IActionResult> UpdateBronze(UpdateBronzeCommand command)
        {
            await _updateBronzeCommandHandler.Handle(command);
            return RedirectToAction("Bronze", "Admin");
        }
    }
}

