using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEProjectApp.DataModel;
using SEProjectApp.AppLogic;
using System.Collections.Generic;
using SEProjectApp.AppLogic.Services;

namespace TestProject1
{
    [TestClass]
    public class ApartmentsServiceTests
    {
        [TestMethod]
        public void GetInvoicesWithPriceLowerThan_ShouldReturn_NumberOfInvoices()
        {

            //Arrange
            ApartmentService apService = new ApartmentService(null);

            var apartment1 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Petrica",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> {
                    new Invoice() {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=45,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6         
                    },
                    new Invoice()  {
                        InvoiceId=2,
                        UserName="Ion",
                        ApartmentNo=14,
                        Price=48,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6
                    },
                    new Invoice()  {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=15,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=2
                    },
                    new Invoice()  {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=5,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }
                }

            };

            //Act
            var retValue = apService.GetNoInvoicesWithPriceLowerThan(20,apartment1);

            //Assert
            Assert.AreEqual(2, retValue);
        }

        [TestMethod]
        public void GetNoApartmentsWhereUserName_ShouldReturn_NumberOfApartments()
        {

            //Arrange
            ApartmentService apService = new ApartmentService(null);
            var apartment1 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment2 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment3 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Marcel",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment4 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };

            List<Apartment> list = new List<Apartment>();
            list.Add(apartment1);
            list.Add(apartment2);
            list.Add(apartment3);
            list.Add(apartment4);


            //Act
            var retValue = apService.GetNoApartmentsWhereUserName("Denis",list);

            //Assert
            Assert.AreEqual(3, retValue);
        }

        [TestMethod]
        public void GetNoApartmentsWhereBuildingId_ShouldReturn_NumberOfApartments()
        {

            //Arrange
            ApartmentService apService = new ApartmentService(null);
            var apartment1 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment2 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment3 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Marcel",
                BuildingId = 7,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment4 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 4,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };

            List<Apartment> list = new List<Apartment>();
            list.Add(apartment1);
            list.Add(apartment2);
            list.Add(apartment3);
            list.Add(apartment4);


            //Act
            var retValue = apService.GetNoApartmentsWhereBuildingId(4, list);
            //Assert
            Assert.AreEqual(1, retValue);
        }

        [TestMethod]
        public void GetNoApartmentsWhereBuildingIdAndUserName_ShouldReturn_NumberOfApartments()
        {
            ApartmentService apService = new ApartmentService(null);
            var apartment1 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 7,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment2 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment3 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Marcel",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment4 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };

            List<Apartment> list = new List<Apartment>();
            list.Add(apartment1);
            list.Add(apartment2);
            list.Add(apartment3);
            list.Add(apartment4);


            //Act
            var retValue = apService.GetNoApartmentsWhereBuildingIdAndUserName(3,"Denis",list);
 
            //Assert
            Assert.AreEqual(2, retValue);
        }

        [TestMethod]
        public void GetNoApartmentsWhereApartmentIdAndApartmentNo_ShouldReturn_NumberOfApartments()
        {
            ApartmentService apService = new ApartmentService(null);
            var apartment1 = new Apartment()
            {
                ApartmentId = 1,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 7,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment2 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 2,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment3 = new Apartment()
            {
                ApartmentId = 2,
                ApartmentNo = 3,
                UserId = new System.Guid(),
                UserName = "Marcel",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };
            var apartment4 = new Apartment()
            {
                ApartmentId = 1,
                ApartmentNo = 7,
                UserId = new System.Guid(),
                UserName = "Denis",
                BuildingId = 3,
                BuildingNo = "7",
                Invoices = new List<Invoice> { }

            };

            List<Apartment> list = new List<Apartment>();
            list.Add(apartment1);
            list.Add(apartment2);
            list.Add(apartment3);
            list.Add(apartment4);


            //Act
            var retValue = apService.GetNoApartmentsWhereApartmentNoAndApartmentId(1, 2, list);

            //Assert
            Assert.AreEqual(1, retValue);
        }
    }
}
