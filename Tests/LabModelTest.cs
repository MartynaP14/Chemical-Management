using Chemical_Management.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chemical_Management.Tests
{
    [TestClass()]
    public class LabModelTest
    {

        [TestMethod()]
        public void CreateLabInstance()
        {
            Lab TestLab = new Lab() { LabID = 1, LabName = "Lab A", LabSite = "Site One" };
            Assert.IsInstanceOfType(TestLab, typeof(Lab));
           
        }

        [TestMethod()]
        public void LabNameTest()
        {
            Lab TestLab = new Lab() { LabID = 1, LabName = "Lab A", LabSite = "Site One" };
            Assert.AreEqual("Lab A", TestLab.LabName);
        }

        [TestMethod()]
        public void LabIDTest()
        {
            Lab TestLab = new Lab() { LabID = 1, LabName = "Lab A", LabSite = "Site One" };
            Assert.AreEqual(1, TestLab.LabID);
        }

        [TestMethod()]
        public void LabSiteTest()
        {
            Lab TestLab = new Lab() { LabID = 1, LabName = "Lab A", LabSite = "Site One" };
            Assert.AreEqual("Site One", TestLab.LabSite);
        }
    }
}
