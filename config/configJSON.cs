using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FrostWolfBot.config
{
	public class configJSON
	{
        public string Token { get; set; }
        public string Prefix { get; set; }

        public async Task LerJSON()
        {
            using(StreamReader SR = new StreamReader("config.json"))
            {
                string json = await SR.ReadToEndAsync();
                StruturaJSON data = JsonConvert.DeserializeObject<StruturaJSON>(json);

                this.Token = data.Token;
                this.Prefix = data.Prefix;
            }
        }
    }

    internal sealed class StruturaJSON
    {
        public string Token { get; set; }
        public string Prefix { get; set; }
        
    }
}
