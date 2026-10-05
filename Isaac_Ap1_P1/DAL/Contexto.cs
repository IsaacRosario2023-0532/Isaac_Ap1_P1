using Microsoft.EntityFrameworkCore;

namespace Isaac_Ap1_P1.DAL
{
    public class Contexto: DbContext
    {
        public Contexto (DbContextOptions <Contexto> contextoOptions) : base(contextoOptions) { }
    }
}
