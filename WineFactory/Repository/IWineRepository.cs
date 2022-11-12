
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
        Wine CreateWine(Fermenter fermenter, Flavors flavor, int id);
     
        void UpdateWine(Wine wine);

        void DeleteWine(Wine wine);

        Wine FindWine(string id);
    
        Wine GetWine(int id);

        List<Wine> GetWines();
    }
}
