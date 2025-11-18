using System.ComponentModel.DataAnnotations;

namespace testAPI.Models;

public class Division
{
    [Key]
    public int id_division { get; set; }
    public string? DivisionName { get; set; }
    public string? DivisionDescription { get; set; }
    public int? id_parent { get; set; }
    public int? sLevel { get; set; }
}
