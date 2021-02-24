using System;
using System.Collections.Generic;
using contractor_jobs.Models;
using contractor_jobs.Repositories;

namespace contractor_jobs.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Job> Get()
    {
      return _repo.Get();
    }
    internal Job Get(int id)
    {
      Job job = _repo.Get(id);
      if (job == null)
      {
        throw new Exception("invalid id");
      }
      return job;
    }

    internal Job Create(Job newJob)
    {
      int id = _repo.Create(newJob);
      newJob.Id = id;
      return newJob;
    }

    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "deleted";
    }

  }
}