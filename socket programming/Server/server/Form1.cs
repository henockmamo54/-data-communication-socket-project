using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        static byte[] Buffer { get; set; }
        static Socket sock;
        Socket acceptedSock;
        string conversation="";

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

            Thread t = new Thread(listenForMessage);
            t.Start();

        }

        private void listenForMessage()
        {
            while (true)
            {
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
                
                conversation += "Client: " + strData + Environment.NewLine;
                this.Invoke(new MethodInvoker(delegate {
                    txt_conversationHistory.Text = conversation;
                }));
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(txt_msg.Text);
            acceptedSock.Send(data);

            conversation += "Server: " + txt_msg.Text + Environment.NewLine;
            txt_conversationHistory.Text = conversation;
            txt_msg.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.Close();
            acceptedSock.Close();
        }

        private void txt_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_send_Click(this, new EventArgs());
            }
        }
    }
}
