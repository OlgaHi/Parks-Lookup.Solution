using System.ComponentModel.DataAnnotations;

namespace ParksSearch.Models
{
  public class NationalPark
  {
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Address { get; set; }
    [Required]
    public bool? WheelchairAccess { get; set; }
  }
}