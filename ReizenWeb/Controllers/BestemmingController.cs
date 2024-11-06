using Microsoft.AspNetCore.Mvc;
using ReizenServices;
using ReizenData.Models;

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
    public async Task<IActionResult> LandBestemmingen(int id)
    {
        Land nieuwLand = await landService.GetLandWithIdAsync(id) is Land land ? land : new Land();
        ViewBag.LandNaam = nieuwLand.Naam;
        ViewBag.Url = nieuwLand.Naam + ".png";
        return View(await bestemmingService.GetAllBestemmingenByLandIdAsync(id));
    }
}
