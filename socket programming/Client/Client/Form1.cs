using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {

        static Socket sock;

        //IPAddress serverIP = IPAddress.Parse("117.17.157.125");
        IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        int serverPort = 1234;

        public Form1()
        {
            InitializeComponent();

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(serverIP, serverPort);

            try {
                sock.Connect(localEndPoint);
            }
            catch (Exception) {
                Console.Write("unable to connect");
                
            }

            byte[] data = Encoding.ASCII.GetBytes("hi heni");

            sock.Send(data);

            sock.Close();
        }
    }
}
