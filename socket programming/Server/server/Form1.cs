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

        //IPAddress myIP = IPAddress.Parse("117.17.157.125");
        IPAddress myIP = IPAddress.Parse("127.0.0.1");
        int myPort = 1234;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(myIP, myPort));

            txtbox_serverMessage.Text += "Ther server is started at IP Adress: " + myIP + " Port : " + myPort + "\n";
            txtbox_serverMessage.Text += "The server is listening ... \n";

            this.Refresh();
            this.Invalidate();

            sock.Listen(100);

            acceptedSock = sock.Accept();

            txtbox_serverMessage.Text += "Client is connected\n";

            Buffer = new byte[acceptedSock.SendBufferSize];
            int bytesRead = acceptedSock.Receive(Buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
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
