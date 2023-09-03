using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    public RequestController( IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> MakeRequest()
    {
        var client = _clientFactory.CreateClient("Test");
         
        var response = await client.GetAsync("http://localhost:5141/api/response/25");
        
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("---> ResponseService Returned Success.");
            return Ok();
        }

        Console.WriteLine("---> ResponseService Returned FAILURE.");
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}