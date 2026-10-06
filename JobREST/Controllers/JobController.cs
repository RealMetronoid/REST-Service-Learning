using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JobREST.Models;
using System.Collections.Generic;

namespace JobREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private JobRepositoryList _repo;

        public JobController(JobRepositoryList repo)
        {
            _repo = repo;
        }

        //  GET: api/<JobController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAll(
            [FromQuery] int minLevel,
            [FromQuery] int? maxLevel,
            [FromQuery] string? nameFilter)
        {
            try
            {
                IEnumerable<Job> result = _repo.GetAllJobs(minLevel, maxLevel, nameFilter);
                if (result == null || result.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //  GET api/<CatsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            Job? job = _repo.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        //  POST api/<CatsController>
        [HttpPost]
        public Job Post([FromBody] Job newJob)
        {
            return _repo.AddJob(newJob);
        }

        //  PUT api/<CatsController>/5
        [HttpPut("{id}")]
        public Job? Put(int id, [FromBody] Job Value)
        {
            return _repo.UpdateJob(id, Value);
        }

        //  DELETE api/<CatsController>/5
        [HttpDelete("{id}")]
        public Job? Delete(int id)
        {
            return _repo.RemoveJob(id);
        }

        [HttpOptions]
        public void Options()
        {
        }
    }
}
