using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IFileService fileService;

        public ProjectController(IProjectService projectService, IFileService fileService)
        {
            this.projectService = projectService;
            this.fileService = fileService;
        }


        [HttpPost("getprojects")]
        public async Task<IActionResult> ProcessFile()
        {
            try
            {
                if (Request.Form.Files.Count == 0)
                    return BadRequest("No file uploaded.");

                var file = Request.Form.Files[0];

                var projects = await fileService.ReadPairsFromFile(file);
                if (projects.Count() == 0)
                    return BadRequest("No projects found in the input file.");

                var longestWorkedTogether = projectService.FindPairs(projects);
                if (longestWorkedTogether == null)
                    return NotFound("No pair of employees found who have worked together on common projects.");

                return Ok(longestWorkedTogether);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the file: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var p = new List<Project>();

            var projects = projectService.FindPairs(p);
            return Ok(projects);
        }
    }
}
