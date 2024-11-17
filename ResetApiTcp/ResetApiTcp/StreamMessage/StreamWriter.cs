using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResetApiTcp.StreamMessage
{
    internal class StreamWriter
    {
        public void WriteBytes(Stream stream, byte[] writeBuffer) 
        {
            try
            {
                stream.Write(writeBuffer, 0, writeBuffer.Length);
                stream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine($"error write = $% {e.Message}");
            }
        }
    }
}
