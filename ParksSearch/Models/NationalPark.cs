namespace ParksSearch.Models
{
  public class NationalPark
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool? WheelchairAccess { get; set; }
  }
}