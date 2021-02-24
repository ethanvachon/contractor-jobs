using System;
using System.Data;
using contractor_jobs.Models;
using Dapper;

namespace contractor_jobs.Repositories
{
  public class ContractorJobsRepository
  {
    private readonly IDbConnection _db;

    public ContractorJobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(ContractorJobs newContractorJobs)
    {
      string sql = @"
      INSERT INTO contractorjobs
      (contractorId, jobId)
      VALUES
      (@contractorId, @jobId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractorJobs);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractorjobs WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}