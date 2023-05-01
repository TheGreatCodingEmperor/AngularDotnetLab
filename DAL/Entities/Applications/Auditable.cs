namespace DAL;

public class Auditable{
    public string? CreatedBy {get;set;}
    public string? UpdatedBy{get;set;}
    public DateTime CreatedTime {get;set;}
    public DateTime UpdatedTime {get;set;}
}