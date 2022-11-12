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
        public Wine CreateWine(Fermenter fermenter, Flavors flavor,int id)
        {
            var wine = new Wine(fermenter, flavor, id);
           
            Add(wine);
            return wine;
        }

        public void DeleteWine(Wine wine)
        {
            Delete(wine);
        }

        public Wine FindWine(string id)
        {
            return Get<Wine>(w => w.BatchId == id).First();
        }

        public Wine GetWine(int id)
        {
            return GetByID<Wine>(id);
        }

        public List<Wine> GetWines()
        {
            return Get<Wine>();
        }

        public void UpdateWine(Wine wine)
        {
            Update(wine);
        }
    }
}
