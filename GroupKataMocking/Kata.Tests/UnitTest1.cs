using System;
using System.Collections.Generic;
using GroupKataMocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kata.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]        
        public void AProductWithAValidExpirationDateShouldSave()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Save(It.IsAny<Product>()));

            Product p = new Product() { Id = 1, ExpirationDate = DateTime.Now.AddDays(1), Name = "productOne" };

            ProductPersister sut = new ProductPersister(mock.Object);
            sut.Save(p);

            mock.Verify(x => x.Save(p), Times.Once);

        }




        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AProductWithAnInvalidExpirationDateShouldThrowException()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Save(It.IsAny<Product>()));

            Product p = new Product() { Id = 1, ExpirationDate = DateTime.Now.AddDays(-1), Name = "productOne" };

            ProductPersister sut = new ProductPersister(mock.Object);
            sut.Save(p);
        }



        //Below this are are things I have added since the KATA
        //--------------------------------------------------------------//

        [TestMethod]
        public void VerifyListOfAllProductsIsReturned()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Find());

            ProductPersister sut = new ProductPersister(mock.Object);

            sut.Find();

            mock.Verify(x => x.Find(), Times.Once);

        }

        public List<Product> GetMockListOfProducts()
        {
            var mockList = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "ProductOne",
                    ExpirationDate = DateTime.Now.AddYears(1)
                },
                new Product()
                {
                      Id = 2,
                    Name = "ProductTwo",
                    ExpirationDate = DateTime.Now.AddYears(-1)

                }

            };

            return mockList;


        }
        

    }
}
