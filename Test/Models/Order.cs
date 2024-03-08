namespace Test.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime DateStart { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; }
}