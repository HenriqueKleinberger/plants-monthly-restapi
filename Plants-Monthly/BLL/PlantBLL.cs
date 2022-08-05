using Plants_Monthly.DAL.Interfaces;

namespace weiss_cinema_restapi.BLL
{
    public class PlantBLL : IPlantBLL
    {
        private readonly ILogger<PlantBLL> _logger;

        public PlantBLL(ILogger<PlantBLL> logger)
        {
            _logger = logger;
        }
    }

}
