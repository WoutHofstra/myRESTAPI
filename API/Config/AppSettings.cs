namespace myRESTAPI.API.Config
{
    public class AppSettings
    {
        public required string ApiName { get; set; }
        public required int DefaultPageSize { get; set; }
        public required bool EnableSoftDelete { get; set; }
    };

    
}