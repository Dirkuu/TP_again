using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
namespace ModelUTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void CreationOfWorker()
        {
            Worker testSubject = new Worker
            {
                FirstName = "Test_Name",
                LastName = "Test_LastName",
                ID = 1
            };
            Assert.AreSame(testSubject.FirstName, "Test_Name");
            Assert.AreSame(testSubject.LastName, "Test_LastName");
        }
    }
}
