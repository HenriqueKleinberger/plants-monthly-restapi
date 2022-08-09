using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.BLL;
using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DAL;
using Plants_Monthly.Schedules;

namespace Plants_Monthly.Utils
{
    public static class DependencyInjector
    {
        public static void InjectCommonDependencies(IServiceCollection services)
        {
            services.AddScoped<ICategoryBLL, CategoryBLL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<IOrderBLL, OrderBLL>();
            services.AddScoped<IOrderDAL, OrderDAL>();
            services.AddScoped<IPlantDAL, PlantDAL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IPushTokenDAL, PushTokenDAL>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IOrderStatusDAL, OrderStatusDAL>();
            services.AddScoped<PushNotificationJob>();
        }
    }
}
