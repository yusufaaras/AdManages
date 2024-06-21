using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SilverController : Controller
    {
        private readonly CreateSilverCommandHandler _createSilverCommandHandler;
        private readonly GetSilverByIdQueryHandler _getSilverByIdQueryHandler;
        private readonly GetSilverQueryHandler _getSilverQueryHandler;
        private readonly UpdateSilverCommandHandler _updateSilverCommandHandler;
        private readonly RemoveSilverCommandHandler _removeSilverCommandHandler;

        public SilverController(CreateSilverCommandHandler createSilverCommandHandler, GetSilverByIdQueryHandler getSilverByIdQueryHandler, GetSilverQueryHandler getSilverQueryHandler, UpdateSilverCommandHandler updateSilverCommandHandler, RemoveSilverCommandHandler removeSilverCommandHandler)
        {
            _createSilverCommandHandler = createSilverCommandHandler;
            _getSilverByIdQueryHandler = getSilverByIdQueryHandler;
            _getSilverQueryHandler = getSilverQueryHandler;
            _updateSilverCommandHandler = updateSilverCommandHandler;
            _removeSilverCommandHandler = removeSilverCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var bronzePackages = await _getSilverQueryHandler.Handle();
            var bronzePackagesList = bronzePackages.Select(result => new AdManage.Domain.Entities.SilverPackages
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
        public IActionResult AddSilver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSilver(CreateSilverCommand command)
        {
            await _createSilverCommandHandler.Handle(command);
            return RedirectToAction("Silver", "Admin");
        }

        public async Task<IActionResult> DeleteSilver(int id)
        {
            await _removeSilverCommandHandler.Handle(new RemoveSilverCommand(id));
            return RedirectToAction("Silver", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSilver(int id)
        {
            var bronzePackages = await _getSilverQueryHandler.Handle();
            var bronzePackagesList = bronzePackages.Select(result => new AdManage.Domain.Entities.SilverPackages
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
        public async Task<IActionResult> UpdateSilver(int id, UpdateSilverCommand command)
        {
            command.Id = id;
            await _updateSilverCommandHandler.Handle(command);
            return RedirectToAction("Silver", "Admin");
        }
    }
}
