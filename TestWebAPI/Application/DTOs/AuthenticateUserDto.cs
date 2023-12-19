namespace TestWebAPI.Application.DTOs
{
    public class AuthenticateUserDto
    {
        #region Properties
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        #endregion

        #region Constructors
        public AuthenticateUserDto()
        {
            Login = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Token = string.Empty;
        }
        #endregion
    }
}
