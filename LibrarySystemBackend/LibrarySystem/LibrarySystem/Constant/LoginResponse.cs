namespace LibrarySystem.Constant
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }   
    }
}
