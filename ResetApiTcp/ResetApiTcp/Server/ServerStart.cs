using ResetApiTcp.Cliernt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ResetApiTcp.Server
{
    internal class ServerStart
    {
        private TcpListener listener;
        private bool ExitMainThread = false;
        public bool GetExitMainThread() 
        {
            return ExitMainThread;
        }
        public void SetGetExitMainThread(bool MainThreadOff) 
        {
            ExitMainThread = MainThreadOff;
        }
        private void Init(int startPort) 
        {
            listener = new TcpListener(IPAddress.Any, startPort);
        }
        public ServerStart(int startPort) 
        {
            Init(startPort);
        }
        public void Start() 
        {
            listener.Start();
        }
        public async void Loop() 
        {
            TcpClient client = listener.AcceptTcpClient();
            await Task.Run(() =>
            {
                new ClientThread(client);
                //... thread sleep(500);
            });
        }
        public void Stop() 
        {
            listener.Stop();
        }
    }
}
