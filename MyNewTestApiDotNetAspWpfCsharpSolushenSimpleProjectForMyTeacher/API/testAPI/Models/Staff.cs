using System.ComponentModel.DataAnnotations;

namespace testAPI.Models;

public class Staff
{
    [Key]
    public int id_staff { get; set; }
    public string? FullName { get; set; }
    public DateTime? Birthday { get; set; }
    public int? id_post { get; set; }
    public string? WorkingPhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? OfficeNumber { get; set; }
    public string? CorporateEmailAddress { get; set; }
    public string? PersonalEmailAddress { get; set; }
    public string? OtherInformation { get; set; }
    public DateTime? DateAcceptance { get; set; }
    public DateTime? DateDismissal { get; set; }
}
