using Isaac_Ap1_P1.DAL;
using Isaac_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Isaac_Ap1_P1.Services;

public class AutoresService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Autores autor)
    {
        if (!await Existe(autor.IdAutor))
            return await Insertar(autor);
        else
            return await Modificar(autor);
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores.AnyAsync(a => a.IdAutor == id);
    }

    private async Task<bool> Insertar(Autores autor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Autores.Add(autor);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Autores autor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(autor);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Autores?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores.AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAutor == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores.Where(a => a.IdAutor == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Autores>> Listar(Expression<Func<Autores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}