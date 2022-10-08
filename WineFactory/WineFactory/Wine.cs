
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace WineFactory
{
    /// <summary>
    /// Sabores lgrados por el productor
    /// </summary>
    public enum Flavors { Honey, Grape, Tamarind, RosePetals, Orange }
    public enum WineStates { Iddle,Fermenting, Finished }

    public class Wine
    {
        #region Events
        public event Action<Wine>? WineIsDone;
        #endregion

        #region Properties
        /// <summary>
        /// Timer para simular el tiempo de fermentacion
        /// </summary>
        public System.Timers.Timer FermentationTime { get; set; }

        /// <summary>
        /// Fermentador
        /// </summary>
        public Fermenter Fermenter { get; set; }
        /// <summary>
        /// Id de Lote de produccion
        /// </summary>
        public string BatchId { get; private set; }
        /// <summary>
        /// Fecha en la que se monto el vino
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Sabor del vino
        /// </summary>
        public Flavors Flavor { get; private set; }    
     
        /// <summary>
        /// Estado del vino
        /// </summary>
        public WineStates State { get; set; }
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// Costructor de Wine
        /// </summary>
        /// <param name="fermenter">Fermentador</param>
        /// <param name="flavor">Sabor</param>
        public Wine(Fermenter fermenter, Flavors flavor)
        {
            {
                FermentationTime = new System.Timers.Timer();
                FermentationTime.Interval = 500;
                FermentationTime.Elapsed += Ready;
                Flavor = flavor;
                Date = DateTime.Now;
                BatchId = CreateBatchId(fermenter,flavor);
                State = WineStates.Iddle;
                Fermenter = fermenter;
            }

        }
        #endregion
        #region Helpers
        /// <summary>
        /// Generador de codificacion de lotes
        /// </summary>
        /// <param name="fermenter">Fermentador</param>
        /// <param name="flavor">Sabor</param>
        /// <returns></returns>
        private string CreateBatchId(Fermenter fermenter, Flavors flavor) {
            return fermenter.Id.ToString() + Flavor.ToString() +DateTime.Now.ToString();
;        }
        #endregion
        /// <summary>
        /// Manejador del evento Timer.Elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Ready(object? sender, ElapsedEventArgs e)
        {
            State = WineStates.Finished;          
        }
        /// <summary>
        /// Metodo para iniciar la fermentacion en un fermentador
        /// </summary>
        public void Fermentation()
        {
            State = WineStates.Fermenting;
            FermentationTime.Start();
         
        }
        #endregion
    }
}
