using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ResetApiTcp.StreamMessage
{
    internal class StreamReader
    {
        public bool ReadBytes(Stream stream, ref byte[] getbytes) 
        {
            bool r = false;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                }
                getbytes = memoryStream.ToArray();
                r = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"error read = %$ {e.Message}");
            }
            return r;
        }
    }
}
