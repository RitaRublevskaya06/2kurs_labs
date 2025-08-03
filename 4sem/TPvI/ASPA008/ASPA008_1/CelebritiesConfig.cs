namespace ASPA008_1
{
    public class CelebritiesConfig
    {
        public string PhotosRequestPath { get; set; }
        public string PhotosFolder { get; set; }
        public string ConnectionString { get; set; }
        public string ISO3166alpha2Path { get; set; }
        public CelebritiesConfig() {
            this.PhotosRequestPath = "/Photos";
            this.PhotosFolder = "/Photos";
            this.ConnectionString = "Data Source=LENOVO-HOME\\SQLEXPESS1;Database=LifeEventsOfCelebrities;Trusted_Connection=True;User Id=sa;Password=sa;TrustServerCertificate=True;";
            this.ISO3166alpha2Path = "/CountryCodes";
        }
    }
}