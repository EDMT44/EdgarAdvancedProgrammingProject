using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace Repository
{
    public partial class DBRepository : IWineRepository
    {
        /// <summary>
        /// Crea un vino en la base de datos
        /// </summary>
        /// <param name="fermenter"></param>
        /// <param name="flavor"></param>
        /// <param name="id"></param>
        /// <param name="batchId"></param>
        /// <param name="state"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Wine CreateWine(Fermenter fermenter, Flavors flavor,int id, string batchId, WineStates state, DateTime date)
        {
            var wine = new Wine(fermenter, flavor, id);
            wine.BatchId = batchId; 
            wine.State = state;
            wine.Date = date;
            Add(wine);
            return wine;
        }
        /// <summary>
        /// /Elimina un vino de la base de datos
        /// </summary>
        /// <param name="wine"></param>
        public void DeleteWine(Wine wine)
        {
            Delete(wine);
        }
        /// <summary>
        /// Obtiene un vino en la base de datos a partir del lote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wine FindWine(string id)
        {
            return Get<Wine>(w => w.BatchId == id).First();
        }
        /// <summary>
        /// Obtiene un vino en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wine GetWine(int id)
        {
            return GetByID<Wine>(id);
        }
        /// <summary>
        /// Obtiene los vinos de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Wine> GetWines()
        {
            return Get<Wine>();
        }
        /// <summary>
        /// Actualiza un vino en la base de datos
        /// </summary>
        /// <param name="wine"></param>
        public void UpdateWine(Wine wine)
        {
            Update(wine);
        }
    }
}
