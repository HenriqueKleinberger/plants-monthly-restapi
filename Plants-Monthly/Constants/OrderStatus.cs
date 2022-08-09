using Microsoft.AspNetCore.Mvc;
using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.DTO;

namespace Plants_Monthly.Constants
{
    public class OrderStatus
    {
        public const String OPENED = "Opened";
        public const String CANCELED = "Canceled";
        public const String TO_DELIVERY = "To Delivery";
        public const String DELIVERED = "Delivered";
    }
}