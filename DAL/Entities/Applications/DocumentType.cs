using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;
[Table("DocumentType")]
public class DocumentType: Auditable{
    [Key]
    public long Id {get;set;}
    [MaxLength(128)]
    public string? Name {get;set;}
}