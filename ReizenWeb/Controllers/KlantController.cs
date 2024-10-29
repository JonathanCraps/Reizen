using Azure;
using Microsoft.AspNetCore.Mvc;
using ReizenData.Models;
using ReizenServices;
using ReizenWeb.Models;

namespace ReizenWeb.Controllers;
public class KlantController : Controller
{
    private readonly ILogger<KlantController> _logger;
    private readonly KlantService klantService;
    private readonly ReisService reisService;
    private readonly BestemmingService bestemmingService;
    public KlantController(ILogger<KlantController> logger, KlantService klantService, ReisService reisService, BestemmingService bestemmingService)
    {
        this._logger = logger;
        this.klantService = klantService;
        this.reisService = reisService;
        this.bestemmingService = bestemmingService;
    }
    public IActionResult Index()
    {
        return RedirectToAction("KlantZoekenVanReis", "Klant", new { reisId = 3 });
    }

    public IActionResult KlantZoekenVanReis(int reisId)
    {
        Reis gekozenReis = reisService.GetReisByIdAsync(reisId).Result! as Reis;
        ViewBag.ReisId = reisId;
        ViewBag.Bestemming = bestemmingService.GetBestemmingByCodeAsync(gekozenReis.Bestemmingscode).Result;
        ViewBag.Vertrek = gekozenReis.Vertrek;
        ViewBag.AantalDagen = gekozenReis.AantalDagen;
        ViewBag.PrijsPerPersoon = gekozenReis.PrijsPerPersoon;
        return View(new KlantByStringSearchViewModel(klantService));
    }
}
