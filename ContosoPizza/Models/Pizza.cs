using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    [Required]
    [EnumDataType(typeof(PizzaSize))]
    [Column(TypeName = "nvarchar(20)")]
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
}

public enum PizzaSize { Small, Medium, Large }