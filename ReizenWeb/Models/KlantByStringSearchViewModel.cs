using Microsoft.AspNetCore.Mvc;
using ReizenData.Models;
using ReizenServices;
namespace ReizenWeb.Models;

public class KlantByStringSearchViewModel : ViewComponent
{
    private readonly KlantService klantService;
    public string Input {  get; set; }
    public List<Klant> Klanten { get; set; } = new();

    public KlantByStringSearchViewModel(KlantService klantService, string input)
    {
        this.klantService = klantService;
        this.Input = input;
    }
    public IViewComponentResult Invoke()
    {
        Klanten = (List<Klant>)klantService.GetAllKlantenContainingStringAsync(Input).Result;
        return View(Klanten);
    }
}
