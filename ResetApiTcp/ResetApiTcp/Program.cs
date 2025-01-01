using System;
using System.Net;
namespace ResetApiTcp 
{
    class Programm 
    {
        private static string file_config = "config.json";
        static void Main() 
        {
            Config.Config configFile = new Config.Config(file_config);
            Server.ServerStart objectServerSatrt = new Server.ServerStart(configFile.GetPort());
            objectServerSatrt.Start();
            while (!objectServerSatrt.GetExitMainThread()) 
            {
                objectServerSatrt.Loop();
            }
            objectServerSatrt.Stop();
        }
    }
}