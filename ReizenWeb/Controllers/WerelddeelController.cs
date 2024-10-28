using Microsoft.AspNetCore.Mvc;
using ReizenServices;
using ReizenWeb.Models;

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

    public IActionResult Index()
    {
        return View(werelddeelService.GetAllWerelddelenAsync().Result);
    }
}
