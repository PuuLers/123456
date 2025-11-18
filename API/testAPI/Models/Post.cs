using System.ComponentModel.DataAnnotations;

namespace testAPI.Models;

public class Post
{
    [Key]
    public int id_post { get; set; }
    public string? PostName { get; set; }
    public string? PostDescription { get; set; }
    public int? id_division { get; set; }
}
