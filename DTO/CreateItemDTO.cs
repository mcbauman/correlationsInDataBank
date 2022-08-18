namespace DataBaseCorrelations.DTO;

public class CreateItemDTO
{
    public string Name { get; set; }
    public List<Guid> UserIds { get; set; }
}