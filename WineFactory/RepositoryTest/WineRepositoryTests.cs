using Microsoft.VisualStudio.TestTools.UnitTesting;
using WineFactory;
using Repository;
using System;

namespace RepositoryTest
{
    [TestClass]
    public class WineRepositoryTests
    {
        IWineRepository _repository;

        public WineRepositoryTests()
        {
            var connectionString = @"Data Source=Edgar_Diego-PC\SQLEXPRESS;AttachDBFilename=C:\Escuela\CUJAE\Tercero\Programación Avanzada\Código\DB\ProductionAreaDB.mdf;Initial Catalog=ProductionAreaDB;User ID=sa;Password=12345";
            _repository = new DBRepository(connectionString);
        }

       [TestMethod]
       public void Can_CreateWine_Test()
       {
           // arrange
           Fermenter fermenter = new Fermenter(1, 200);
           Flavors flavor = Flavors.Honey;
           int id = 1;
           string batchId = "hello";
           DateTime date = DateTime.Now;
           WineStates state = WineStates.Iddle;
     
     
           // act
           _repository.BeginTransaction();
           var wine = _repository.CreateWine( fermenter,flavor,id);
           _repository.CommitTransaction();
     
           // assert
           Assert.IsNotNull(wine);
           Assert.AreNotEqual(0, wine.ID);
           Assert.AreEqual(batchId, wine.BatchId);
           
       }

        [TestMethod]
        public void Can_UpdateWine_Test()
        {
            // arrange
            _repository.BeginTransaction();
            var wine = _repository.FindWine("hello");
            _repository.CommitTransaction();

            WineStates state = WineStates.Finished;
            wine.State = state;

            // act
            _repository.BeginTransaction();
            _repository.UpdateWine(wine);
            _repository.PartialCommit();

            // assert
            var newWine = _repository.GetWine(wine.ID);
            _repository.CommitTransaction();
            Assert.IsNotNull(newWine);
            Assert.AreNotEqual(0, newWine.ID);
            Assert.AreEqual(state, newWine.State);
        }

        [TestMethod]
        public void Can_DeleteWine_Test()
        {
            // arrange
            _repository.BeginTransaction();
            var wine = _repository.FindWine("hello");
            _repository.CommitTransaction();

            // act
            _repository.BeginTransaction();
            _repository.DeleteWine(wine);
            _repository.PartialCommit();

            // assert
            var deletedWine = _repository.GetWine(wine.ID);
            _repository.CommitTransaction();
            Assert.IsNull(deletedWine);
        }
    }
}