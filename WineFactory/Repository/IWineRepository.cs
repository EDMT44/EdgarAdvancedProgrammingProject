
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace Repository
{
    /// <summary>
    /// Define las funcionalidades para la administración de trabajadores.
    /// </summary>
    public interface IWineRepository : IRepository
    {
        /// <summary>
        /// crea un vino en el soporte de datos
        /// </summary>
        /// <param name="fermenter">fermentador a usar en el vino</param>
        /// <param name="flavor">sabor del vino</param>
        /// <param name="id">id del vino</param>
        /// <param name="batchId">codigo de lote</param>
        /// <param name="state">estado del vino</param>
        /// <param name="date">fecha en la que se hizo</param>
        /// <returns></returns>
        Wine CreateWine(Fermenter fermenter, Flavors flavor, int id, string batchId, WineStates state, DateTime date);
        /// <summary>
        /// Actualiza un vino en el soporte de datos
        /// </summary>
        /// <param name="wine"></param>
        void UpdateWine(Wine wine);
        /// <summary>
        /// Elimina un vino en el soporte de datos
        /// </summary>
        /// <param name="wine"></param>
        void DeleteWine(Wine wine);
        /// <summary>
        /// Obtiene un vino en el soporte de datos a partir del lote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Wine FindWine(string id);
        /// <summary>
        /// Obtiene un vino en el soporte de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Wine GetWine(int id);
        /// <summary>
        /// Obtiene los vinos del soporte de datos
        /// </summary>
        /// <returns></returns>
        List<Wine> GetWines();
    }
}
