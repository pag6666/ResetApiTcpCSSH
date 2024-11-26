using Newtonsoft.Json;
using ResetApiTcp.patterns;
using System.Net.Sockets;
using System.Text;

namespace ResetApiTcp.Cliernt
{
    internal class ClientThread
    {
        private TcpClient Client;
        public ClientThread(TcpClient Client) 
        {
            this.Client = Client;
            NetworkStream stream = Client.GetStream();
            StreamMessage.StreamReader read = new StreamMessage.StreamReader();
            StreamMessage.StreamWriter write = new StreamMessage.StreamWriter();
            DataTransportationFormat GET = new DataTransportationFormat();
            DataTransportationFormat SET = new DataTransportationFormat();
            try
            {
                byte[] bufferRead = new byte[128]; 
                if (read.ReadBytes(stream, ref bufferRead)) {
                    GET = JsonConvert.DeserializeObject<DataTransportationFormat>(Encoding.UTF8.GetString(bufferRead));
                }
            }
            catch 
            {
                Console.WriteLine("Error read format");
            }
            SET = Update(GET);
            try
            {
                byte[] bufferWrite = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(SET));
                write.WriteBytes(stream, bufferWrite);
            }
            catch
            {
                Console.WriteLine("Error write format");
            }
            

        }
        private DataTransportationFormat Update(DataTransportationFormat GET) 
        {
            DataTransportationFormat SET = new DataTransportationFormat();
            SET.NameUser = Environment.MachineName;
            SET.Request = GET.Request;
            SET.DataFormat = GET.DataFormat;

            //read data and write data
           

            return SET;
        }
        
    }
}
