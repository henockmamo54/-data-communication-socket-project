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

namespace server
{
    public partial class Form1 : Form
    {
        static byte[] Buffer { get; set; }
        static Socket sock;
        Socket acceptedSock;
        public Form1()
        {
            InitializeComponent();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(0,1234));
            sock.Listen(100);

            acceptedSock = sock.Accept();
            Buffer = new byte[acceptedSock.SendBufferSize];
            int bytesRead = acceptedSock.Receive(Buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++) {
                formatted[i] = Buffer[i];
            }

            string strData = Encoding.ASCII.GetString(formatted);
            Console.Write(strData + "\r\n");
            Console.Read();
            sock.Close();
            acceptedSock.Close();

        }
    }
}
