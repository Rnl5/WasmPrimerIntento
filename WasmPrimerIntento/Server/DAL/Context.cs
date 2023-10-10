using Microsoft.EntityFrameworkCore;
using WasmPrimerIntento.Server.Pages;

public class Context : DbContext
{
    public DbSet<Aportes> Aportes {get; set;}   

    public Context(DbContextOptions<Context> options) : base(options) { }
}