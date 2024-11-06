using Microsoft.AspNetCore.Mvc;
using ReizenServices;
using ReizenData.Models;
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
    public async Task<IActionResult> BestemmingReizen(string code)
    {
        Bestemming gekozenBestemming = await bestemmingService.GetBestemmingByCodeAsync(code) is Bestemming bestemming ? bestemming: new Bestemming();
        ViewBag.BestemmingNaam = gekozenBestemming.Plaats;
        ViewBag.Url = gekozenBestemming.Plaats + ".jpg";
        return View(reisService.GetReizenByBestemmingCode(code).Result);
    }
}
