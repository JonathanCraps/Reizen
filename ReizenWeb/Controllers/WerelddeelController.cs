using Microsoft.AspNetCore.Mvc;
using ReizenServices;

namespace ReizenWeb.Controllers;
public class WerelddeelController : Controller
{
    private readonly ILogger<WerelddeelController> _logger;
    private readonly WerelddeelService werelddeelService;

    public WerelddeelController(ILogger<WerelddeelController> logger, WerelddeelService werelddeelService)
    {
        _logger = logger;
        this.werelddeelService = werelddeelService;
    }

    public async Task<IActionResult> Index()
    {
        return View( await werelddeelService.GetAllWerelddelenAsync());
    }
}
