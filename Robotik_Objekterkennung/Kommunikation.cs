using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Robotik_Objekterkennung
{
    class Kommunikation
    {
        private int listenPort;
        private UdpClient udp = null; // socket
        private IPEndPoint ep = null; // ip end point    
        private Socket socket = null;
        private IPAddress broadcast;
        private int port;

        // Konstruktor für den Sender - UDP oder TCP Protokoll
        public Kommunikation(String ipaddress, int port, string protocol)
        {
            this.broadcast = IPAddress.Parse(ipaddress);
            this.port = port;
            ProtocolType type = 0;
            if (protocol == "udp")
            {
                type = ProtocolType.Udp;
            }
            else if (protocol == "tcp")
            {
                type = ProtocolType.Tcp;
            }

            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);
            this.ep = new IPEndPoint(this.broadcast, this.port);              
        }

        // Nachricht senden
        public void sendMsg(string msg)
        {
            msg = (char)126 + " " + msg; // char 126 = size of message
            byte[] sendBuffer = Encoding.ASCII.GetBytes(msg);
            socket.SendTo(sendBuffer, ep);
        }

        // Konstruktor für den Empfänger - UDP Protokoll
        public Kommunikation(int port)
        {
            this.port = port;
            udp = new UdpClient(port);
            ep = new IPEndPoint(IPAddress.Any, listenPort);
        }

        // Nachricht erhalten
        public string recMsg()
        {
            try
            {
                byte[] bytes = udp.Receive(ref ep);
                return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                return "";
            }   
        }

        // Verbindung schließen
        public void close()
        {
            if (udp != null)
            {
                udp.Close();
            }
            else if (socket != null)
            {
                socket.Close();
            }
        }
    }
}
