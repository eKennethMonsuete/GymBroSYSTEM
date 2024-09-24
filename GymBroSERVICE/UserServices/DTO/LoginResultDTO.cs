namespace GymBroSERVICE.UserServices.DTO
{
    public class LoginResultDTO
    {
        public string AccessToken { get; set; }

        public DateTime ExpiratedAt { get; set; }
    }
}
