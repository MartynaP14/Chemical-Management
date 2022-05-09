using Chemical_Management.Controllers;
using Chemical_Management.Data;
using Chemical_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.ComponentModel.DataAnnotations;
namespace Chemical_ManagementTests.Controllers
{
    [TestClass]
    public class SupplyControllersTest
    {
        [TestMethod()]
        public void Test_SupplyCreate()
        {
            var options = new DbContextOptionsBuilder<Chemical_ManagementContext>()


                .UseInMemoryDatabase(databaseName: "SupplyListDatabase")
                .Options;
            var context = new Chemical_ManagementContext(options);


            context.Supply.Add(new Supply { SupplyId = 1, ReagentStock = 10 });
            
            context.SaveChanges();


            SuppliesController supply_test = new SuppliesController(context);
            Supply Supplytestobject = new Supply() { SupplyId = 1, ReagentStock = 10 };

            var SupplyControllerCreate = supply_test.Create(Supplytestobject);


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(SupplyControllerCreate);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(SupplyControllerCreate, typeof(AcceptedResult));
            //I picked ms unit test assert instead of xunit
        }
    }
}