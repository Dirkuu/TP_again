using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatasLayer;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {


        [TestInitialize]
        public void init()
        {

        }
        [TestMethod]
        public void AddToData()
        {
            int sizeBeforeAdd = DataRepository.GetAllClients().Count;
            var cl = new Client
            {
                firstName = "Test",
                lastName = "Test"
            };
            DataRepository.CreateClient(cl);
            Assert.AreEqual(DataRepository.GetAllClients().Count, sizeBeforeAdd);
        }

        [TestMethod]
        public void Deteleclient()
        {
            int sizeBeforeAdd = DataRepository.GetAllClients().Count;
            var cl = new Client
            {
                firstName = "Test",
                lastName = "Test"
            };
            DataRepository.CreateClient(cl);
            DataRepository.DeleteClient(cl);
            Assert.IsFalse(DataRepository.GetAllClients().Contains(cl));
        }

        [TestMethod]
        public void UpdateTest()
        {

            var cl = new Client
            {
                firstName = "Test",
                lastName = "Testinglastname",
                Id = 10
            };
            DataRepository.CreateClient(cl);

            cl.firstName = "modified";
            DataRepository.UpdateClient(cl);
            Assert.IsFalse(DataRepository.GetAllClients().Contains(cl));

        }

        [TestMethod]
        public void GetClients()
        {

            Assert.IsTrue(DataRepository.GetAllClients() != null);
        }

        [TestMethod]
        public void GetBank()
        {
            Assert.IsTrue(DataRepository.GetAllBanks() != null);
        }
    }
}
