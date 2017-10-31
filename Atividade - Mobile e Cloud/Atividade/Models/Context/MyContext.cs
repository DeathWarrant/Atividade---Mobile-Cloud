using System.Data.Entity;

namespace Atividade.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("StrConn")
        {

        }

        public System.Data.Entity.DbSet<Atividade.Models.Modelo3D> Modelo3D { get; set; }

        public System.Data.Entity.DbSet<Atividade.Models.TipoModelo3D> TipoModelo3D { get; set; }
    }
}