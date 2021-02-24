using System;
using contractor_jobs.Models;
using contractor_jobs.Repositories;

namespace contractor_jobs.Services
{
  public class ContractorJobsService
  {
    private readonly ContractorJobsRepository _repo;

    public ContractorJobsService(ContractorJobsRepository repo)
    {
      _repo = repo;
    }

    internal ContractorJobs Create(ContractorJobs newContractorJobs)
    {
      int id = _repo.Create(newContractorJobs);
      newContractorJobs.Id = id;
      return newContractorJobs;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "delort";
    }
  }
}