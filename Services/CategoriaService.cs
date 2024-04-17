using webapi;
using webapi.Models;

public class CategoriaService : ICategoriaService // con esto implementamos la interfaz del servicio
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

// metodo para guardar cambios 
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    //metodo para hacer update 
      public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoria.Descripcion = categoria.Descripcion;
            categoria.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }

    // metodo eliminar 
     public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual !=  null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}

// servico listo para para implementar 
public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id,Categoria categoria);
    Task Delete(Guid id);


}