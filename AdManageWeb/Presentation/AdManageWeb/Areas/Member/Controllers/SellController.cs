using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Member.Controllers
{
    [Area("Member")]
    public class SellController : Controller
    {
        private readonly CreateReservationCommandHandler _createReservationCommandHandler;
        private readonly GetReservationByIdQueryHandler _getReservationByIdQueryHandler;
        private readonly GetReservationQueryHandler _getReservationQueryHandler;

        public SellController(CreateReservationCommandHandler createReservationCommandHandler, GetReservationByIdQueryHandler getReservationByIdQueryHandler, GetReservationQueryHandler getReservationQueryHandler)
        {
            _createReservationCommandHandler = createReservationCommandHandler;
            _getReservationByIdQueryHandler = getReservationByIdQueryHandler;
            _getReservationQueryHandler = getReservationQueryHandler;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationCommand command)
        {
            await _createReservationCommandHandler.Handle(command);
            return RedirectToAction("Bronze", "Admin");
        }
    }
}
