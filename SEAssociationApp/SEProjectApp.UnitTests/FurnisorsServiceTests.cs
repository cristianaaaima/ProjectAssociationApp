using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEProjectApp.AppLogic.Services;
using SEProjectApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.UnitTests
{
    [TestClass]
    public class FurnisorsServiceTests
    {
        [TestMethod]
        public void GetNoFurnisorsWhereFurnisorName_ShouldReturn_NoOfFurnisors()
        {

            //Arrange
            FurnisorService service = new FurnisorService(null);
            List<Furnisor> list = new List<Furnisor> {
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Distrigaz",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    }
            };

            //Act
            var res = service.GetNoFurnisorsWhereFurnisorName("Enel", list);

            //Assert
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void GetNameWhereFurnisorId_ShouldReturn_FurnisorName()
        {

            //Arrange
            FurnisorService service = new FurnisorService(null);
            List<Furnisor> list = new List<Furnisor> {
                    new Furnisor() {
                        FurnisorId=1,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Distrigaz",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=5,
                        FurnisorName="CompaniaDeApa",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    }
            };

            //Act
            var res = service.GetNameWhereFurnisorId(3, list);

            //Assert
            Assert.AreEqual("Distrigaz", res);
        }

        [TestMethod]
        public void GetNameWhereStartDate_ShouldReturn_FurnisorName()
        {

            //Arrange
            FurnisorService service = new FurnisorService(null);
            List<Furnisor> list = new List<Furnisor> {
                    new Furnisor() {
                        FurnisorId=1,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2015, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Distrigaz",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=5,
                        FurnisorName="CompaniaDeApa",
                        StartDate= new DateTime(2014, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    }
            };

            //Act
            var res = service.GetNameWhereStartDate(new DateTime(2015, 6, 1, 12, 32, 30), list);

            //Assert
            Assert.AreEqual("Enel", res);
        }

        [TestMethod]
        public void GetIdWhereDueDate_ShouldReturn_FurnisorId()
        {

            //Arrange
            FurnisorService service = new FurnisorService(null);
            List<Furnisor> list = new List<Furnisor> {
                    new Furnisor() {
                        FurnisorId=1,
                        FurnisorName="Distrigaz",
                        StartDate= new DateTime(2015, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=5,
                        FurnisorName="CompaniaDeApa",
                        StartDate= new DateTime(2014, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2018, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    }
            };

            //Act
            var res = service.GetIdWhereDueDate(new DateTime(2018, 6, 1, 12, 32, 30), list);

            //Assert
            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void GetNoFurnisorsWhereStartDateLessThan_ShouldReturn_NoOfFurnisors()
        {

            //Arrange
            FurnisorService service = new FurnisorService(null);
            List<Furnisor> list = new List<Furnisor> {
                    new Furnisor() {
                        FurnisorId=1,
                        FurnisorName="Enel",
                        StartDate= new DateTime(2019, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=3,
                        FurnisorName="Distrigaz",
                        StartDate= new DateTime(2013, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2014, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    },
                    new Furnisor() {
                        FurnisorId=5,
                        FurnisorName="CompaniaDeApa",
                        StartDate= new DateTime(2014, 6, 1, 12, 32, 30),
                        DueDate=new DateTime(2018, 6, 1, 12, 32, 30),
                        Invoices=new List<Invoice> { }
                    }
            };

            //Act
            var res = service.GetNoFurnisorsWhereStartDateLessThan(new DateTime(2018, 6, 1, 12, 32, 30), list);

            //Assert
            Assert.AreEqual(2, res);
        }
    }
}

