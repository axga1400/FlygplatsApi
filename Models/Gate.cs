
namespace FlygplatsApi.Models;

public class Gate
{
    public long Id { get; set; }
    public string? Namn { get; set; }
    public string? Terminal { get; set; }
    public List<Flyg>? Flyg { get; set; }
}