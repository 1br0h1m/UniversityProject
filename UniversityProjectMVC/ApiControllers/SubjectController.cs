using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Services;

namespace UniversityProjectMVC.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController(SubjectService service) : ControllerBase
    {
        readonly SubjectService service = service;
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = await service.Get();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Subject subject)
        {
            try
            {
                var response = await service.Create(subject);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(Subject subject)
        {
            try
            {
                var response = await service.Update(subject);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await service.Delete(id);
                if (response)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
