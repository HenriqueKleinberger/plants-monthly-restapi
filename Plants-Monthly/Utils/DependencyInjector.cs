using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.BLL;
using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DAL;

namespace Plants_Monthly.Utils
{
    public static class DependencyInjector
    {
        public static void InjectCommonDependencies(IServiceCollection services)
        {
            services.AddScoped<ICategoryBLL, CategoryBLL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
        }
    }
}
