namespace DataBaseCorrelations.Models;

public class UserSignUp
{
    public string Name { get; set; }=String.Empty;
    public List<UserClass>? Friends { get; set; } = new List<UserClass>();
    public List<ItemClass>? Items { get; set; } = new List<ItemClass>();
}