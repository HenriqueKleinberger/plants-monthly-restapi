
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.Mappers
{
    public static class PushTokenMapper
    {
        public static PushTokenDTO ToPushTokenDTO(this PushToken pushToken)
        {
            PushTokenDTO pushTokenDTO = new PushTokenDTO()
            {
                Token = pushToken.Token
            };

            return pushTokenDTO;
        }
    }
}
