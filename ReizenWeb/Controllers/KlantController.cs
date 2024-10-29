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
    public KlantController(ILogger<KlantController> logger, KlantService klantService, ReisService reisService)
    {
        this._logger = logger;
        this.klantService = klantService;
        this.reisService = reisService;
    }
    public IActionResult Index()
    {
        return RedirectToAction("KlantZoekenVanReis", "Klant", new { reisId = 3 });
    }
    
    public IActionResult KlantZoekenVanReis(int reisId)
    {
        Reis gekozenReis = reisService.GetReisByIdAsync(reisId).Result! as Reis;
        return View(gekozenReis);
    }
    [HttpGet]
    public IActionResult TabelKlanten(string input)
    {
        var tabelKlantenViewModel = new KlantByStringSearchViewModel(klantService, input);
        return View();
    }
}
