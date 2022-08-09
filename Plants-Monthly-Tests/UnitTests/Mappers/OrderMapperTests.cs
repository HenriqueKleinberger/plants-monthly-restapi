using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Plants_Monthly.Utils;
using Plants_Monthly_Tests.Builders.DTO;
using System;
using System.Collections.Generic;

namespace Plants_Monthly_Tests.UnitTests.Mappers
{
    [TestClass]
    public class OrderMapperTests
    {
        [TestMethod]
        public void WhenDayOfMonthIsAfterThan15_ShouldCreateOrderForNextMonth()
        {
            OrderDTO orderDTO = new OrderDTOBuilder().Build();
            int month = 8;
            Mock<IDateTimeProvider> dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.GetNow()).Returns(new DateTime(2020, month, 15));

            Order order = orderDTO.ToOrder(new User(), new List<Plant>(), dateTimeMock.Object);

            Assert.AreEqual(month + 1, order.Date.Month);
        }

        [TestMethod]
        public void WhenDayOfMonthIsBefore15_ShouldCreateOrderForThisMonth()
        {
            OrderDTO orderDTO = new OrderDTOBuilder().Build();
            int month = 8;
            Mock<IDateTimeProvider> dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.GetNow()).Returns(new DateTime(2020, month, 14));

            Order order = orderDTO.ToOrder(new User(), new List<Plant>(), dateTimeMock.Object);

            Assert.AreEqual(month, order.Date.Month);
        }
    }
}