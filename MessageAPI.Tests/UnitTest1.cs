using MessageAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MessageAPI.Tests
{
    public class Tests
    {
        List<IMessageLogger> list;

        [SetUp]
        public void Setup()
        {
            var mockRepoConsole = new Mock<IMessageLogger>();
            mockRepoConsole.Setup(repo => repo.WriteMessage())
                .Returns("I wrote to console");
            mockRepoConsole.Setup(repo => repo.name)
                .Returns("Console");

            var mockRepoDB = new Mock<IMessageLogger>();
            mockRepoDB.Setup(repo => repo.WriteMessage())
                .Returns("I wrote to DB");
            mockRepoDB.Setup(repo => repo.name)
                .Returns("DB");

            list = new List<IMessageLogger>() { mockRepoConsole.Object, mockRepoDB.Object };

        }

        [Test]
        public void TestConsole()
        {
            //Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["MessageLoggerType"]).Returns("Console");

            var controller = new MessageController(configuration.Object, list);
            // Act
            var data = controller.Get();

            //Assert
            Assert.AreEqual("I wrote to console",data);

        }

        [Test]
        public void TestDB()
        {
            //Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["MessageLoggerType"]).Returns("DB");

            var controller = new MessageController(configuration.Object, list);
            // Act
            var data = controller.Get();

            //Assert
            Assert.AreEqual("I wrote to DB", data);

        }
    }
}