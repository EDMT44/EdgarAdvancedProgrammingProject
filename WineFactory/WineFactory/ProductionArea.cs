using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineFactory
{
    public class ProductionArea
    {
        #region Properties
        /// <summary>
        /// lista de vinos terminados
        /// </summary>
        public List<Wine> FinishedWineList { get; set; }
        /// <summary>
        /// Lista de vinos
        /// </summary>
        public List<Wine> Wines { get; set; }

        #endregion
        #region Methods
        #region Constructors
        public ProductionArea()
        {
            Wines = new List<Wine>();
            FinishedWineList = new List<Wine>();
        }
        #endregion
        
        /// <summary>
        /// Agregar un vino a la lista
        /// </summary>
        /// <param name="wine"> vino a agregar</param>
        /// <returns></returns>
        public ProductionArea AddWine(Wine wine)
        {
            Wines.Add(wine);
            wine.WineIsDone += SetToFinishedWineList;
            return this;
        }

        private void SetToFinishedWineList(Wine wine)
        {
            FinishedWineList.Add(wine);
            Wines?.Remove(wine);

        }

        /// <summary>
        /// Eliminar un vino de la lista
        /// </summary>
        /// <param name="wineCode">Codigo del lote</param>
        void DeleteWine(string wineCode)
        {
            Wines?.Remove(Wines.First(x => x.BatchId == wineCode));
        }
       
        #endregion
    }
}
