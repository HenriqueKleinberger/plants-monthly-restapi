namespace Plants_Monthly.Exceptions
{
    public class OrderStatusNotFoundException : Exception
    {
        public OrderStatusNotFoundException(string message)
            : base(message)
        {
        }
    }
}
