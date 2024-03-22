namespace ItsDecidedDemo.Models;

public class Poll
{
    public int Id {get;set;}
    public string CustomName {get;set;}
    public string CustomDescription {get;set;}
    public string PIN {get;set;}
    public int PollTypeId {get;set;}
    public bool PublicResults {get;set;} 
    public int TotalSubmission {get;set;} = 0;

}