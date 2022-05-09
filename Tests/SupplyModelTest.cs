using Chemical_Management.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chemical_Management.Tests
{
    [TestClass()]
    public class SupplyModelTest
    {

        [TestMethod()]
        public void CreateSupplyInstance()
        {
            Supply TestSupply = new Supply() { SupplyId = 1, ReagentStock=10 };
            
            Assert.IsInstanceOfType(TestSupply, typeof(Lab));

        }

        [TestMethod()]
        public void SupplyNameTest()
        {
            Supply TestSupply = new Supply() { SupplyId = 1, ReagentStock = 10 };
            Assert.AreEqual(10, TestSupply.ReagentStock);
        }

        [TestMethod()]
        public void SupplyIDTest()
        {
            Supply TestSupply = new Supply() { SupplyId = 1, ReagentStock = 10 };
            Assert.AreEqual(1, TestSupply.SupplyId);
        }

        
    }
}

