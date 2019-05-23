using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Events;
using DatasManagment;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {


        private DataService DataSer;
        private DataRepository DatRep;
        private Machines newState;
        private Client client;
        private MachineState machineState;
        private DataContext dataContext;
        private Worker worker;

        [TestInitialize]
        public void TestInitialize()
        {
            var DataFill = new JSoupFill();
            dataContext = new DataContext();
            DatRep = new DataRepository(DataFill);
            DataSer = new DataService { DataRepository = DatRep };

            newState = new Machines
            {
                Id = 333,
                Name = "Test",
                Coins = 1
            };
            DataSer.AddMachine(newState);

            client = new Client
            {
                FirstName = "A",
                LastName = "B",
                ID = 666,
                Tokens = 3
            };
            DataSer.AddClient(client);


            worker = new Worker
            {
                FirstName = "A",
                LastName = "B",
                ID = 666,
            };
            DataSer.AddWorker(worker);

            machineState = new MachineState
            {
                IsTaken = false,
                IsWorking = true,
                CashInside = 13,
                DateOfUsage = DateTimeOffset.Now,
                Machine = newState
            };
            DataSer.AddState(machineState);
            //DataSer.UseMachine(5, 7, client, newState);


        }
        [TestMethod]
        public void ShouldFailToUseMachineWithoutCoins()
        {
            client.Tokens = 0;
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.UseMachine(5, 7, client, newState);
            Assert.AreEqual(temp, DatRep.GetAllEvents().ToList().Count);
            Console.WriteLine(DataSer.ShowBinded());

        }
        [TestMethod]
        public void ShouldContainFiveObjects()
        {
            Assert.AreEqual(DatRep.GetAllMachines().ToList().Count, 6);
            Assert.AreEqual(DatRep.GetAllClients().ToList().Count, 6);
            Assert.AreEqual(DatRep.GetAllStates().ToList().Count, 6);
            Assert.AreEqual(DatRep.GetAllWorkers().ToList().Count, 5);
        }

        [TestMethod]
        public void ShouldContainsFifteenObjectWithDifferentFill()
        {
            var DataFill = new DataFillStatic();
            var dcontext = new DataContext();
            var dRep = new DataRepository(DataFill);
            var dSer = new DataService { DataRepository = DatRep };

            Assert.AreEqual(dRep.GetAllMachines().ToList().Count, 15);
            Assert.AreEqual(dRep.GetAllClients().ToList().Count, 15);
            Assert.AreEqual(dRep.GetAllStates().ToList().Count, 15);
            Assert.AreEqual(dRep.GetAllWorkers().ToList().Count, 15);

        }

        [TestMethod]
        public void ShouldFailIfMachineIsTaken()
        {
            machineState.IsTaken = true;
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.UseMachine(5, 7, client, newState);
            Assert.AreEqual(temp, DatRep.GetAllEvents().ToList().Count);
            Console.WriteLine(DataSer.ShowBinded());

        }
        [TestMethod]
        public void ShouldNotFailIfMachineIsTaken()
        {
            machineState.IsTaken = false;
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.UseMachine(5, 7, client, newState);
            Assert.AreNotEqual(temp, DatRep.GetAllEvents().ToList().Count);
            Console.WriteLine(DataSer.ShowBinded());

        }


        [TestMethod]
        public void ShouldNotBeAbleToFillBrokenMachine()
        {
            machineState.IsWorking = false;
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.FillMachine(newState, worker, 10);
            Assert.AreEqual(temp, DatRep.GetAllEvents().ToList().Count);


        }

        [TestMethod]
        public void ShouldBeAbleToFillBrokenMachine()
        {

            machineState.IsWorking = true;
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.FillMachine(newState, worker, 10);
            Assert.AreNotEqual(temp, DatRep.GetAllEvents().ToList().Count);


        }
        [TestMethod]
        public void ShouldAddCoins()
        {

            machineState.IsWorking = true;
            var temp = newState.Coins;
            DataSer.FillMachine(newState, worker, 10);
            Assert.AreEqual(temp + 10, newState.Coins );


        }



        [TestMethod]
        public void ShouldNotFaitToUseMachineWithCoins()
        {
            var temp = DatRep.GetAllEvents().ToList().Count;
            DataSer.UseMachine(5, 7, client, newState);
            Assert.AreNotEqual(temp, DatRep.GetAllEvents().ToList().Count);
            Console.WriteLine(DataSer.ShowBinded());

        }

        [TestMethod]
        public void CreationOfWorker()
        {

            Worker testSubject = new Worker
            {
                FirstName = "TestName",
                LastName = "TestLastName",
                ID = 1
            };
            Assert.AreSame(testSubject.FirstName, "TestName");
            Assert.AreSame(testSubject.LastName, "TestLastName");
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
