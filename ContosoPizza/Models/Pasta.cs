using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Pasta
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Range(0.01, 9999.99)]
    public decimal Price{ get; set; }
}