using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Plants_Monthly.Utils;
using Plants_Monthly_Tests.Builders.DTO;
using Plants_Monthly_Tests.Builders.Model;
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
            OrderStatus orderStatus = new OrderStatusBuilder().Build();

            Order order = orderDTO.ToOrder(new User(), new List<Plant>(), dateTimeMock.Object, orderStatus);

            Assert.AreEqual(month + 1, order.Date.Month);
        }

        [TestMethod]
        public void WhenDayOfMonthIsBefore15_ShouldCreateOrderForThisMonth()
        {
            OrderDTO orderDTO = new OrderDTOBuilder().Build();
            int month = 8;
            Mock<IDateTimeProvider> dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.GetNow()).Returns(new DateTime(2020, month, 14));
            OrderStatus orderStatus = new OrderStatusBuilder().Build();

            Order order = orderDTO.ToOrder(new User(), new List<Plant>(), dateTimeMock.Object, orderStatus);

            Assert.AreEqual(month, order.Date.Month);
        }
    }
}