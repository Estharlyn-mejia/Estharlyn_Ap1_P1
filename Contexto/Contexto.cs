using Estharlyn_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Estharlyn_Ap1_P1.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options){}

    public DbSet<Modelo1> Libros {get; set;}
}