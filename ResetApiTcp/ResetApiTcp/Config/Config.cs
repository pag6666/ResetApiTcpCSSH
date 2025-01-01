using Newtonsoft.Json;
using ResetApiTcp.Config.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResetApiTcp.Config
{
    public class Config
    {
        private p_config _config;
        public Config(string file_path) {
            if (file_path != string.Empty) 
            {
                _config = JsonConvert.DeserializeObject<p_config>(file_path);
            }
        }
        public string GetName() 
        {
            if (_config.name != string.Empty) {
                return _config.name;
            }
            return "\0";
        }
        public int GetPort() 
        {
            if (_config.port != 0) {
                return _config.port;
            }
            return -1;
        }
    }
}
