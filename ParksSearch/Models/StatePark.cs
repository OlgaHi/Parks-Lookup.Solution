using System.ComponentModel.DataAnnotations;

namespace ParksSearch.Models
{
  public class StatePark
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public bool? WheelchairAccess { get; set; }
  }
}