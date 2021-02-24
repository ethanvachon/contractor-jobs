using System.Collections.Generic;
using contractor_jobs.Models;
using contractor_jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractor_jobs.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorJobsController : ControllerBase
  {
    private readonly ContractorJobsService _service;

    public ContractorJobsController(ContractorJobsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<ContractorJobs> Create([FromBody] ContractorJobs newContractorJobs)
    {
      try
      {
        return Ok(_service.Create(newContractorJobs));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}