using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contractor_jobs.Models;
using contractor_jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractor_jobs.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    private readonly ContractorsService _cs;

    public JobsController(JobsService js, ContractorsService cs)
    {
      _js = js;
      _cs = cs;
    }

    // GET api/Jobs
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/Jobs/5
    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        return Ok(_js.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/contractors")]
    public ActionResult<IEnumerable<Contractor>> GetContractorsByJob(int id)
    {
      try
      {
        return Ok(_cs.GetContractorsByJob(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/Jobs
    [HttpPost]
    public ActionResult<Job> Post([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/Jobs/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_js.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}