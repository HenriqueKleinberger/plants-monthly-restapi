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

        public PushNotificationJob(IPushTokenDAL pushTokenDAL)
        {
            _pushTokenDAL = pushTokenDAL;
        }

        public async Task Execute(IJobExecutionContext context)
		{
            Console.WriteLine("metodo");
        }
	}
}
