using Microsoft.AspNetCore.Mvc;
using ReizenServices;

namespace ReizenWeb.Controllers;
public class BestemmingController : Controller
{
    private readonly ILogger<BestemmingController> _logger;
    private readonly BestemmingService bestemmingService;
    private readonly LandService landService;

    public BestemmingController(ILogger<BestemmingController> logger, BestemmingService bestemmingService, LandService landService)
    {
        _logger = logger;
        this.bestemmingService = bestemmingService;
        this.landService = landService;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult LandBestemmingen(int id)
    {
        ViewBag.LandNaam = landService.GetLandWithIdAsync(id).Result.Naam;
        ViewBag.Url = ViewBag.LandNaam + ".png";
        return View(bestemmingService.GetAllBestemmingenByLandIdAsync(id).Result);
    }
}
