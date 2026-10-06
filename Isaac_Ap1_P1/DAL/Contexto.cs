using Isaac_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Isaac_Ap1_P1.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Autores> Autores { get; set; }
    
}