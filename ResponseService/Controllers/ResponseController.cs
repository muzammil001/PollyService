using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAResponse(int id)
        {
            var rnd = new Random();
            var rndInt = rnd.Next(1, 101);
            if (rndInt >= id)
            {
                Console.WriteLine($"---> {DateTime.Now} Failure - Generate a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("---> Success - Generate a HTTP see");
            return Ok(new {id});
        }
    }
}