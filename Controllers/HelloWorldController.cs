using Microsoft.AspNetCore.Mvc;
using webapi;

namespace webApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class helloworldController : ControllerBase 
{
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;

    private readonly  ILogger<helloworldController> _logger;
    public helloworldController(IHelloWorldService helloWorld, ILogger<helloworldController> logger,TareasContext db)
    {
        helloWorldService = helloWorld;
        _logger = logger;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("this is log for hello weorl!");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}