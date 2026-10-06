using Estharlyn_Ap1_P1.Context;
using Microsoft.EntityFrameworkCore;
using Estharlyn_Ap1_P1.Models;

namespace Estharlyn_Ap1_P1.Services;

public class Services1(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int idAutor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.AnyAsync(libro => libro.IdAutor == idAutor);
    }

    public async Task<bool> Guardar(Modelo1 libros)
    {
        if(!await Existe(libros.IdAutor))
            return await Insertar(libros);
        else
            return await Modificar(libros);
    }

    private async Task<bool> Insertar(Modelo1 libros)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Add(libros);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Modelo1 libros)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Update(libros);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.Where(l => l.IdAutor == libroId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Modelo1?> Buscar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.AsNoTracking().FirstOrDefaultAsync(l => l.IdAutor == libroId);
    }

    public async Task<List<Modelo1>> ObtenerTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.AsNoTracking().ToListAsync();
    }
}