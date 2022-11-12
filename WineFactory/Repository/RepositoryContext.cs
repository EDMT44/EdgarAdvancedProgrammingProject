using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WineFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Define la estructura de la base de datos.
    /// </summary>
    public class RepositoryContext : DbContext
    {
        #region Tables

        public DbSet<Wine> Wines { get; set; }

      //  public DbSet<Student> Students { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public RepositoryContext()
        {

        }

        /// <summary>
        /// Inicializa un objeto <see cref="RepositoryContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        public RepositoryContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        /// <summary>
        /// Inicializa un objeto <see cref="RepositoryContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Habilita características en tiempo de diseño de la base de datos.
    /// Ejemplo: Migraciones.
    /// </summary>
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            try
            {
                var connectionString = @"Data Source=Edgar_Diego-PC\SQLEXPRESS;AttachDBFilename=C:\Escuela\CUJAE\Tercero\Programación Avanzada\Código\DB\ProductionAreaDB.mdf;Initial Catalog=ProductionAreaDB;User ID=sa;Password=12345";
                optionsBuilder.UseSqlServer(connectionString);
            }
            catch (Exception)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
            }

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
