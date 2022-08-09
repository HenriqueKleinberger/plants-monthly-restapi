
using Plants_Monthly.DTO;
using Plants_Monthly.Model;
using Plants_Monthly.Utils;

namespace Plants_Monthly.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToOrderDTO(this Order order)
        {
            OrderDTO orderDTO = new OrderDTO()
            {
                Id = order.Id,
                Month = order.Date.Month,
                Year = order.Date.Year,
                Plants = order.Plants.ConvertAll(p => p.ToPlantDTO())
            };

            return orderDTO;
        }

        public static Order ToOrder(this OrderDTO orderDTO, User user, List<Plant> plants, IDateTimeProvider dateTimeProvider)
        {
            DateTime today = dateTimeProvider.GetNow();
            Order order = new Order()
            {
                Id = orderDTO.Id,
                Date = today.AddMonths(today.Date.Day >= 15 ? 1 : 0),
                Plants = plants,
                User = user,
                Status = OrderStatus.Opened
            };

            return order;
        }
    }
}
