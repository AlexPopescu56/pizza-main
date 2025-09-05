using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context = default!;
        private readonly ILogger<PizzaService> _logger;

    public PizzaService(PizzaContext context, ILogger<PizzaService> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public IList<Pizza> GetPizzas()
        {
            if(_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
             _logger.LogInformation("Added new pizza: {PizzaName}", pizza.Name);
        }

        public void DeletePizza(int id)
        {
            if (_context.Pizzas != null)
            {   
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }            
        } 
    }
}
