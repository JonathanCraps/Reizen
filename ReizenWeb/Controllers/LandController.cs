using Microsoft.AspNetCore.Mvc;
using ReizenServices;
using ReizenData.Models;

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
    public async Task<IActionResult> Index() => View(await landservice.GetAllLandenAsync());
    
    public async Task<IActionResult> WerelddeelLanden(int id)
    {
        Wereldeel nieuwWereldDeel = await werelddeelService.GetWerelddeelByIdAsync(id) is Wereldeel wereldDeel ? wereldDeel : new Wereldeel();
        ViewBag.WerelddeelNaam = nieuwWereldDeel.Naam;
        return View(await landservice.GetLandenWithWereldeelIdAsync(id));
    }
}
