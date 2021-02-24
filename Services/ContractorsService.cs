using System;
using System.Collections.Generic;
using contractor_jobs.Models;
using contractor_jobs.Repositories;

namespace contractor_jobs.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    private readonly JobsRepository _jrepo;

    public ContractorsService(ContractorsRepository repo, JobsRepository jrepo)
    {
      _repo = repo;
      _jrepo = jrepo;
    }

    internal IEnumerable<Contractor> Get()
    {
      return _repo.Get();
    }
    internal Contractor Get(int id)
    {
      Contractor cont = _repo.Get(id);
      if (cont == null)
      {
        throw new Exception("invalid id");
      }
      return cont;
    }

    internal object Create(Contractor newContractor)
    {
      int id = _repo.Create(newContractor);
      newContractor.Id = id;
      return newContractor;
    }

    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "deleted";
    }

    internal IEnumerable<Contractor> GetContractorsByJob(int id)
    {
      Job exists = _jrepo.Get(id);
      if (exists == null)
      {
        throw new Exception("invalid id");
      }
      return _repo.GetContractorsByJob(id);
    }
  }
}