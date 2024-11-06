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

    public async Task<IActionResult> KlantZoekenVanReis(int reisId)
    {
        Reis gekozenReis = await reisService.GetReisByIdAsync(reisId) is Reis reis ? reis : new Reis();
        ViewBag.ReisId = reisId;
        Bestemming nieuweBestemming = await bestemmingService.GetBestemmingByCodeAsync(gekozenReis.Bestemmingscode) is Bestemming bestemming ? bestemming : new Bestemming();
        ViewBag.Bestemming = nieuweBestemming.Code;
        ViewBag.Vertrek = gekozenReis.Vertrek;
        ViewBag.AantalDagen = gekozenReis.AantalDagen;
        ViewBag.PrijsPerPersoon = gekozenReis.PrijsPerPersoon;
        return View(new KlantByStringSearchViewModel(klantService));
    }
}
