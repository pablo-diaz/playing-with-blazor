using Newtonsoft.Json;

namespace Utils
{
    public class Configuration
    {
        private class ConfigDTO
        {
            public string baseDomain = "";
        }

        public string BaseDomain { get; }

        private Configuration(string baseDomain)
        {
            BaseDomain = baseDomain;
        }

        public static Configuration CreateFromJSON(string jsonContent)
        {
            var dto = JsonConvert.DeserializeObject<ConfigDTO>(jsonContent);
            return new Configuration(dto.baseDomain);
        }
    }
}