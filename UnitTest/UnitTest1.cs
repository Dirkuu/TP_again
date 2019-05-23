using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Events;
using DatasManagment;
using System;

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
            var temp = DatRep.GetAllEvents();
            DataSer.UseMachine(5, 7, client, newState);
            Assert.AreSame(temp, DatRep.GetAllEvents());
           


            Console.WriteLine(DataSer.ShowBinded());

        }
        [TestMethod]
        public void CreationOfWorker()
        {
            Console.WriteLine("XD");

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
