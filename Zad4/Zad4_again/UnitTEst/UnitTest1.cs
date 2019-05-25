using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatasLayer;
using System.Linq;

namespace UnitTEst
{
    [TestClass]
    public class UnitTest1
    {
      
        [TestMethod]
        public void AddToData()
        {
            DataRepository.init();
            int sizeBeforeAdd = DataRepository.GetAllClients().Count;
            var cl = new Client
            {
                firstName = "Test",
                lastName = "Testinglastname",
            };
            DataRepository.CreateClient(cl);
            Assert.AreNotEqual(DataRepository.GetAllClients().Count, sizeBeforeAdd);
        }

        [TestMethod]
        public void UpdateTest()
        {

            var cl = new Client
            {
                firstName = "Test",
                lastName = "Testinglastname",
            };
            DataRepository.CreateClient(cl);

            cl.firstName = "modified";
            DataRepository.UpdateClient(cl);
            Assert.IsTrue(DataRepository.GetAllClients().Contains(cl));

        }
    }
}
