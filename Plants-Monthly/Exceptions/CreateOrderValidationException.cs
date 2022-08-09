namespace Plants_Monthly.Exceptions
{
    public class CreateOrderValidationException : Exception
    {
        public CreateOrderValidationException(string message)
            : base(message)
        {
        }
    }
}
