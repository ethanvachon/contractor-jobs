namespace contractor_jobs.Models
{
  public class Contractor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Industry { get; set; }
  }

  public class ContractorJobsViewModel : Contractor
  {
    public int ContractorJobsId { get; set; }
  }
}