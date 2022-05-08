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
    public class ReagentControllersTests
    {



        [TestMethod()]
        public void Test_ReagentCreate()
        {
            var options = new DbContextOptionsBuilder<Chemical_ManagementContext>()
                .UseInMemoryDatabase(databaseName: "ReagentListDatabase")
                .Options;
            var context = new Chemical_ManagementContext(options);
            
            context.Reagent.Add(new Reagent { ReagentID = 1, ReagentName = "HCL", LotNumber = 1002 });
            context.Reagent.Add(new Reagent { ReagentID = 2, ReagentName = "ABC", LotNumber = 100 });

            context.SaveChanges();

            ReagentsController reagent_test = new ReagentsController(context);

            Reagent r = new Reagent() { ReagentID = 100, ReagentName = "HCL", LotNumber = 1002 };
            
            

            var result = reagent_test.Create(r) ;
            //Reagent? creaResult = (Reagent)result.ViewData.Model;

            Assert.IsNotNull(result);
            

            Assert.IsInstanceOfType(result, typeof(AcceptedResult));
        }

        /*
        [TestMethod()]
        public void Details()
        {

            var logger = Mock.Of<ILogger<ReagentsController>>();

            var controller = new ReagentsController(logger);


            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod()]
        public void Create()
        {

            var logger = Mock.Of<ILogger<ReagentsController>>();

            var controller = new ReagentsController(logger);


            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void Edit()
        {

            var logger = Mock.Of<ILogger<ReagentsController>>();

            var controller = new ReagentsController(logger);


            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void Delete()
        {

            var logger = Mock.Of<ILogger<ReagentsController>>();

            var controller = new ReagentsController(logger);


            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        */
    }
}
