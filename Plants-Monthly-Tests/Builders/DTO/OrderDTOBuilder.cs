using Plants_Monthly.DTO;
using System;
using System.Collections.Generic;

namespace Plants_Monthly_Tests.Builders.DTO
{
    public class OrderDTOBuilder
    {
        private OrderDTO _orderDTO;

        public List<PlantDTO> PlantsDTO = new List<PlantDTO>()
        {
            new PlantDTOBuilder().Build(),
            new PlantDTOBuilder().WithId("Id2").WithImageId("ImageId2").WithName("Name2").Build()
        };

        public OrderDTOBuilder()
        {

            Random random = new Random();
            _orderDTO = new OrderDTO();
            _orderDTO.Id = random.Next(1, 10);
            _orderDTO.Month = random.Next(1, 12);
            _orderDTO.Year = random.Next(2020, 2024);
            _orderDTO.Plants = this.PlantsDTO;
        }

        public OrderDTO Build()
        {
            return _orderDTO;
        }
    }
}
