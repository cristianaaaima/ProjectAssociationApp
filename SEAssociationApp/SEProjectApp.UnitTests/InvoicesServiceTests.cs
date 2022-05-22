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
    public class InvoicesServiceTests
    {

        [TestMethod]
        public void GetNoInvoicesWhereStatus_ShouldReturn_NoOfInvoices()
        {
            //Arrange
            InvoiceService service = new InvoiceService(null);
            List<Invoice> invs = new List<Invoice> {
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
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }

            };
            //Act
            var res = service.GetNoInvoicesWhereStatus("Paid", invs);
            //Assert
            Assert.AreEqual(3, res);

        }

        [TestMethod]
        public void GetUserNameWhereInvoiceId_ShouldReturn_UserName()
        {
            InvoiceService service = new InvoiceService(null);
            List<Invoice> invs = new List<Invoice> {
                    new Invoice() {
                        InvoiceId=5,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=45,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6
                    },
                    new Invoice()  {
                        InvoiceId=7,
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
                        InvoiceId=8,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=5,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }

            };
            var res = service.GetUserNameWhereInvoiceId(7, invs);

            Assert.AreEqual(res, "Ion");

        }

        [TestMethod]
        public void GetNoInvoicesWithPriceLowerThan_ShouldReturn_NoOfInvoices()
        {
            InvoiceService service = new InvoiceService(null);
            List<Invoice> invs = new List<Invoice> {
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
                        Price=414,
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
                        Price=125,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }

            };
            var res = service.GetNoInvoicesWithPriceLowerThan(100, invs);

            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void GetNoInvoicesWithApartmentIdAndStatus_ShouldReturn_NoOfInvoices()
        {
            InvoiceService service = new InvoiceService(null);
            List<Invoice> invs = new List<Invoice> {
                    new Invoice() {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=45,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6
                    },
                    new Invoice()  {
                        InvoiceId=2,
                        UserName="Ion",
                        ApartmentNo=14,
                        Price=414,
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
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=7
                    },
                    new Invoice()  {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=125,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }

            };
            var res = service.GetNoInvoicesWithApartmentIdAndStatus(6, "Unpaid", invs);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void GetApartmentIdWhereUserNameIs_ShouldReturn_ApartmentId()
        {
            InvoiceService service = new InvoiceService(null);
            List<Invoice> invs = new List<Invoice> {
                    new Invoice() {
                        InvoiceId=1,
                        UserName="Mihai",
                        ApartmentNo=15,
                        Price=45,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6
                    },
                    new Invoice()  {
                        InvoiceId=2,
                        UserName="Ion",
                        ApartmentNo=14,
                        Price=414,
                        Status="Paid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=6
                    },
                    new Invoice()  {
                        InvoiceId=1,
                        UserName="Ovidiu",
                        ApartmentNo=15,
                        Price=15,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=7
                    },
                    new Invoice()  {
                        InvoiceId=1,
                        UserName="Marcel",
                        ApartmentNo=15,
                        Price=125,
                        Status="Unpaid",
                        DueDate=System.DateTime.Now,
                        Description="Nothing",
                        ApartmentId=8
                    }

            };
            var res = service.GetApartmentIdWhereUserNameIs("Marcel", invs);

            Assert.AreEqual(8, res);
        }


    }
}