using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class MenuModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public MenuModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);
            return RedirectToPage();
        }
    }
}