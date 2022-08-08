using Plants_Monthly.Schedules;
using Quartz;

namespace Plants_Monthly.Utils
{
    public static class Scheduler
    {
        public async static void CreateSchedule(IServiceCollection services)
        {
            services.AddQuartz(q => {
                q.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey("awesome job", "awesome group");
                q.AddJob<PushNotificationJob>(jobKey, j => j
                    .WithDescription("my awesome job")
                );

                // Trigger the job on the 25th of each month at 7PM
                q.AddTrigger(t => t
                 .WithIdentity("Simple Trigger")
                 .ForJob(jobKey)
                 .StartNow()
                 .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10)).RepeatForever())
                 //.WithCronSchedule("30 9 12 8 * ?")
                 .WithDescription("my awesome simple trigger")


            );
            });
            services.AddQuartzServer(opts => opts.WaitForJobsToComplete = true);
        }
    }
}
