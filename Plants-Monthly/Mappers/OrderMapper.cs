
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

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

        public static Order ToOrder(this OrderDTO orderDTO, User user, List<Plant> plants)
        {
            Order order = new Order()
            {
                Id = orderDTO.Id,
                //Date = orderDTO.Date,
                Plants = plants,
                User = user,
                Status = OrderStatus.Opened
            };

            return order;
        }
    }
}
