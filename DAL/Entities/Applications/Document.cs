using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;
[Table("Document")]
public class Document:Auditable{
    [Key]
    public string Guid {get;set;}

    [MaxLength(1024)]
    public string Path {get;set;}
}