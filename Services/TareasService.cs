using webapi;
using webapi.Models;

public class TareasService  : ITareasService
{
    TareasContext context;

    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    // metodo para obtener los datos de la base de datos
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    // metodo para guardar los datos en la base de datos
    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    // metodo para  actualizar los datos en la base de datos
    public async Task Update(Guid id, Tarea Tarea)
    {
        var TareaActual = context.Tareas.Find(id);

        if(TareaActual != null)
        {
            TareaActual.Titulo = Tarea.Titulo;
            Tarea.Descripcion = Tarea.Descripcion;
            Tarea.PrioridadTarea = Tarea.PrioridadTarea;
            Tarea.CategoriaId = Tarea.CategoriaId;
            
            await context.SaveChangesAsync();
        }
    }

    // metodo para eliminar datos de la base de datos

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id , Tarea tarea);
    Task Delete(Guid id);
}