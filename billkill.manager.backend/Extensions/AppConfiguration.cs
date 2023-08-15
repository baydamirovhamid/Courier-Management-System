namespace billkill.manager.backend.Extensions
{
    public class AppConfiguration
    {
        private readonly string _jwtSecret = string.Empty;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();

            _jwtSecret = root.GetSection("ApplicationSettings").GetSection("jwt_secret").Value;
        }
        public string JWTSecret
        {
            get => _jwtSecret;
        }
    }
}
