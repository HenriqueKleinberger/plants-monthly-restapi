using Plants_Monthly.Model;

namespace Plants_Monthly_Tests.Builders.Model
{
    public class OrderStatusBuilder
    {
        private OrderStatus _orderStatus;

        public string Name = Plants_Monthly.Constants.OrderStatus.OPENED;
        public int Id = 1;

        public OrderStatusBuilder()
        {
            _orderStatus = new OrderStatus();
            _orderStatus.Name = this.Name;
            _orderStatus.Id = this.Id;
        }

        public OrderStatus Build()
        {
            return _orderStatus;
        }
    }
}
