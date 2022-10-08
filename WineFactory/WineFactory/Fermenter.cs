using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineFactory
{
    public class Fermenter
    {
        #region Prperties
        /// <summary>
        /// Id del fermentador
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Capacidad en Litros
        /// </summary>
        public int Capacity { get; private set; }
        #endregion
        #region Methods
        #region Constructors

        public Fermenter(int id, int capacity)
        {
            Id = id;
            Capacity = capacity;
        }
        #endregion
        #endregion
    }
}
