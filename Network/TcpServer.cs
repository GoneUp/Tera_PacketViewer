using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using Utils;

namespace Network
{
    public class TcpServer
    {
        protected string BindAddress;
        protected int BindPort;
        protected int MaxConnections;
        protected Dictionary<string, long> ConnectionsTime;

        public IScsServer Server;

        public TcpServer(string bindAddress, int bindPort, int maxConnections)
        {
            BindAddress = bindAddress;
            BindPort = bindPort;
            MaxConnections = maxConnections;
            ConnectionsTime = new Dictionary<string, long>();
        }

        public void BeginListening()
        {
            Log.Info("Start TcpServer at {0}:{1}...", BindAddress, BindPort);
            Server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(BindAddress, BindPort));
            Server.Start();

            Server.ClientConnected += OnConnected;
            Server.ClientDisconnected += OnDisconnected;
        }

        public void ShutdownServer()
        {
            Log.Info("Shutdown TcpServer...");
            Server.Stop();
        }

        protected void OnConnected(object sender, ServerClientEventArgs e)
        {
// ReSharper disable StringIndexOfIsCultureSpecific.1
            string ip = Regex.Match(e.Client.RemoteEndPoint.ToString(), "([0-9]+).([0-9]+).([0-9]+).([0-9]+)").Value;
// ReSharper restore StringIndexOfIsCultureSpecific.1

            if (ip == "159.253.18.161")
                return;

            Log.Info("Client connected!");

            if (ConnectionsTime.ContainsKey(ip))
            {
                if (Funcs.GetCurrentMilliseconds() - ConnectionsTime[ip] < 2000)
                {
                    Process.Start("cmd",
                                  "/c netsh advfirewall firewall add rule name=\"AutoBAN (" + ip +
                                  ")\" protocol=TCP dir=in remoteip=" + ip + " action=block");

                    ConnectionsTime.Remove(ip);

                    Log.Info("TcpServer: FloodAttack prevent! Ip " + ip + " added to firewall");
                    return;
                }
                ConnectionsTime[ip] = Funcs.GetCurrentMilliseconds();
            }
            else
                ConnectionsTime.Add(ip, Funcs.GetCurrentMilliseconds());

            new Connection(e.Client);
        }

        protected void OnDisconnected(object sender, ServerClientEventArgs e)
        {
            Log.Info("Client disconnected!");
        }
    }
}