using Plants_Monthly.Schedules;
using Quartz;

namespace Plants_Monthly.Utils
{
    public static class Scheduler
    {
        public async static void CreateSchedule(IServiceCollection services)
        {
            string notificationJob = "push notification job";
            services.AddQuartz(q => {
                q.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey(notificationJob, "push notification group");
                q.AddJob<PushNotificationJob>(jobKey, j => j
                    .WithDescription(notificationJob)
                );

                // Trigger the job on the 25th of each month at 7PM
                q.AddTrigger(t => t
                    .WithIdentity("Push Notification Trigger")
                    .ForJob(jobKey)
                    .StartNow()
                    .WithCronSchedule("0 0 19 25 * ?")
                    .WithDescription("Push Notification Trigger")
                );
            });
            services.AddQuartzServer(opts => opts.WaitForJobsToComplete = true);
        }
    }
}
