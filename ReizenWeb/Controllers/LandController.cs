using Microsoft.AspNetCore.Mvc;
using ReizenServices;

namespace ReizenWeb.Controllers;
public class LandController : Controller
{
    private readonly ILogger<LandController> _logger;
    private LandService landservice;

    public LandController(ILogger<LandController> logger, LandService landservice)
    {
        _logger = logger;
        this.landservice = landservice;
    }
    public IActionResult Index()
    {
        return View(landservice.GetAllLandenAsync().Result);
    }
    public IActionResult WerelddeelLanden(int id)
    {
        return View(landservice.GetLandenWithWereldeelIdAsync(id).Result);
    }
}
