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
    public class LabControllersTest
    {
        [TestMethod()]
        public void Test_LabCreate()
        {
            var options = new DbContextOptionsBuilder<Chemical_ManagementContext>()
                
                
                .UseInMemoryDatabase(databaseName: "LabListDatabase")
                .Options;
            var context = new Chemical_ManagementContext(options);


            context.Lab.Add(new Lab { LabID = 1, LabSite="Site 1", LabName = "Lab One"});
            context.Lab.Add(new Lab { LabID = 2, LabSite = "S-4", LabName = "Area 51" });
            context.SaveChanges();


            LabsController lab_test = new LabsController(context);
            Lab labtestobject = new Lab() { LabID = 2, LabSite = "S-4", LabName = "Area 51" };

            var ControllerCreate = lab_test.Create(labtestobject);
            

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(ControllerCreate);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ControllerCreate, typeof(AcceptedResult));
        }
    }
}

