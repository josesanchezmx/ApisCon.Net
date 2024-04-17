using Microsoft.AspNetCore.Mvc;
using webapi.Models;
namespace webApi.Controllers;

[Route("/api/[controller]")]

public class TareaController : ControllerBase
{
    ITareasService tareasService;

    public TareaController(ITareasService service)
    {
        tareasService = service;
    }

    // creacion de los end points para la API
    // end poin de obtener datos de la base de datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }

    // End Point Post
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tarea.FechaCreacion = DateTime.Now;
        tareasService.Save(tarea);
        return Ok();
    }


    // End Point para actulizar los datos de la base de datos
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareasService.Update(id, tarea);
        return Ok();
    }

    // End Point para eliminar datos de la base de datos
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareasService.Delete(id);
        return Ok();
    }
}