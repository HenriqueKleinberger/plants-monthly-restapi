
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
                Date = order.Date,
                PlantsId = order.Plants.ConvertAll(p => p.Id)
            };

            return orderDTO;
        }

        public static Order ToOrder(this OrderDTO orderDTO, User user, List<Plant> plants)
        {
            Order order = new Order()
            {
                Id = orderDTO.Id,
                Date = orderDTO.Date,
                Plants = plants,
                User = user
            };

            return order;
        }
    }
}
