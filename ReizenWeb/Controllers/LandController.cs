using Microsoft.AspNetCore.Mvc;
using ReizenServices;

namespace ReizenWeb.Controllers;
public class LandController : Controller
{
    private readonly ILogger<LandController> _logger;
    private LandService landservice;
    private WerelddeelService werelddeelService;

    public LandController(ILogger<LandController> logger, LandService landservice, WerelddeelService werelddeelService)
    {
        _logger = logger;
        this.landservice = landservice;
        this.werelddeelService = werelddeelService;
    }
    public IActionResult Index()
    {
        return View(landservice.GetAllLandenAsync().Result);
    }
    public IActionResult WerelddeelLanden(int id)
    {
        ViewBag.WerelddeelNaam = werelddeelService.GetWerelddeelByIdAsync(id).Result.Naam;
        return View(landservice.GetLandenWithWereldeelIdAsync(id).Result);
    }
}
