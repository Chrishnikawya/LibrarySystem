namespace LibrarySystem.Services
{
    public class AuthorServiceClass : AuthorService
    {
        public string GetHello(string name)
        {
            return $"hello,{name}";
        }
    }
}
