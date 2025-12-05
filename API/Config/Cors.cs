namespace myRESTAPI.API.Config
{
    public class Cors
    {
        public List<string> AllowedOrigins { get; set; }
        public List<string> AllowedMethods { get; set; }
        public List<string> AllowedHeaders { get; set; }
    };
}