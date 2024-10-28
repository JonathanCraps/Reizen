using Microsoft.AspNetCore.Mvc;
using ReizenServices;

namespace ReizenWeb.Controllers;
public class BestemmingController : Controller
{
    private readonly ILogger<BestemmingController> _logger;
    private readonly BestemmingService bestemmingService;

    public BestemmingController(ILogger<BestemmingController> logger, BestemmingService bestemmingService)
    {
        _logger = logger;
        this.bestemmingService = bestemmingService;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult LandBestemmingen(int id)
    {
        return View(bestemmingService.GetAllBestemmingenByLandIdAsync(id).Result);
    }
}
