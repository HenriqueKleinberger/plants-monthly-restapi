using Expo.Server.Client;
using Expo.Server.Models;
using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Quartz;

namespace Plants_Monthly.Schedules
{
	public class PushNotificationJob : IJob
	{
        private readonly IPushTokenDAL _pushTokenDAL;
        private readonly IOrderDAL _orderDAL;

        public PushNotificationJob(IPushTokenDAL pushTokenDAL)
        {
            _pushTokenDAL = pushTokenDAL;
        }

        public async Task Execute(IJobExecutionContext context)
		{
            List<PushTokenDTO> tokens = await _pushTokenDAL.GetPushTokensAsync();
            var expoSDKClient = new PushApiClient();
            var pushTicketReq = new PushTicketRequest()
            {
                PushTo = tokens.ConvertAll(t => t.Token),
                PushBadgeCount = 7,
                PushTitle= "Your monthly order",
                PushBody = "Please select the plants for your next shipment"
            };
            var result = await expoSDKClient.PushSendAsync(pushTicketReq);

            if (result?.PushTicketErrors?.Count() > 0)
            {
                foreach (var error in result.PushTicketErrors)
                {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }
        }
	}
}
