using System;
using System.Collections.Generic;
using System.Data;
using contractor_jobs.Models;
using Dapper;

namespace contractor_jobs.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql);
    }

    internal Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal int Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name, industry)
      VALUES
      (@Name, @Industry);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Contractor> GetContractorsByJob(int id)
    {
      string sql = @"
      SELECT c.*,
      cj.id as ContractorJobsId
      FROM contractorjobs cj
      JOIN contractors c ON c.id = cj.contractorId
      WHERE jobId = @id";
      return _db.Query<ContractorJobsViewModel>(sql, new { id });
    }
  }
}