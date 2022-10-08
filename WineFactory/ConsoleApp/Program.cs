using WineFactory;
using System.Diagnostics;


namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creando fermentadores
            Fermenter f1 = new Fermenter(1, 200);
            Fermenter f2 = new Fermenter(2, 200);
            Fermenter f3 = new Fermenter(3, 200);
            Fermenter f4 = new Fermenter(4, 200);
            Fermenter f5 = new Fermenter(5, 200);
            //creando vinos
            Wine w1 = new Wine(f1, Flavors.Orange);
            Wine w2 = new Wine(f2, Flavors.Honey);
            Wine w3 = new Wine(f3, Flavors.Honey);
            Wine w4 = new Wine(f4, Flavors.Tamarind);
            Wine w5 = new Wine(f5, Flavors.Grape);
            //creando area de produccion
            ProductionArea Area1 = new ProductionArea();
            //agragando vinos al area
            Area1.AddWine(w1).
                AddWine(w2).
                AddWine(w3).
                AddWine(w4).
                AddWine(w5);
            foreach (var wine in Area1.Wines)
            {
                wine.Fermentation();
            }
            foreach (var item in Area1.Wines)
            {
                Console.WriteLine(item.BatchId);
                Console.WriteLine(item.Flavor.ToString());
                Console.WriteLine(item.State.ToString());
            }
            foreach (var item in Area1.FinishedWineList)
            {
                Console.WriteLine(item.BatchId);
                Console.WriteLine(item.Flavor.ToString());
                Console.WriteLine(item.State.ToString());
            }
            Thread.Sleep(5000);
            foreach (var item in Area1.Wines)
            {
                Console.WriteLine(item.BatchId);
                Console.WriteLine(item.Flavor.ToString());
                Console.WriteLine(item.State.ToString());
            }
            foreach (var item in Area1.FinishedWineList)
            {
                Console.WriteLine(item.BatchId);
                Console.WriteLine(item.Flavor.ToString());
                Console.WriteLine(item.State.ToString());
            }
        }
    }
}