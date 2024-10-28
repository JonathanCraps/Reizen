using Microsoft.AspNetCore.Mvc;
using ReizenServices;
namespace ReizenWeb.Controllers;
public class ReisController : Controller
{
    private ReisService reisService;
    private BestemmingService bestemmingService;
    public ReisController(ReisService reisService, BestemmingService bestemmingService)
    {
        this.reisService = reisService;
        this.bestemmingService = bestemmingService;
    }
    public IActionResult Index()
    {
        return View();
    }
    [Route("BestemmingReizen")]
    public IActionResult BestemmingReizen(string code)
    {
        ViewBag.BestemmingNaam = bestemmingService.GetBestemmingByCodeAsync(code).Result.Plaats;
        ViewBag.Url = ViewBag.BestemmingNaam + ".jpg";
        return View(reisService.GetReizenByBestemmingCode(code).Result);
    }
}
